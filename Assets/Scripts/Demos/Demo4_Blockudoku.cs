using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BlockudokuAI.Data;
using BlockudokuAI.Compoent;
using Random = UnityEngine.Random;

namespace BlockudokuAI
{
    public class Demo4_Blockudoku : MonoBehaviour
    {
        public BattleBoard Board;
        public Image BgImage;
        public Text ScoreText;
        public SelectBoard SelectBoard;
        public int SelectCount = 3;
        
        public Button ReplayBtn;

        public int Score
        {
            get=> _score;
            
            set
            {
                _score = value;
                ScoreText.text = $"Score: {_score}";
            }
        }
        private int _score = 0;
        
        public BlockItem SelectBlock => SelectBoard != null ? SelectBoard.SelectedBlock?.SelectBlock : null;
        
        private void Start()
        {
            ReplayBtn.onClick.AddListener(() =>
            {
                ReplayGame();
            });
            
            SelectBoard.InitSelectBoard(SelectCount, () =>
            {
                var blockDataList = new List<BlockData>();
                for (int i = 0; i < SelectCount; i++)
                {
                    var blockData = BlockDataFactory.CreateBlockData(
                        (BlockShapeType)Random.Range(0, (int)BlockShapeType.Length),
                        (BlockRotateType)Random.Range(0, (int)BlockRotateType.Length),
                        (BlockColorType)Random.Range(0, (int)BlockColorType.Length));
                    blockDataList.Add(blockData);
                }
                return blockDataList;
            });
            
            SelectBoard.CreateSelectBlocks();
            
            Score = 0;
        }

        void Update()
        {
            CheckInputClick();
        }

        private void CheckInputClick()
        {
            if (SelectBlock == null)
            {
                return;
            }

            bool ifBlockValid = false;
            
            var mousePos = Input.mousePosition;
            if (RectTransformUtility.RectangleContainsScreenPoint(BgImage.rectTransform, mousePos))
            {
                if(RectTransformUtility.ScreenPointToLocalPointInRectangle(BgImage.rectTransform, mousePos, null, out var localPos))
                {
                    ifBlockValid = Board.TryFollowBlock(localPos, SelectBlock);
                    
                    if (ifBlockValid && Input.GetMouseButtonUp(0))
                    {
                        Board.TryAddBlock();

                        SelectBoard.RemoveSelectBlock();
                        
                        if (SelectBoard.IfEmpty())
                        {
                            SelectBoard.CreateSelectBlocks();
                        }

                        if (Board.TryMatchAndClearBoard(out var matchTypes ,out var matchedCells))
                        {
                            Score += matchTypes.Count * matchedCells.Count;
                        }
                        
                        Board.TryRemoveFollowBlock();
                    }
                }
            }

            if (!ifBlockValid)
            {
                Board.TryRemoveFollowBlock();
            }
        }

        private void ReplayGame()
        {
            Board.ClearBoard();
            SelectBoard.CreateSelectBlocks();
            Score = 0;
        }
    }
}
