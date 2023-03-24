namespace Tennis.App.GameStates;

public class AdvantageP2 : IScore
{
    public string GetScoreStringPlayer1()
    {

        MatchController.stateOfGame = StateOfGame.Deuce;
        return "Deuce";
    }

    public string GetScoreStringPlayer2()
    {
        MatchController.stateOfGame = StateOfGame.Win;
        return "Player Two Wins";
    }
}
