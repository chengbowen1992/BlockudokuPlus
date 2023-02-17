using UnityEngine;

namespace BlockudokuAI.Data
{
    /// <summary>
    /// Basic data of the board
    /// BoardData contains cells on board
    /// </summary>
    [System.Serializable]
    public class BoardData
    {
        public int Width;
        public int Height;
        public CellData[,] Cells;
        
        public BoardData(){}
        
        public BoardData(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new CellData[height, width];
        }

        #region Add block to board
        public bool CanAddBlock(Vector2Int centerIndex,BlockData blockData)
        {
            var cells = blockData.BlockCells;
            foreach (var cell in cells)
            {
                var posToCenter = cell.GetPosToBlockCenter();
                var targetPos = posToCenter + centerIndex;
                if (targetPos.x < 0 || targetPos.x >= Width || targetPos.y < 0 || targetPos.y >= Height)
                {
                    return false;
                }

                if (Cells[targetPos.y, targetPos.x] != null)
                {
                    return false;
                }
            }

            return true;
        }

        public void AddBlock(Vector2Int centerIndex, BlockData blockData)
        {
            foreach (var cell in blockData.BlockCells)
            {
                var newCell = cell.Clone();
                var targetIndex = cell.GetPosToBlockCenter() + centerIndex;
                Cells[targetIndex.y, targetIndex.x] = newCell;
            }
        }

        public CellData RemoveCell(Vector2Int position)
        {
            var cell = Cells[position.y, position.x];
            if (cell != null)
            {
                Cells[position.y, position.x] = null;
            }

            return cell;
        }
        #endregion

        #region Check cell's matchment and clear

        public bool TryRemoveCell(Vector2Int position, out CellData cellData)
        {
            cellData = Cells[position.y, position.x];
            if (cellData != null)
            {
                Cells[position.y, position.x] = null;
                return true;
            }

            return false;
        }

        #endregion
        
        #region Other Interfaces
        public void SetCellData(CellData cellData)
        {
            var pos = cellData.Position;
            Cells[pos.y, pos.x] = cellData;
        }
        
        public CellData GetCellData(Vector2Int pos)
        {
            return Cells[pos.y, pos.x];
        }

        public bool TryGetCellData(int x, int y, out CellData cellData)
        {
            cellData = Cells[y, x];
            return cellData != null;
        }
        
        public void Clear()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Cells[y, x] = null;
                }
            }
        }
        #endregion
    }
}