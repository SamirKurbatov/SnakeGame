using SnakeGame.Models;

namespace SnakeGame;

public class SnakeCreatorByConsole : ICreate<Snake>
{
    public Snake Create()
    {
        var bodyColor = GetSnakeColor();
        var headColor = GetSnakeColor();
        Console.Write("Введите начальную позицию X змеи: ");
        var initialX = int.Parse(Console.ReadLine());
        Console.Write("Введите конечную позицию Y: ");
        var initialY = int.Parse(Console.ReadLine());
        Console.Write("Введите длину змеи: ");
        var bodyLenght = int.Parse(Console.ReadLine());
        return new Snake(initialX, initialY, headColor, bodyColor, bodyLenght);
    }

    private ConsoleColor GetSnakeColor()
    {
        var random = new Random();
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor?)consoleColors.GetValue(random.Next(consoleColors.Length)) ?? ConsoleColor.White;
    }
}