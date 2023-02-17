using UnityEngine;
using UnityEngine.UI;
using BlockudokuAI.Data;
using BlockudokuAI.Compoent;
using Random = UnityEngine.Random;

namespace BlockudokuAI
{
    public class Demo3_BlockClear : MonoBehaviour
    {
        public RectTransform DisplayRoot;
        public BattleBoard Board;
        public Image BgImage;
        
        public Button PreVariantBtn;
        public Button NextVariantBtn;
        public Button ReplayBtn;
        
        private BlockItem _randomBlock;
        
        private void Start()
        {
            CreateSelectBlock();
            PreVariantBtn.onClick.AddListener(() =>
            {
                CreateSelectBlock();
            });
            NextVariantBtn.onClick.AddListener(() =>
            {
                _randomBlock.AutoRotate();
            });
            ReplayBtn.onClick.AddListener(() =>
            {
                Board.ClearBoard();
                CreateSelectBlock();
            });
        }

        private void CreateSelectBlock()
        {
            if (_randomBlock)
            {
                Destroy(_randomBlock.gameObject);
                _randomBlock = null;
            }
            
            var blockData = BlockDataFactory.CreateBlockData(
                (BlockShapeType)Random.Range(0, (int)BlockShapeType.Length),
                (BlockRotateType)Random.Range(0, (int)BlockRotateType.Length),
                (BlockColorType)Random.Range(0, (int)BlockColorType.Length));

            _randomBlock = BlockItemCreator.CreateBlockItem(blockData);
            _randomBlock.transform.SetParent(DisplayRoot, false);
        }

        void Update()
        {
            DealWithInputClick();
        }

        private void DealWithInputClick()
        {
            bool ifBlockValid = false;
            
            var mousePos = Input.mousePosition;
            if (RectTransformUtility.RectangleContainsScreenPoint(BgImage.rectTransform, mousePos))
            {
                if(RectTransformUtility.ScreenPointToLocalPointInRectangle(BgImage.rectTransform, mousePos, null, out var localPos))
                {
                    ifBlockValid = Board.TryFollowBlock(localPos, _randomBlock);
                    
                    if (ifBlockValid && Input.GetMouseButtonUp(0))
                    {
                        Board.TryAddBlock();
                        
                        CreateSelectBlock();
                        
                        if (Board.TryMatchAndClearBoard(out var matchTypes ,out var matchedCells))
                        {
                            //TODO Deal with score
                            Board.TryRemoveFollowBlock();
                        }
                    }
                }
            }

            if (!ifBlockValid)
            {
                Board.TryRemoveFollowBlock();
            }
        }
    }
}
