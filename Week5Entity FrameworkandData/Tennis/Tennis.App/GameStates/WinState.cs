namespace Tennis.App.GameStates;

public class WinState : IScore
{
    public string GetScoreStringPlayer1()
    {
        MatchController.stateOfGame = StateOfGame.Normal;
        return "Player One has won the game!";
    }

    public string GetScoreStringPlayer2()
    {
        MatchController.stateOfGame = StateOfGame.Normal;
        return "Player Two has won the game!";
    }
}
