﻿using System;
using System.Linq;

namespace FigureDrawing
{
    class Triangle : Figure
    {
        public Triangle(Scene scene, int width)
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
            char[][] triangle = new char[width][];
            for (int i = 0; i < triangle.Length; i++)
            {
                triangle[i] = new char[width + 1];
            }
            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j < i + 1; j++)
                    triangle[i - 1][j] = (char)(Id+'0');
            }
            Shape = triangle;
            return triangle;
        }
    }
}
