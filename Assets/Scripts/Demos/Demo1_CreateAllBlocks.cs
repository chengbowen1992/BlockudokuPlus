using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BlockudokuAI.Data;
using BlockudokuAI.Compoent;

namespace BlockudokuAI.Demo
{
    public class Demo1_CreateAllBlocks : MonoBehaviour
    {
        public RectTransform BlockRoot;
        public Button PreRotateButton;
        public Button NextRotateButton;
        
        private List<BlockItem> _blocks = new List<BlockItem>();

        private void Start()
        {
            for (int i = 0; i < (int)BlockShapeType.Length; i++)
            {
                for (int j = 0; j < (int)BlockRotateType.Length; j++)
                {
                    var block = CreateNewBlock(i, j, BlockRoot);
                    ((RectTransform)block.transform).anchoredPosition = new Vector2(j * 400, -i * 400);
                    _blocks.Add(block);
                }
            }
            
            PreRotateButton.onClick.AddListener(() =>
            {
                foreach (var b in _blocks)
                {
                    b.AutoRotate(true);
                }
            });
            
            NextRotateButton.onClick.AddListener(() =>
            {
                foreach (var b in _blocks)
                {
                    b.AutoRotate();
                }
            });
        }

        private BlockItem CreateNewBlock(int blockShapeType, int blockVariation, Transform blockParent)
        {
            var blockData = BlockDataFactory.CreateBlockData((BlockShapeType)blockShapeType, (BlockRotateType)blockVariation, BlockColorType.Red);
            
            //change block cell's color
            for (int i = 0; i < blockData.CellCount; i++)
            {
                blockData.BlockCells[i].ColorType = (BlockColorType)i;
            }
            
            var block = BlockItemCreator.CreateBlockItem(blockData);
            block.transform.SetParent(blockParent, false);
            block.transform.localPosition = Vector3.zero;
            return block;
        }
    }
}