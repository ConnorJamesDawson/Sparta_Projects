using TextOnly_DnDGame.App.Entities.Player;

namespace TextOnly_DnDGame.App;

public class System
{
    bool quit = false;
    Map map = new();
    public void GameLoop()
    {
        Map map = new Map();

        map.DrawMap();
        while (!quit)
        {
            Movement();
        }
    }
    public void Movement()
    {
        Console.WriteLine("----- Please input a cardinal direction to go in (N)orth (E)ast (S)outh (W)est or (Q)uit to leave the prog -----");
        Console.WriteLine($"Player is at {map.playerY} : {map.playerX}");

        string userInput = Console.ReadLine()!.ToUpper();

        if(userInput == "QUIT")
        {
            quit = true;
            return;
        }

        switch (userInput.First()) //(Up PlayerY-=1) (Down - PlayerY+=1) (East - PlayerX +=1) (West PlayerX-=1)
        {
            case 'N':
                map.CheckMovement(movementY: -1);
                break;
            case 'E':
                map.CheckMovement(movementX: 1);
                break;
            case 'S':
                map.CheckMovement(movementY: 1);
                break;
            case 'W':
                map.CheckMovement(movementX: -1);
                break;
        }
    }
}
