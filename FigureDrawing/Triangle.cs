using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDrawing
{
    class Triangle : Figure
    {
        public override char[,] Draw(int width)
        {
            char[,] triangle = new char[width, width + 1];
            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j < i + 1; j++)
                    triangle[i - 1, j] = (char)(Id+'0');
                //Console.Write("*");
                //triangle[i - 1, 0] = '\n';
                //Console.WriteLine( "\n" ); 
            }
            Shape = triangle;
            return triangle;
        }
    }
}
