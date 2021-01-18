using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDrawing
{
    class Scene
    {
        List<Figure> figures;
        char[,] scene;

        public Scene()
        {
            figures = new List<Figure>();
            scene = new char[35, 70];
        }

        public void AddFigure(Figure figure)
        {
            figures.Add(figure);
            DisplayShapes();
        }
        public void RemoveFigure(Figure figure)
        {
            figures.Remove(figure);
            scene = new char[35, 70];
            DisplayShapes();
        }

        public void DisplayShapes()
        {
            foreach (Figure f in figures)
            {
                for (int i = 0; i < f.Shape.GetLength(0); i++)
                {
                    for (int j = 0; j < f.Shape.GetLength(1); j++)
                    {
                        if (f.Shape[i, j] != 0 && f.Shape[i , j] != 32)
                        {
                            scene[i, j] = f.Shape[i , j];
                        }
                    }
                }
            }
        }
        public void DisplayShape(char[,] shape, int X, int Y)
        {
            for (int i = Y; i < shape.GetLength(0) + Y; i++)
            {
                for (int j = X; j < shape.GetLength(1) + X; j++)
                {
                    if (shape[i - Y, j - X] != 0 && shape[i - Y, j - X] != 32)
                    {
                        scene[i, j] = shape[i - Y, j - X];
                    }
                }
            }
            
        }
        public string PrintScene()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < scene.GetLength(0); i++)
            {
                for (int j = 0; j < scene.GetLength(1); j++)
                {
                    sb.Append(scene[i, j]);
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }
        public static string PrintShape(char[,] shape)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                        sb.Append(shape[i, j]);
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}
