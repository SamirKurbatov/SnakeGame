using Zmeika2;

namespace ConsoleApp1;

public sealed class GameBoard
{
    private static GameBoard _initalize;

    private const int BoardWidth = 30;
    private const int BoardHeight = 20;
    private const ConsoleColor BorderColor = ConsoleColor.Gray;

    private const int ScreenWidth = BoardWidth * 3;
    private const int ScreenHeight = BoardHeight * 3;

    public int GetBoardWidth()
    {
        return BoardWidth;
    }

    public int GetBoardHeight()
    {
        return BoardHeight;
    }

    public int GetScreenWidth()
    {
        return ScreenWidth;
    }

    public int GetScreenHeight()
    {
        return ScreenHeight;
    }

    public static void ConfigureBoard()
    {
        Console.SetWindowSize(ScreenWidth, ScreenHeight);
        Console.SetBufferSize(ScreenWidth, ScreenHeight);
        Console.CursorVisible = false;
    }

    public void DrawBoard()
    {
        for (int i = 0; i < BoardWidth; i++)
        {
            new Pixel(i, 0, BorderColor).Draw();
            new Pixel(i, BoardHeight - 1, BorderColor).Draw();
        }

        for (int i = 0; i < BoardHeight; i++)
        {
            new Pixel(0, i, BorderColor).Draw();
            new Pixel(BoardWidth - 1, i, BorderColor).Draw();
        }
    }

    public static GameBoard Initialize()
    {
        if (_initalize == null)
        {
            return new GameBoard();
        }
        return _initalize;
    }
}
