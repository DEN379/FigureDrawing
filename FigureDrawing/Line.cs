using System;
using System.Linq;

namespace FigureDrawing
{
    class Line : Figure
    {
        public Line(Scene scene, int width)
        {
            if (scene.Figures.Count == 0) Id = 0;
            else
                Id = scene.Figures.Select(n => n.Id).Max() + 1;
            X = 0;
            Y = 0;
            Draw(width);
        }
        public override char[][] Draw(int width)
        {
            char[][] line = new char[1][];
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = new char[width];
            }
            for (int i = 0; i < width; i++)
            {
                line[0][i] = (char)(Id + '0');
                
            }
            Shape = line;
            return line;
        }
    }
}
