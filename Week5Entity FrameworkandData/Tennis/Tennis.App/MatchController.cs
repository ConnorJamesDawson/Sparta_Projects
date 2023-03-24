using System.Linq.Expressions;
using Tennis.App.GameStates;

namespace Tennis.App;

public static class MatchController
{
    public static Score Player1ScoreEnum { get; set; } = 0;
    public static Score Player2ScoreEnum { get; set; } = 0;

    public static int Player1SetWins { get; set; } = 0;
    public static int Player2SetWins { get; set; } = 0;

    public static StateOfGame stateOfGame = 0; //State at normal

    public static NormalState normalState = new();
    public static DeuceState deuceState = new();
    public static AdvantageP1 advantageP1State = new();
    public static AdvantageP2 advantageP2State = new();
    public static WinState winState = new();

    public static string Player1Scores()
    {
        return StateMachine(1);
    }

    public static string Player2Scores()
    {
        return StateMachine(2);
    }

    public static string StateMachine(int i)
    {
        switch(stateOfGame)
        {
            case StateOfGame.Normal:
                switch(i)
                {
                    case 1:
                        return normalState.GetScoreStringPlayer1();
                    case 2:
                        return normalState.GetScoreStringPlayer2();
                }
                break;
            case StateOfGame.Deuce:
                switch (i)
                {
                    case 1:
                        return deuceState.GetScoreStringPlayer1();
                    case 2:
                        return deuceState.GetScoreStringPlayer2();
                }
                break;
            case StateOfGame.AdvantageP1:
                switch (i)
                {
                    case 1:
                        return advantageP1State.GetScoreStringPlayer1();
                    case 2:
                        return advantageP1State.GetScoreStringPlayer2();
                }
                break;
            case StateOfGame.AdvantageP2:
                switch (i)
                {
                    case 1:
                        return advantageP2State.GetScoreStringPlayer1();
                    case 2:
                        return advantageP2State.GetScoreStringPlayer2();
                }
                break;
            case StateOfGame.Win:
                switch (i)
                {
                    case 1:
                        return winState.GetScoreStringPlayer1();
                    case 2:
                        return winState.GetScoreStringPlayer2();
                }
                break;
            default:
                return "There was an error!";
        }
        return "How did I get Here?";
    }

    public static string GetSetsWon()
    {
        if (Player1SetWins == 3)
        {
            return "Player One wins the match!";
        }
        if (Player2SetWins == 3)
        {
            return "Player Two wins the match!";
        }
        return $"Player One Sets: {Player1SetWins}, Player Two Sets: {Player2SetWins}";
    }

    public static void ResetScores()
    {
        Player1ScoreEnum = 0;
        Player2ScoreEnum = 0;
        stateOfGame = StateOfGame.Normal;
    }

    public static void ResetSetWins()
    {
        Player1SetWins = 0;
        Player2SetWins = 0;
    }
}
