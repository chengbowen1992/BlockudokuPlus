using UnityEngine;
using UnityEngine.UI;
using BlockudokuAI.Data;

namespace BlockudokuAI.Compoent
{
    /// <summary>
    /// The view of the cell
    /// It can be used to create a block or add to the board
    /// </summary>
    public class CellItem : MonoBehaviour
    {
        public Sprite[] FullSprites;
        private CellData _data;
        public Image BgImage;
        public Vector2 CellSize = new Vector2(100f, 100f);
        public RectTransform RectTrans => transform as RectTransform;
        
        public void SetData(CellData data)
        {
            _data = data;
            UpdateCell();
        }

        public void SetCellSize(Vector2 cellSize)
        {
            CellSize = cellSize;
            UpdateCell();
        }
        
        public void UpdateCell()
        {
            UpdateColor();
            UpdateLocalPosition();
        }

        private void UpdateColor()
        {
            if (_data != null)
            {
                BgImage.sprite = FullSprites[(int)_data.ColorType];        
            }
        }

        private void UpdateLocalPosition()
        {
            RectTrans.anchoredPosition = GetLocalPositionOnBlock();
        }
        
        public Vector3 GetLocalPositionOnBlock()
        {
            var blockRect = _data.BlockRect;
            var cellPos = _data.Position;
            var cellSize = CellSize;
            var centerPos = new Vector2(blockRect.x * cellSize.x * 0.5f, blockRect.y * cellSize.y * 0.5f);
            var localPos = new Vector2(cellPos.x * cellSize.x, cellPos.y * cellSize.y) - centerPos;
            return localPos;
        }

        public CellData GetCellData(bool ifClone = false)
        {
            return ifClone ? _data.Clone() : _data;
        }
    }
}