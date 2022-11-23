namespace SnakeGame.Inerfaces;

interface IBuild<T>
{
    void FirstBuild();
    void SecondBuild();
    T GetResult();
}

/*
 *  public void Clear()
    {

        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                Console.SetCursorPosition(X * Size + x, Y * Size + y);
                Console.Write(' ');
            }
        }
    }
 */
