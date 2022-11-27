using System;
using System.Drawing;
using System.Xml.Linq;
using SnakeGame.Inerfaces;

namespace SnakeGame;

public abstract class BaseDrawer<T, K> : IDrawble<T, K>
{
    public abstract void Draw(T firstValue, K secondValue);
}


