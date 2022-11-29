using SnakeGame.Inerfaces;
using SnakeGame.Models;

namespace SnakeGame;

public class GameBoardDrawer : IDrawble<GameBoard>
{
    public void Clear(GameBoard abstraction, PixelDrawer abstractionDrawer)
    {
        Console.Clear();
    }

    public void Draw(GameBoard gameBoard, PixelDrawer pixelDrawer)
    {
        for (int i = 0; i < gameBoard.BoardWidth; i++)
        {
            pixelDrawer.Draw(new Pixel(i, 0, gameBoard.BorderColor));
        }

        for (int i = 0; i < gameBoard.BoardHeight - 1; i++)
        {
            pixelDrawer.Draw(new Pixel(0, i, gameBoard.BorderColor));
            pixelDrawer.Draw(new Pixel(gameBoard.BoardWidth - 1, i, gameBoard.BorderColor));
        }
    }
}

