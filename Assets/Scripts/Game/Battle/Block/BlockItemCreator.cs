using UnityEngine;
using BlockudokuAI.Data;

namespace BlockudokuAI.Compoent
{
    /// <summary>
    /// The creator of the block item
    /// </summary>
    public static class BlockItemCreator
    {
        public static readonly string DefaultBlockItemPath = "Game/Prefabs/Blocks/BlockItem";
        
        public static BlockItem CreateBlockItem(BlockData blockData)
        {
            var blockItem = Object.Instantiate(Resources.Load<BlockItem>(DefaultBlockItemPath));
#if UNITY_EDITOR
            blockItem.name = $"Block{blockData.ShapeType.ToString()}-{blockData.RotateType.ToString()}";
#endif
            blockItem.SetData(blockData);
            return blockItem;
        }
    }
}