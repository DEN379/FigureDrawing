using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDrawing
{
    class Rectangle : Figure
    {
        public override char[,] Draw(int width)
        {
            char[,] rectangle = new char[width, width];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    rectangle[i, j] = (char)(Id + '0');
                }
                //rectangle[i, 0] = '\n';
            }
            Shape = rectangle;
            return rectangle;
        }
    }
}
