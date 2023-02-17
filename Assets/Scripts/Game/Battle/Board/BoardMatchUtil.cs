using System.Collections.Generic;
using UnityEngine;

namespace BlockudokuAI.Data
{
    public enum MatchType
    {
        Horizen0,
        Horizen1,
        Horizen2,
        Horizen3,
        Horizen4,
        Horizen5,
        Horizen6,
        Horizen7,
        Horizen8,

        Vertical0,
        Vertical1,
        Vertical2,
        Vertical3,
        Vertical4,
        Vertical5,
        Vertical6,
        Vertical7,
        Vertical8,

        NineCell0,
        NineCell1,
        NineCell2,
        NineCell3,
        NineCell4,
        NineCell5,
        NineCell6,
        NineCell7,
        NineCell8,
        
        Length,
    }

    /// <summary>
    /// Define the match rule and check the match result
    /// </summary>
    public static class BoardMatchUtil
    {
        //TODO set by configuration
        private static readonly int DefaultBoardWidth = 9;
        private static readonly int DefaultBoardHeight = 9;
        
        private static Dictionary<int, List<Vector2Int>> _matchDic = new Dictionary<int, List<Vector2Int>>();

        static BoardMatchUtil()
        {
            //All Horizontal Match
            for (int i = (int)MatchType.Horizen0; i <= (int)MatchType.Horizen8; i++)
            {
                var index = i - (int)MatchType.Horizen0;

                var horizonMatchList = new List<Vector2Int>();
                for (int j = 0; j < DefaultBoardWidth; j++)
                {
                    horizonMatchList.Add(new Vector2Int(j, index));
                }
                _matchDic[i] = horizonMatchList;
            }
            
            //All Vertical Match
            for (int i = (int)MatchType.Vertical0; i <= (int)MatchType.Vertical8; i++)
            {
                var index = i - (int)MatchType.Vertical0;
                
                var verticalMatchList = new List<Vector2Int>();
                for (int j = 0; j < DefaultBoardHeight; j++)
                {
                    verticalMatchList.Add(new Vector2Int(index, j));
                }
                _matchDic[i] = verticalMatchList;
            }
            
            //All Nine Cell Match
            for (int i = (int)MatchType.NineCell0; i <= (int)MatchType.NineCell8; i++)
            {
                var index = i - (int)MatchType.NineCell0;
                var nineCellMatchList = new List<Vector2Int>();
                
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        nineCellMatchList.Add(new Vector2Int(index % 3 * 3 + j, index / 3 * 3 + k));
                    }
                }
                _matchDic[i] = nineCellMatchList;
            }
        }

        public static bool TryGetAllMatches(this BoardData boardData, out List<MatchType> matchTypes, out HashSet<Vector2Int> matchedIndexs)
        {
            //TODO use a cache to avoid new
            matchTypes = new List<MatchType>();
            matchedIndexs = new HashSet<Vector2Int>();
            
            for (int i = 0; i < (int)MatchType.Length; i++)
            {
                var matchType = (MatchType)i;
                if (boardData.IfMatch(matchType, out var matchList))
                {
                    matchTypes.Add(matchType);
                    foreach (var pos in matchList)
                    {
                        matchedIndexs.Add(pos);
                    }
                }
            }

            return matchTypes.Count > 0;        
        }
        
        private static bool IfMatch(this BoardData boardData, MatchType matchType, out List<Vector2Int> matchList)
        {
            if (!_matchDic.TryGetValue((int)matchType, out matchList))
            {
                Debug.LogError($"BoardMatchUtil == MatchType not found:{matchType.ToString()}");
                return false;
            }

            foreach (var pos in matchList)
            {
                if (boardData.GetCellData(pos) == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}