namespace Tennis.App.GameStates;

public class AdvantageP1 : IScore
{
    public string GetScoreStringPlayer1()
    {
        MatchController.stateOfGame = StateOfGame.Win;
        return "Player One Wins";
    }

    public string GetScoreStringPlayer2()
    {
        MatchController.stateOfGame = StateOfGame.Deuce;
        return "Deuce";
    }
}
