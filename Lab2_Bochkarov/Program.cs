using System;

namespace Lab2_Bochkarov
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameAccount player1 = new ExtraSeriesPointsGameAccount("Thomas");
            GameAccount player2 = new ExtraSeriesPointsGameAccount("Harry");
            GameAccount player3 = new ExtraSeriesPointsGameAccount("Bober");
            GameAccount player4 = new ThriftyGameAccount("Ricky");

            GameVariety.GetStandardGame(player1, player2, 18);
            GameVariety.GetPracticeGame(player1, player2);
            GameVariety.GetStandardGame(player1, player2, 24);
            
            GameVariety.GetSoloRankedGame(player1, 20);
            GameVariety.GetSoloRankedGame(player3, 20);

            GameVariety.GetStandardGame(player3, player4, 15);
            GameVariety.GetStandardGame(player3, player4, 10);
            GameVariety.GetStandardGame(player3, player4, 27);
            
            
            foreach (var player in GameAccount.GetUsersList())
            {
                Console.WriteLine("<---------------------------------------------------->");
                player.GetStats();
            }   
        }
    }
}