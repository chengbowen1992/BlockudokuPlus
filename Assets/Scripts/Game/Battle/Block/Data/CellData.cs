using System;
using UnityEngine;

namespace BlockudokuAI.Data
{
    public enum CellType
    {
        Normal,
        Skill
    }
    
    /// <summary>
    /// Basic data of the cell
    /// Cells make up blocks
    /// </summary>
    [Serializable]
    public class CellData
    {
        public BlockColorType ColorType;
        
        //Block info the cell belongs to
        public Vector2Int BlockRect;
        public Vector2Int Position;
        public int Index;

        //Reserve for future use
        public CellType Type;
        public int Value;
        
        public CellData(){}
        
        public CellData(BlockColorType colorType, Vector2Int position, Vector2Int blockRect, int index = 0, CellType type = CellType.Normal, int value = 0)
        {
            ColorType = colorType;
            Position = position;
            BlockRect = blockRect;
            Type = type;
            Index = index;
            Value = value;
        }
        
        public void UpdateRectAndPos(Vector2Int blockRect, Vector2Int position)
        {
            BlockRect = blockRect;
            Position = position;
        }

        public Vector2Int GetPosToBlockCenter()
        {
            var blockRect = BlockRect;
            var cellPos = Position;
            var centerPos = new Vector2Int(blockRect.x / 2, blockRect.y / 2);
            var posToCenter = cellPos - centerPos;
            return posToCenter;
        }

        public CellData Clone()
        {
            var cellData = new CellData(ColorType, Position, BlockRect, Index, Type, Value);
            return cellData;
        }
    }
}