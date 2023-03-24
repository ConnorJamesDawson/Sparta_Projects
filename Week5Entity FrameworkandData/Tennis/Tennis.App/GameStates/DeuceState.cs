namespace Tennis.App.GameStates;

public class DeuceState : IScore
{
    public string GetScoreStringPlayer1()
    {
        MatchController.stateOfGame = StateOfGame.AdvantageP1;
       return "Advantage Player One";
    }

    public string GetScoreStringPlayer2()
    {
        MatchController.stateOfGame = StateOfGame.AdvantageP2;
        return "Advantage Player Two";
    }
}
