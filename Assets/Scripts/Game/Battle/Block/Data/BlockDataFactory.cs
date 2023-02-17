using System.Collections.Generic;
using UnityEngine;

namespace BlockudokuAI.Data
{
    /// <summary>
    /// The factory to create block data.
    /// </summary>
    public static class BlockDataFactory
    {
        /// <summary>
        /// Block Shape's position relative to the origin.
        /// The origin is at the bottom left corner of the shape.
        /// TODO: Config it by tool or excel.
        /// </summary>
        private static readonly Dictionary<Vector2Int, List<Vector2Int>> BlockShapeDictionary =
            new Dictionary<Vector2Int, List<Vector2Int>>()
            {
                #region Cell1
                /*
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell1, (int)BlockRotateType.Default),
                    new List<Vector2Int>() { new Vector2Int(0, 0) }
                },
                {
                    new Vector2Int((int)BlockShapeType.Cell1, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>() { new Vector2Int(0, 0) }
                },
                {
                    new Vector2Int((int)BlockShapeType.Cell1, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>() { new Vector2Int(0, 0) }
                },
                {
                    new Vector2Int((int)BlockShapeType.Cell1, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>() { new Vector2Int(0, 0) }
                },
                #endregion

                #region Cell2
                /*
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell2, (int)BlockRotateType.Default),
                    new List<Vector2Int>() { new Vector2Int(0, 0), new Vector2Int(1, 0) }
                },
                /*
                 * x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell2, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>() { new Vector2Int(0, 1), new Vector2Int(0, 0) }
                },
                /*
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell2, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>() { new Vector2Int(1, 0), new Vector2Int(0, 0) }
                },
                /*
                 * x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell2, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>() { new Vector2Int(0, 0), new Vector2Int(0, 1) }
                },
                #endregion

                #region Cell3

                /*
                 * x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell3Line, (int)BlockRotateType.Default),
                    new List<Vector2Int>() { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(2, 0) }
                },
                /*
                 * x
                 * x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell3Line, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>() { new Vector2Int(0, 2), new Vector2Int(0, 1), new Vector2Int(0, 0) }
                },
                /*
                 * x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell3Line, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>() { new Vector2Int(2, 0), new Vector2Int(1, 0), new Vector2Int(0, 0) }
                },
                /*
                 * x
                 * x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell3Line, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>() { new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(0, 2) }
                },

                /*
                 * x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell3L, (int)BlockRotateType.Default),
                    new List<Vector2Int>() {new Vector2Int(0, 1), new Vector2Int(0, 0), new Vector2Int(1, 0) }
                },
                /*
                 * x x
                 * x 
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell3L, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>() { new Vector2Int(1, 1) , new Vector2Int(0, 1),new Vector2Int(0, 0)  }
                },
                /*
                 * x x
                 *   x 
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell3L, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>() { new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(0, 1) }
                },
                /*
                 *   x
                 * x x 
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell3L, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>() { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(1, 1) }
                },
                #endregion

                #region Cell4

                /*
                 * x x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Line, (int)BlockRotateType.Default),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(2, 0), new Vector2Int(3, 0) }
                },

                /*
                 * x
                 * x
                 * x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Line, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 3), new Vector2Int(0, 2), new Vector2Int(0, 1), new Vector2Int(0, 0) }
                },

                /*
                 * x x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Line, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>() { new Vector2Int(3, 0), new Vector2Int(2, 0), new Vector2Int(1, 0), new Vector2Int(0, 0) }
                },

                /*
                 * x
                 * x
                 * x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Line, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(0, 2), new Vector2Int(0, 3) }
                },

                /*
                 * x x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Square, (int)BlockRotateType.Default),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(1, 0) }
                },

                /*
                 * x x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Square, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(1, 0), new Vector2Int(0, 0)}
                },

                /*
                 * x x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Square, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>()
                        { new Vector2Int(1, 1), new Vector2Int(1, 0), new Vector2Int(0, 0),  new Vector2Int(0, 1) }
                },

                /*
                 * x x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Square, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>()
                        { new Vector2Int(1, 0), new Vector2Int(0, 0),  new Vector2Int(0, 1), new Vector2Int(1, 1) }
                },

                /*
                 * x
                 * x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4L, (int)BlockRotateType.Default),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 2), new Vector2Int(0, 1), new Vector2Int(0, 0), new Vector2Int(1, 0) }
                },

                /*
                 * x x x
                 * x 
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4L, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>()
                        { new Vector2Int(2, 1), new Vector2Int(1, 1), new Vector2Int(0, 1), new Vector2Int(0, 0) }
                },

                /*
                 * x x
                 *   x
                 *   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4L, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>()
                        { new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(1, 2), new Vector2Int(0, 2) }
                },

                /*
                 *     x
                 * x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4L, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(2, 0), new Vector2Int(2, 1) }
                },

                /*
                 *   x
                 *   x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4L2, (int)BlockRotateType.Default),
                    new List<Vector2Int>()
                        { new Vector2Int(1, 2), new Vector2Int(1, 1), new Vector2Int(1, 0), new Vector2Int(0, 0) }
                },

                /*
                 * x
                 * x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4L2, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>()
                        { new Vector2Int(2, 0), new Vector2Int(1, 0), new Vector2Int(0, 0), new Vector2Int(0, 1) }
                },

                /*
                 * x x
                 * x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4L2, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(0, 2), new Vector2Int(1, 2) }
                },

                /*
                 * * * *
                 *     *
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4L2, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(2, 1), new Vector2Int(2, 0) }
                },

                /*
                 * x x x
                 *   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4T, (int)BlockRotateType.Default),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(1, 0), new Vector2Int(2, 1) }
                },

                /*
                 *   x
                 * x x
                 *   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4T, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>()
                        { new Vector2Int(1, 2), new Vector2Int(1, 1), new Vector2Int(0, 1), new Vector2Int(1, 0) }
                },

                /*
                 *   x
                 * x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4T, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>()
                        { new Vector2Int(2, 0), new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(0, 0) }
                },

                /*
                 * x
                 * x x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4T, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(0, 2) }
                },

                /*
                 * x x
                 *   x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Z, (int)BlockRotateType.Default),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(1, 0), new Vector2Int(2, 0) }
                },

                /*
                 *   x
                 * x x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Z, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>()
                        { new Vector2Int(1, 2), new Vector2Int(1, 1), new Vector2Int(0, 1), new Vector2Int(0, 0) }
                },
                
                /*
                 * x x
                 *   x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Z, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>()
                        { new Vector2Int(2, 0), new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(0, 1) }
                },
                
                /*
                 *   x
                 * x x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Z, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(1, 2) }
                },
                
                
                /*
                 *   x x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Z2, (int)BlockRotateType.Default),
                    new List<Vector2Int>()
                        { new Vector2Int(2, 1) , new Vector2Int(1, 1), new Vector2Int(1, 0), new Vector2Int(0, 0) }
                },
                
                /*
                 * x
                 * x x
                 *   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Z2, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>()
                        { new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(0, 1), new Vector2Int(0, 2) }
                },
                
                /*
                 *   x x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Z2, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(2, 1) }
                },
                
                /*
                 * x
                 * x x
                 *   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell4Z2, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 2), new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(1, 0) }
                },
                
                #endregion

                #region Cell5

                /*
                 * x
                 * x
                 * x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5L, (int)BlockRotateType.Default),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 2), new Vector2Int(0, 1), new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(2, 0) }
                },

                /*
                 * x x x 
                 * x
                 * x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5L, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>()
                        { new Vector2Int(2, 2), new Vector2Int(1, 2), new Vector2Int(0, 2), new Vector2Int(0, 1), new Vector2Int(0, 0) }
                },
                
                /*
                 * x x x
                 *     x
                 *     x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5L, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>()
                        { new Vector2Int(2, 0), new Vector2Int(2, 1), new Vector2Int(2, 2), new Vector2Int(1, 2), new Vector2Int(0, 2) }
                },
                
                /*
                 *     x
                 *     x
                 * x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5L, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>()
                        { new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(2, 0), new Vector2Int(2, 1), new Vector2Int(2, 2) }
                },

                /*
                 *   x
                 * x x x
                 *   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5X, (int)BlockRotateType.Default),
                    new List<Vector2Int>(){ new Vector2Int(0,1), new Vector2Int(1,2), new Vector2Int(2,1) , new Vector2Int(1,0), new Vector2Int(1,1)}
                },
                
                /*
                 *   x
                 * x x x
                 *   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5X, (int)BlockRotateType.Degree90),
                    new List<Vector2Int>(){ new Vector2Int(1,2), new Vector2Int(2,1) , new Vector2Int(1,0) ,  new Vector2Int(0,1), new Vector2Int(1,1)}
                },
                
                /*
                 *   x
                 * x x x
                 *   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5X, (int)BlockRotateType.Degree180),
                    new List<Vector2Int>(){ new Vector2Int(2,1) , new Vector2Int(1,0) ,  new Vector2Int(0,1) , new Vector2Int(1,2), new Vector2Int(1,1)}
                },
                
                /*
                 *   x
                 * x x x
                 *   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5X, (int)BlockRotateType.Degree270),
                    new List<Vector2Int>(){  new Vector2Int(1,0) ,  new Vector2Int(0,1) , new Vector2Int(1,2), new Vector2Int(2,1), new Vector2Int(1,1)}
                },
                
                /*
                 * x   x
                 * x x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5U,(int)BlockRotateType.Default), 
                    new List<Vector2Int>(){ new Vector2Int(0,1), new Vector2Int(0,0), new Vector2Int(1, 0), new Vector2Int(2,0), new Vector2Int(2,1)}
                },
                
                /*
                 * x x 
                 * x 
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5U,(int)BlockRotateType.Degree90), 
                    new List<Vector2Int>(){ new Vector2Int(1,2), new Vector2Int(0,2), new Vector2Int(0, 1), new Vector2Int(0,0), new Vector2Int(1,0)}
                },
                
                /*
                 * x x x
                 * x   x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5U,(int)BlockRotateType.Degree180), 
                    new List<Vector2Int>(){ new Vector2Int(2,0), new Vector2Int(2,1), new Vector2Int(1, 1), new Vector2Int(0,1), new Vector2Int(0,0)}
                },
                
                /*
                 * x x
                 *   x
                 * x x
                 */
                {
                    new Vector2Int((int)BlockShapeType.Cell5U,(int)BlockRotateType.Degree270), 
                    new List<Vector2Int>(){ new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(1, 1), new Vector2Int(1,2), new Vector2Int(0,2)}
                },
                
                #endregion
            };

        public static BlockData CreateBlockData(BlockShapeType shapeType, BlockRotateType rotateType,
            BlockColorType colorType)
        {
            if (!BlockShapeDictionary.TryGetValue(new Vector2Int((int)shapeType, (int)rotateType), out var shapeCells))
            {
                Debug.LogError($"BlockDataFactory == CreateBlock: does not contain key {shapeType.ToString()}, {rotateType.ToString()}");
                return null;
            }
            
            var blockData = new BlockData(shapeType, rotateType, colorType, shapeCells);
            return blockData;
        }

        public static BlockData RotateBlockTo(this BlockData data, BlockRotateType rotateType)
        {
            if (data == null)
            {
                return null;
            }
            
            if (!BlockShapeDictionary.TryGetValue(new Vector2Int((int)data.ShapeType, (int)rotateType), out var shapeCells))
            {
                Debug.LogError($"BlockDataFactory == RotateBlockTo: does not contain key {data.ShapeType.ToString()}, {rotateType.ToString()}");
                return null;
            }
            
            data.SetRotateType(rotateType, shapeCells);
            return data;
        }
    }
}