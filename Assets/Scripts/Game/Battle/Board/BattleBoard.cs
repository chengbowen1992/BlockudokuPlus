using System.Collections.Generic;
using UnityEngine;
using BlockudokuAI.Data;

namespace BlockudokuAI.Compoent
{
    /// <summary>
    /// The view of the battle board
    /// It deals with add the selected block  as well as clear the matches of the board
    /// </summary>
    public class BattleBoard : MonoBehaviour
    {
        public int BoardWidth = 9;
        public int BoardHeight = 9;
        public float CellSize = 100f;
        public RectTransform BoardRoot;
        
        private Dictionary<Vector2Int, CellItem> _cellItems = new Dictionary<Vector2Int, CellItem>();
        private RectTransform _rectTransform => transform as RectTransform;
        
        private BoardData _boardData;
        
        private BlockItem _followBlock;
        private Vector2Int? _followBlockIndex;

        #region Initialize
        private void Awake()
        {
            _boardData = new BoardData(BoardWidth, BoardHeight);
        }
        #endregion

        #region Check input and make a following block
        
        /// <summary>
        /// Transfer the ui position to board index
        /// </summary>
        /// <param name="uiPos">The local position of the board</param>
        /// <param name="boardIndex">It starts from (0, 0) at the left bottom</param>
        public bool TryGetBoardIndexByUIPos(Vector3 uiPos, out Vector2Int boardIndex)
        {
            var boardSize = new Vector2(BoardWidth * CellSize, BoardHeight * CellSize);
            var transferPos = new Vector2(uiPos.x + boardSize.x * 0.5f, uiPos.y + boardSize.y * 0.5f);
            boardIndex = new Vector2Int(Mathf.FloorToInt(transferPos.x / CellSize), Mathf.FloorToInt(transferPos.y / CellSize));
            return boardIndex.x >= 0 && boardIndex.x < BoardWidth && boardIndex.y >= 0 && boardIndex.y < BoardHeight;
        }

        /// <summary>
        /// Check if the following block can be created
        /// </summary>
        /// <param name="targetIndex">Index on board</param>
        /// <param name="block">It should be create with it's center at the targetIndex</param>
        private bool CanCreateFollowingBlock(Vector2Int targetIndex, BlockItem block)
        {
            return _boardData.CanAddBlock(targetIndex, block.GetData());
        }

        /// <summary>
        /// Try to create a following block or make the following block move by the ui position
        /// </summary>
        /// <param name="uiPos">Local position of the board</param>
        /// <param name="block">The origin block to be created with</param>
        public bool TryFollowBlock(Vector3 uiPos, BlockItem block)
        {
            if(TryGetBoardIndexByUIPos(uiPos, out var boardIndex))
            {
                if (CanCreateFollowingBlock(boardIndex, block))
                {
                    if(_followBlock == null)
                    {
                        CreateFollowBlock(boardIndex, block);
                    }
                    _followBlock.SetLocalPosByCenter(GetLocalPosByIndex(boardIndex));
                    _followBlockIndex = boardIndex;
                    return true;
                }
            }

            if (_followBlock)
            {
                TryRemoveFollowBlock();
            }
            return false;
        }
        
        /// <summary>
        /// Create a following block
        /// </summary>
        /// <param name="boardIndex">The board index and the center of the block to be put on</param>
        /// <param name="block">The origin block to be created with</param>
        private void CreateFollowBlock(Vector2Int boardIndex, BlockItem block)
        {
            if (_followBlock != null)
            {
                Debug.LogError("BattleBoard == CreateFollowingBlock FollowingBlock is not null");
                Destroy(_followBlock.gameObject);
            }

            _followBlock = block.Clone(_rectTransform);
            _followBlock.SetLocalPosByCenter(GetLocalPosByIndex(boardIndex));
            _followBlock.SetAlpha(0.35f);
            _followBlockIndex = boardIndex;
        }
        
        /// <summary>
        /// Remove the following block
        /// </summary>
        public bool TryRemoveFollowBlock()
        {
            if (_followBlock != null)
            {
                Destroy(_followBlock.gameObject);
                _followBlock = null;
                return true;
            }

            _followBlockIndex = null;
            return false;
        }

        /// <summary>
        /// Get the local position by index
        /// </summary>
        /// <param name="boardIndex">The board index</param>
        private Vector3 GetLocalPosByIndex(Vector2Int boardIndex)
        {
            var boardSize = new Vector2(BoardWidth * CellSize, BoardHeight * CellSize);
            var localPos = new Vector3(boardIndex.x * CellSize - boardSize.x * 0.5f, boardIndex.y * CellSize - boardSize.y * 0.5f);
            return localPos + new Vector3(CellSize * 0.5f, CellSize * 0.5f);
        }

        #endregion

        #region Add block to board

        public bool TryAddBlock()
        {
            if (_followBlock == null || !_followBlockIndex.HasValue)
            {
                return false;
            }
            
            return TryAddBlockInternal(_followBlockIndex.Value, _followBlock);
        }

        private bool TryAddBlockInternal(Vector2Int boardIndex, BlockItem block)
        {
            if (_boardData.CanAddBlock(boardIndex, block.GetData()))
            {
                var addedCells = block.CloneCells(BoardRoot, GetLocalPosByIndex(boardIndex));
                foreach (var cell in addedCells)
                {
                    _cellItems.Add(cell.GetCellData().GetPosToBlockCenter() + boardIndex, cell);
                    _boardData.AddBlock(boardIndex, block.GetData());
                }                
                return true;
            }

            return false;
        }

        #endregion

        #region Match and clear Board
        
        public bool TryMatchAndClearBoard(out List<MatchType> matchTypes, out List<CellData> matchedCells)
        {
            matchedCells = null;
            
            if (!_boardData.TryGetAllMatches(out matchTypes, out var matchedIndexs))
            {
                return false;
            }

            matchedCells = new List<CellData>();

            foreach (var index in matchedIndexs)
            {
                if (!_cellItems.TryGetValue(index, out var cellItem))
                {
                    Debug.LogError("BattleBoard == TryMatchAndClearBoard Cell is not exist!");
                    continue;
                }
                matchedCells.Add(cellItem.GetCellData(true));

                TryRemoveCell(index);
            }

            return true;
        }

        private bool TryRemoveCell(Vector2Int boardIndex)
        {
            if (_cellItems.TryGetValue(boardIndex, out var cell))
            {
                _boardData.TryRemoveCell(boardIndex, out var _);
                Destroy(cell.gameObject);
                _cellItems.Remove(boardIndex);
                return true;
            }

            return false;
        }
        
        public void ClearBoard()
        {
            TryRemoveFollowBlock();
            
            foreach (var cell in _cellItems.Values)
            {
                Destroy(cell.gameObject);
            }
            _cellItems.Clear();
            _boardData.Clear();
        }
        #endregion
    }
}