using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace BlockudokuAI.Compoent
{
    public class SelectItem : MonoBehaviour
    {
        public Button BgButton;
        public Image BgImage;
        public Color UnSelectColor;
        public Color SelectColor;
        
        public bool IfSelect
        {
            get => _ifSelect;
            set
            {
                _ifSelect = value;
                OnSelect(_ifSelect);
            }
        }

        public bool IfBind => _blockItem != null;

        private int _index;
        
        private bool _ifSelect = false;

        private BlockItem _blockItem;

        private Action<SelectBlockInfo> _onSelectBlock;

        private void Start()
        {
            BgButton.onClick.AddListener(OnButtonClick);
            IfSelect = false;
        }

        public void BindBlock(int index, BlockItem blockItem, Action<SelectBlockInfo> onSelectBlock)
        {
            Assert.IsNotNull(blockItem);
            _index = index;
            if (_blockItem)
            {
                Destroy(_blockItem.gameObject);
            }
            
            _blockItem = blockItem;
            _onSelectBlock = onSelectBlock;
            _blockItem.RectTrans.SetParent(transform, false);
            _blockItem.RectTrans.anchoredPosition = Vector2.zero;
            IfSelect = false;
        }

        public SelectBlockInfo UnBindBlock()
        {
            var blockItem = _blockItem;
            _blockItem = null;
            return new SelectBlockInfo() { SelectIndex = _index, SelectBlock = blockItem };
        }

        public void ReBindBlock(BlockItem blockItem)
        {
            _blockItem = blockItem;
            _blockItem.RectTrans.SetParent(transform, false);
            _blockItem.RectTrans.anchoredPosition = Vector2.zero;
            IfSelect = true;
        }

        public int RemoveBlock()
        {
            if (_blockItem)
            {
                Destroy(_blockItem.gameObject);
            }
            _blockItem = null;
            IfSelect = false;
            return _index;
        }

        private void OnButtonClick()
        {
            if (!IfSelect)
            {
                IfSelect = true;
            }
            else
            {
                if (_blockItem)
                {
                    _blockItem.AutoRotate();
                }   
            }
            
            _onSelectBlock?.Invoke(new SelectBlockInfo() { SelectIndex = _index, SelectBlock = _blockItem });
        }

        private void OnSelect(bool ifSelect)
        {
            BgImage.color = ifSelect ? SelectColor : UnSelectColor;
        }
    }
}