namespace AdventOfCode2022.Day2
{
    internal class GameRound
    {
        private const int defeatScore = 0;
        private const int drawScore = 3;
        private const int winScore = 6;

        public Type OpponentType { get; private set; }

        public Type PlayerType { get; private set; }



        public static GameRound FromTextPart1(string input)
        {
            var gameRound = new GameRound();
            var splitted = input.Split(' ');
            var opponentLetter = splitted[0][0];
            var playerLetter = splitted[1][0];

            gameRound.OpponentType = ParseOpponentType(opponentLetter);

            switch (playerLetter)
            {
                case 'X':
                    gameRound.PlayerType = Type.Rock;
                    break;
                case 'Y':
                    gameRound.PlayerType = Type.Paper;
                    break;
                case 'Z':
                    gameRound.PlayerType = Type.Scissors;
                    break;
                default:
                    throw new ArgumentException($"Invalid letter for opponent : {playerLetter}");
            }


            return gameRound;
        }

        public static GameRound FromTextPart2(string input)
        {
            var gameRound = new GameRound();
            var splitted = input.Split(' ');
            var opponentLetter = splitted[0][0];
            var playerLetter = splitted[1][0];

            gameRound.OpponentType = ParseOpponentType(opponentLetter);

            switch (playerLetter)
            {
                case 'X': // Must lose
                    gameRound.PlayerType = GetLosingTypeFor(gameRound.OpponentType);
                    break;
                case 'Y': // Must draw
                    gameRound.PlayerType = gameRound.OpponentType;
                    break;
                case 'Z': // Must win
                    gameRound.PlayerType = GetWinningTypeFor(gameRound.OpponentType);
                    break;
                default:
                    throw new ArgumentException($"Invalid letter for opponent : {playerLetter}");
            }

            return gameRound;
        }

        private static Type ParseOpponentType(char opponentLetter)
        {
            switch (opponentLetter)
            {
                case 'A':
                    return Type.Rock;
                case 'B':
                    return Type.Paper;
                case 'C':
                    return Type.Scissors;
                default:
                    throw new ArgumentException($"Invalid letter for opponent : {opponentLetter}");
            }
        }

        private static Type GetWinningTypeFor(Type inputType)
        {
            switch (inputType)
            {
                case Type.Rock:
                    return Type.Paper;
                case Type.Paper:
                    return Type.Scissors;
                case Type.Scissors:
                    return Type.Rock;
                default:
                    return Type.Unknown;
            }
        }

        private static Type GetLosingTypeFor(Type inputType)
        {
            switch (inputType)
            {
                case Type.Rock:
                    return Type.Scissors;
                case Type.Paper:
                    return Type.Rock;
                case Type.Scissors:
                    return Type.Paper;
                default:
                    return Type.Unknown;
            }
        }

        public int CalculateScore()
        {
            int outcomeScore = this.CalculateOutcome();

            // Type enum is order in such a way score is the enum value.
            return outcomeScore + (int)this.PlayerType;
        }

        private int CalculateOutcome()
        {
            if (this.OpponentType == this.PlayerType)
            {
                return drawScore;
            }

            if (this.OpponentType == Type.Rock)
            {
                return this.PlayerType == Type.Paper ? winScore : defeatScore;
            }

            if (this.OpponentType == Type.Scissors)
            {
                return this.PlayerType == Type.Rock ? winScore : defeatScore;
            }

            // Fallback : Opponent has paper
            return this.PlayerType == Type.Scissors ? winScore : defeatScore;
        }
    }
}
