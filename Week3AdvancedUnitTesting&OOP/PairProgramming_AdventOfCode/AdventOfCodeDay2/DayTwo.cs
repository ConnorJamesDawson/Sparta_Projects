namespace AdventOfCodeDay2
{
    public class DayTwo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static int RockPaperScissors(char[] opponentMoves, char[] plannedMoves)
        {
            int result = 0;

            // Went for simplest solution - No accounting for human wrong moves
            for(int i = 0; i < opponentMoves.Length; i++)
            {
                // 'A' for opponent and 'X' for player are both 'Rock'
                if( (opponentMoves[i] == 'A') && (plannedMoves[i] == 'X') ) result += 4;
                // Opponent Rock Player Paper
                else if ( (opponentMoves[i] == 'A') && (plannedMoves[i] == 'Y') ) result += 8;
                // Opponent Rock Player Scissors
                else if ((opponentMoves[i] == 'A') && (plannedMoves[i] == 'Z')) result += 3;
                // Opponent Paper Player Rock
                else if ((opponentMoves[i] == 'B') && (plannedMoves[i] == 'X')) result += 1;
                // Opponent Paper Player Paper
                else if ((opponentMoves[i] == 'B') && (plannedMoves[i] == 'Y')) result += 5;
                // Opponent Paper Player Scissors
                else if ((opponentMoves[i] == 'B') && (plannedMoves[i] == 'Z')) result += 9;
                // Opponent Scissors Player Rock
                else if ((opponentMoves[i] == 'C') && (plannedMoves[i] == 'X')) result += 7;
                // Opponent Scissors Player Paper
                else if ((opponentMoves[i] == 'C') && (plannedMoves[i] == 'Y')) result += 2;
                // opponent Scissors Player Scissors
                else result += 6;
            }
            return result;
        }
    }
}