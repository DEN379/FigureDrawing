using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDrawing
{
    class Line : Figure
    {
        public override char[,] Draw(int width)
        {
            char[,] line = new char[1, width];
            for(int i = 0; i < width; i++)
            {
                line[0, i] = (char)(Id + '0');
                
            }
            //for (int i = 0; i < width; i++)
            //{
            //    Console.Write(line[0, i]);
            //}
            Shape = line;
            return line;
        }
    }
}
