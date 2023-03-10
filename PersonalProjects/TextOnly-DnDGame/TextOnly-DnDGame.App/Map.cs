using TextOnly_DnDGame.App.Entities;
using TextOnly_DnDGame.App.Entities.Player;

namespace TextOnly_DnDGame.App;

public class Map
{
    public int playerX = 0;
    public int playerY = 0;

    Player player = new(name: "Connor",health: 10,attack: 5,armour: 4,speed: 2); 
    Player bat = new(name: "Bat",health: 6,attack: 2,armour: 0,speed: 1); 

    private char[][] _map = new char[][]
    {
        new char[] { 'W', 'W', 'W', 'W', 'W'},
        new char[] { 'W', 'G', ' ', 'B', 'W'},
        new char[] { 'W', ' ', 'W', 'P', 'W'},
        new char[] { 'W', ' ', ' ', ' ', 'W'},
        new char[] { 'W', 'W', 'W', 'W', 'W'},
    };

    public void DrawMap()
    {
        Console.Clear();
        for (int i = 0; i < _map.Length; i++)
        {
            for (int j = 0; j < _map[i].Length; j++)
            {
                Console.Write($"{_map[i][j]} ");
                if (_map[i][j] == 'P')
                {
                    playerY = i;
                    playerX = j;
                }
            }
            Console.Write($"\n");
        }
    }

    public async void CheckMovement(int movementY = 0, int movementX = 0)
    {
        Console.WriteLine($"Checking map cell {playerY + movementY} : {playerX + movementX}");
        Console.WriteLine($"Map cell is {_map[playerY + movementY][playerX + movementX]}");
        switch (_map[playerY + movementY][playerX + movementX])
        {
            case 'W':
                Console.WriteLine("You bumped into a wall, try again");
                break;
            case 'G':
                Console.WriteLine($"Congratulations you've found the goal");
                break;
            case ' ':
                _map[playerY][playerX] = ' ';
                playerY += movementY;
                playerX += movementX;
                _map[playerY][playerX] = 'P';
                DrawMap();
                Console.WriteLine($"You moved one space");
                break;
            case 'B':
                _map[playerY][playerX] = ' ';
                playerY += movementY;
                playerX += movementX;
                _map[playerY][playerX] = 'P';
                Console.WriteLine(StartCombat(player, bat));
                await Task.Delay(3000);
                DrawMap();
                break;
        }
    }

    string StartCombat(Entity player, Entity opponent)
    {
        bool combatActive = true;
            Console.Clear();
        while (combatActive)
        {
            Console.WriteLine($"----- You have encountered a {opponent.Name} -----");
            Console.WriteLine($"{opponent.Name} stats: Health:{opponent.Health}, Attack:{opponent.Attack}, Armour:{opponent.Armour}, Speed:{opponent.Speed}");
            Console.WriteLine($"----- (A)ttack (R)un -----");

            string input = Console.ReadLine()!.ToUpper();

            switch(input.First())
            {
                case 'A':
                    if(player.AttackTarget(opponent) == TargetAlive.Dead)
                    {
                        return $"You Won! The {opponent.Name} is dead!";
                    }
                    break;
                case 'R':
                    Console.WriteLine($"You ran away from {opponent}");
                    break;
            }
        }
        return "";
    }
}
