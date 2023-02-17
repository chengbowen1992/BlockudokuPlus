using System.Collections.Generic;
using UnityEngine;
using BlockudokuAI.Data;

namespace BlockudokuAI.Compoent
{
    /// <summary>
    /// The view of the block
    /// It contains cell items
    /// </summary>
    public class BlockItem : MonoBehaviour
    {
        public CellItem CopyCellOne;
        public CanvasGroup CanvasAlpha;
        public RectTransform RectTrans => transform as RectTransform;
        public Vector2Int CellSize = new Vector2Int(100, 100);
        private List<CellItem> _cells = new List<CellItem>();
        private BlockData _data;

        public void SetData(BlockData data)
        {
            if (data == null)
            {
                Debug.LogError("BlockItem == SetData data is null");
                return;
            }

            //TODO use a pool 
            foreach (var oldCell in _cells)
            {
                Destroy(oldCell.gameObject);   
            }
            
            _cells.Clear();
            
            _data = data;

            foreach (var cellData in data.BlockCells)
            {
                var newCell = CreateCell(RectTrans, cellData);
                _cells.Add(newCell);
            }
        }

        public BlockData GetData(bool ifClone = false)
        {
            return ifClone ? _data.Clone() : _data;
        }

        public void SetAlpha(float alpha)
        {
            CanvasAlpha.alpha = alpha;
        }

        public void AutoRotate(bool ifReverse = false)
        {
            _data.AutoRotate(ifReverse);
            UpdateCell();
        }

        private void UpdateCell()
        {
            foreach (var cell in _cells)
            {
                cell.UpdateCell();
            }
        }
        
        public void SetLocalPosByCenter(Vector3 centerPos)
        {
            RectTrans.anchoredPosition = GetBlockLocalPosByCenter(centerPos);
        }

        private Vector3 GetBlockLocalPosByCenter(Vector3 centerPos)
        {
            var xOffset = _data.RectSize.x % 2 == 0 ? 0 : CellSize.x / 2;
            var yOffset = _data.RectSize.y % 2 == 0 ? 0 : CellSize.y / 2;
            return centerPos + new Vector3(xOffset, yOffset);
        }

        private CellItem CreateCell(RectTransform root, CellData cellData)
        {
            var cellItem = Instantiate(CopyCellOne, root);
            cellItem.gameObject.SetActive(true);
#if UNITY_EDITOR
            cellItem.name = $"cell_{cellData.Index}:[{cellData.Position.x},{cellData.Position.y}]";
#endif
            cellItem.SetData(cellData);
            cellItem.SetCellSize(CellSize);
            return cellItem;
        }

        public BlockItem Clone(RectTransform root)
        {
            var newBlock = Instantiate(this, root);
            newBlock.gameObject.SetActive(true);
            newBlock.SetData(_data.Clone());
            return newBlock;
        }

        public List<CellItem> CloneCells(RectTransform root, Vector3 centerPos)
        {
            var clonedCells = new List<CellItem>(_cells.Count);

            foreach (var cell in _cells)
            {
                var clonedCell =  CreateCell(root, cell.GetCellData(true));
                var blockLocalPos = GetBlockLocalPosByCenter(centerPos);
                var cellLocalPos = cell.GetLocalPositionOnBlock();
                clonedCell.RectTrans.anchoredPosition = blockLocalPos + cellLocalPos;
                clonedCells.Add(clonedCell);
            }

            return clonedCells;
        }
    }
}