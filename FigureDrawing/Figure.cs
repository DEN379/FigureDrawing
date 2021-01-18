using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDrawing
{
    abstract class Figure
    {
        private int x;
        private int y;
        private int id;
        private char[,] shape;
        public int X
        {
            get => x;
            set => x = value;
        }
        public int Y
        {
            get => y;
            set => y = value;
        }
        public int Id
        {
            get => id;
            set => id = value;
        }
        public char[,] Shape
        {
            get => shape;
            set => shape = value;
        }
        public abstract char[,] Draw(int width);
    }
}
