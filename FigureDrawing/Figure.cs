using System;

namespace FigureDrawing
{
    abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        public char[,] Shape { get; protected set; }
        public abstract char[,] Draw(int width);
    }
}
