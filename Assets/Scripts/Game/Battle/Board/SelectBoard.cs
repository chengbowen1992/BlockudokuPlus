using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using BlockudokuAI.Data;

namespace BlockudokuAI.Compoent
{
    public class SelectBoard : MonoBehaviour
    {
        public RectTransform DisplayRoot;
        public SelectItem CopyItem;

        private List<SelectItem> _selectItems;
        private Func<List<BlockData>> _getSelectBlocks;

        private int _selectCount = 0;

        public SelectBlockInfo SelectedBlock { get; private set; } = null;

        public void InitSelectBoard(int selectCount, Func<List<BlockData>> getSelectBlocks)
        {
            Assert.IsNotNull(getSelectBlocks);
            Assert.IsTrue(selectCount > 0);
            
            _selectCount = selectCount;
            _getSelectBlocks = getSelectBlocks;
            _selectItems = new List<SelectItem>(_selectCount);
            
            for (int i = 0; i < _selectCount; i++)
            {
                var newItem = Instantiate(CopyItem, DisplayRoot, false);
                _selectItems.Add(newItem);
            }
        }

        public void CreateSelectBlocks()
        {
            CreateSelectBlocks(_getSelectBlocks.Invoke());
            OnSelectedChanged(null);
        }

        private void CreateSelectBlocks(List<BlockData> blockDataList)
        {
            Assert.IsTrue(blockDataList.Count == _selectCount);
            
            for (int i = 0; i < _selectCount; i++)
            {
                var blockData = blockDataList[i];
                var selectItem = _selectItems[i];
                var blockItem = BlockItemCreator.CreateBlockItem(blockData);
                selectItem.BindBlock(i, blockItem, item =>
                {
                    OnSelectedChanged(item);
                });
            }
        }

        public void RemoveSelectBlock()
        {
            if(SelectedBlock == null)
            {
                return;
            }
            
            var selectItem = _selectItems[SelectedBlock.SelectIndex];
            selectItem.RemoveBlock();
            SelectedBlock = null;
        }
        
        public bool IfEmpty()
        {
            foreach (var selectItem in _selectItems)
            {
                if (selectItem.IfBind)
                {
                    return false;
                }
            }

            return true;
        }

        private void OnSelectedChanged(SelectBlockInfo selectBlockInfo)
        {
            SelectedBlock = selectBlockInfo;

            var selectedIndex = SelectedBlock?.SelectIndex ?? -1;
            
            for (int i = 0; i < _selectItems.Count; i++)
            {
                if (i == selectedIndex)
                {
                    continue;
                }
                
                _selectItems[i].IfSelect = false;
            }
        }
    }
}