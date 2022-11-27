using SnakeGame.Inerfaces;
using SnakeGame.Models;

namespace SnakeGame;

internal class GameBoardConfigurator : IConfigure<GameBoard>
{
    public void Configure(GameBoard gameBoard)
    {
        Console.CursorVisible = false;
    }
}
