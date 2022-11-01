namespace Lab2_Bochkarov
{
    public class HistoryGame
    {
        public int Rating { get; }
        public GameAccount Opponent { get; }
        public int GameIndex { get; }
        public GameStatus GameStatus{ get; }

        public string GameName { get; }

        public HistoryGame(GameAccount opponent, int rating, int gameIndex, GameStatus gameStatus, string gameName)
        {
            Opponent = opponent;
            Rating = rating;
            GameIndex = gameIndex;
            GameStatus = gameStatus;
            GameName = gameName;
        }
    }
}