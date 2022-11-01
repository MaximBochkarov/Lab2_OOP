using System;
using System.Collections.Generic;

namespace Lab2_Bochkarov
{
    public class GameAccount
    {
        private string UserName { get; }
        private int _currentRating;
        public int CurrentRating
        {
            get => _currentRating;
            protected set => _currentRating = value < 1 ? 1 : value;
        }

        private const int InitialRating = 100;
        
        protected readonly List<HistoryGame> AllStats = new List<HistoryGame>();

        private static readonly List<GameAccount> UsersList = new List<GameAccount>();

        public static readonly GameAccount System = new GameAccount();

        public GameAccount(string userName)
        {
            UsersList.Add(this);
            UserName = userName;
            CurrentRating = InitialRating;
        }

        private GameAccount()
        {
            CurrentRating = Int32.MaxValue - InitialRating;
            UserName = "System";
        }

        public static List<GameAccount> GetUsersList()
        {
            return UsersList;
        }
        public virtual void WinGame(Game game, GameAccount opponent)
        {
            AllStats.Add(new HistoryGame(opponent, game.Rating, game.GameIndex, GameStatus.Win, game.GetType().Name));
            CurrentRating += game.Rating;
        }
        public virtual void LoseGame(Game game, GameAccount opponent)
        {
            AllStats.Add(new HistoryGame(opponent, game.Rating, game.GameIndex, GameStatus.Lose, game.GetType().Name));
            CurrentRating -= game.Rating;
        }
        public virtual void GetStats()
        {
            int gameNumber = 1;
            Console.WriteLine($"(<-The game history for: {UserName}->)");
            Console.WriteLine($"Total games: {AllStats.Count} | Current rating: {CurrentRating} =>");
            foreach(var game in AllStats)
            {
                Console.Write($"{gameNumber++}-({game.GameName}) --> \t");
                Console.WriteLine(game.GameStatus.Equals(GameStatus.Win)
                    ? $"Win against {game.Opponent.UserName},\t game rating: {game.Rating},\t index: {game.GameIndex}."
                    : $"Lose against {game.Opponent.UserName},\t game rating: {game.Rating},\t index: {game.GameIndex}.");
            }
            
        }

    }

    public class ThriftyGameAccount : GameAccount
    {
        public ThriftyGameAccount(string userName) : base(userName)
        {
        }

        public override void GetStats()
        {
            Console.WriteLine("Account type: Thrifty");
            base.GetStats();
        }

        public override void LoseGame(Game game, GameAccount opponent)
        {
            AllStats.Add(new HistoryGame(opponent, game.Rating, game.GameIndex, GameStatus.Lose, game.GetType().Name));
            CurrentRating -= game.Rating / 2;
        }
    }

    public class ExtraSeriesPointsGameAccount : GameAccount
    {
        private int _series;
        private int _extraPoints;
        
        public ExtraSeriesPointsGameAccount(string userName) : base(userName)
        {
            _series = 0;
            _extraPoints = 0;
        }
        public override void WinGame(Game game, GameAccount opponent)
        {
            AllStats.Add(new HistoryGame(opponent, game.Rating, game.GameIndex, GameStatus.Win, game.GetType().Name));
            SeriesCount();
            SeriesExtraPoints();
            CurrentRating += game.Rating;
        }
        public override void LoseGame(Game game, GameAccount opponent)
        {
            AllStats.Add(new HistoryGame(opponent, game.Rating, game.GameIndex, GameStatus.Lose, game.GetType().Name));
            SeriesReset();
            CurrentRating -= game.Rating;
        }
        private void SeriesExtraPoints()
        {
            if (_series is < 3 or > 10) return;

            switch (_series)
            {
                case 3:
                    CurrentRating += 30;
                    _extraPoints += 30;
                    break;
                case 5:
                    CurrentRating += 50;
                    _extraPoints += 50;
                    break;
                case 10:
                    CurrentRating += 100;
                    _extraPoints += 100;
                    break;
            }
        }
        private void SeriesCount() => ++_series;
        private void SeriesReset() => _series = 0;
        public override void GetStats()
        {
            Console.WriteLine("Account type: ExtraSeriesPoints");
            base.GetStats();
            Console.WriteLine($"Accrued extra rating points: {_extraPoints}; (special account bonuses)");
        }
    }
}