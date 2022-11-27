using System;
using System.Drawing;
using System.Xml.Linq;
using SnakeGame.Inerfaces;
using SnakeGame.Interfaces;

namespace SnakeGame;

public abstract class BaseDrawer<T, K> : IDrawble<T, K>
{
    public abstract void Draw(T firstValue, K secondValue);
    public abstract void Clear(T firstValue, K secondValue);    
}


