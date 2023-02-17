using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace BlockudokuAI.Data
{
    public enum BlockShapeType
    {
        Cell1,
        
        Cell2,
        
        Cell3Line,
        Cell3L,
        
        Cell4Line,
        Cell4Square,
        Cell4L,
        Cell4L2,
        Cell4Z,
        Cell4Z2,
        Cell4T,

        Cell5X,
        Cell5L,
        Cell5U,
        
        Length,
    }

    public enum BlockRotateType
    {
        Default,
        Degree90,
        Degree180,
        Degree270,
        
        Length,
    }

    public enum BlockColorType
    {
        Red,
        Green,
        Blue,
        Yellow,
        Purple,
        
        Length,
    }
    
    /// <summary>
    /// Basic block data
    /// Blocks are made up of cells
    /// </summary>
    [Serializable]
    public class BlockData
    {
        public BlockShapeType ShapeType;
        public BlockRotateType RotateType;
        public BlockColorType ColorType;
        
        public Vector2Int RectSize;
        public int CellCount;
        
        public List<CellData> BlockCells;

        public BlockData(){}
        
        public BlockData(BlockShapeType shapeType, BlockRotateType rotateType, BlockColorType colorType, List<Vector2Int> cellPositions)
        {
            Assert.IsTrue(cellPositions != null && cellPositions.Count > 0);

            ShapeType = shapeType;
            RotateType = rotateType;
            ColorType = colorType;
            BlockCells = new List<CellData>(cellPositions.Count);
            RectSize = GetBlockRectSize(cellPositions);
            for (int i = 0; i < cellPositions.Count; i++)
            {
                var cellPos = cellPositions[i];
                BlockCells.Add(new CellData(colorType, cellPos, RectSize, i));
            }

            CellCount = BlockCells.Count;
        }

        public void AutoRotate(bool ifReverse = false)
        {
            this.RotateBlockTo(ifReverse ? GetPrevRotateType(RotateType) : GetNextRotateType(RotateType));
        }

        public void SetRotateType(BlockRotateType rotateType, List<Vector2Int> cellPositions, bool ifForceChange = false)
        {
            if(ifForceChange == false && rotateType == RotateType)
                return;
            
            RotateType = rotateType;

            if (BlockCells.Count != cellPositions.Count)
            {
                Debug.LogError($"BlockData == SetVariant: BlockCells.Count != cellPositions.Count");
                return;
            }
            
            RectSize = GetBlockRectSize(cellPositions);
            
            for (int i = 0; i < BlockCells.Count; i++)
            {
                var blockCell = BlockCells[i];
                blockCell.UpdateRectAndPos(RectSize, cellPositions[i]);
            }
        }

        private Vector2Int GetBlockRectSize(List<Vector2Int> cells)
        {
            var rectSize = Vector2Int.zero;

            if (cells == null || cells.Count == 0)
            {
                return rectSize;
            }
            
            foreach (var cell in cells)
            {
                rectSize.x = Mathf.Max(rectSize.x, cell.x);
                rectSize.y = Mathf.Max(rectSize.y, cell.y);
            }

            return rectSize;
        }
        
        private BlockRotateType GetNextRotateType(BlockRotateType rotateType)
        {
            return (BlockRotateType)(((int)rotateType + 1) % (int)BlockRotateType.Length);
        }
        
        private BlockRotateType GetPrevRotateType(BlockRotateType rotateType)
        {
            return (BlockRotateType)(((int)rotateType - 1 + (int)BlockRotateType.Length) % (int)BlockRotateType.Length);
        }

        public BlockData Clone()
        {
            var cloneData = new BlockData()
            {
                ShapeType = ShapeType, RotateType = RotateType, ColorType = ColorType, RectSize = RectSize,
                CellCount = CellCount
            };
            cloneData.BlockCells = new List<CellData>(BlockCells.Count);
            foreach (var cellData in BlockCells)
            {
                cloneData.BlockCells.Add(cellData.Clone());
            }

            return cloneData;
        }
    }
}