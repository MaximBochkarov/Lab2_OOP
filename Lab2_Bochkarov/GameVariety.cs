using System;

namespace Lab2_Bochkarov
{
    public static class GameVariety
    {
        private static readonly Random Random = new Random();
        public static Game GetStandardGame(GameAccount acc1, GameAccount acc2, int rating)
        {
            return new StandardGame(acc1, acc2, rating);
        }
        public static Game GetPracticeGame(GameAccount acc1, GameAccount acc2)
        {
            return new PracticeGame(acc1, acc2);
        }
        public static Game GetSoloRankedGame(GameAccount acc1, int rating)
        {
            return new SoloRankedGame(acc1, rating);
        }
    }
}