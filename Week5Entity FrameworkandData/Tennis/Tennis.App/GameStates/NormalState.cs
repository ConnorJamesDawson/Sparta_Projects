namespace Tennis.App.GameStates;

public class NormalState : IScore
{
    public string GetScoreStringPlayer1()
    {
        MatchController.Player1ScoreEnum++;

        if (CheckIfBothAre40())
        {
            return "Deuce";
        }

        if (MatchController.Player1ScoreEnum == Score.Win)
        {
            MatchController.Player1SetWins++;
            MatchController.stateOfGame = StateOfGame.Win;
            MatchController.ResetScores();
            return "Player One Wins";
        }

        return $"{MatchController.Player1ScoreEnum} - {MatchController.Player2ScoreEnum}";
        
    }

    public string GetScoreStringPlayer2()
    {
        MatchController.Player2ScoreEnum++;
        if(CheckIfBothAre40())
        {
            return "Deuce";
        }
        if (MatchController.Player2ScoreEnum == Score.Win)
        {
            MatchController.Player2SetWins++;
            MatchController.stateOfGame = StateOfGame.Win;
            MatchController.ResetScores();
            return "Player Two Wins";
        }

        return $"{MatchController.Player1ScoreEnum} - {MatchController.Player2ScoreEnum}";
        
    }

    private bool CheckIfBothAre40()
    {
        if (MatchController.Player1ScoreEnum == Score.Fourty && MatchController.Player2ScoreEnum == Score.Fourty)
        {
            MatchController.stateOfGame = StateOfGame.Deuce;
            return true;
        }
        return false;
    }
}
