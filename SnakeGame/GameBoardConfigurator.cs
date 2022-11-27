using SnakeGame.Models;

namespace SnakeGame;

internal class GameBoardConfigurator : BaseConfigurator<GameBoard>
{
    public override void Configure(GameBoard gameBoard)
    {
        Console.CursorVisible = false;
    }
}
