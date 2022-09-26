using UnityEngine;
using System.Collections.Generic;

namespace Superpow
{
    public class Utils
    {
        public static int GetNumLevels(int world, int subWorld)
        {
            GameLevel[] gameLevels = Resources.LoadAll<GameLevel>("World_" + world + "/SubWorld_" + subWorld);
            return gameLevels.Length;

            //// Indicate the number of levels in specific sub-worlds.
            //int[,] numLevels =
            //{
            //    { 5, 5, 5, 5, 5 }, // For world 0
            //    { 1, 1, 1, 1, 1 }, // For world 1
            //    { 4, 4, 4, 4, 4 }, // For world 2
            //    { 4, 4, 4, 4, 4 }, // For world 3
            //    { 4, 4, 4, 4, 4 }, // For world 4
            //    { 18, 18, 18, 18, 18 }, // For world 5
            //    { 18, 18, 18, 18, 18 }, // Not used yet
            //    { 18, 18, 18, 18, 18 }, // Not used yet
            //    { 18, 18, 18, 18, 18 }, // Not used yet
            //    { 18, 18, 18, 18, 18 }  // Not used yet
            //};

            //return numLevels[world, subWorld];
        }

        public static int GetLeaderboardScore()
        {
            int levelInSub = Prefs.unlockedWorld == 0 && Prefs.unlockedSubWorld == 0 ? 12 : 18;
            int score = (Prefs.unlockedWorld * 5 + Prefs.unlockedSubWorld) * levelInSub + Prefs.unlockedLevel;

            if (levelInSub == 18) score -= 6;
            return score;
        }

        public static GameLevel Load(int world, int subWorld, int level)
        {
            return Resources.Load<GameLevel>("World_" + world + "/SubWorld_" + subWorld + "/Level_" + level);
        }
    }
}