using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace FigureDrawing
{
    class Scene
    {
        public static readonly int SCENE_HEIGTH = 20;
        public static readonly int SCENE_WIDTH = 70;

        [JsonProperty("scene")]
        public char[,] scene;
        [JsonProperty("Figures")]
        public List<Figure> Figures { get; set; }
        public Scene()
        {
            Figures = new List<Figure>();
            scene = new char[SCENE_HEIGTH, SCENE_WIDTH];
        }

        public void MoveFigureUp(Figure figure)
        {
            if (figure.Y == 0) return;
            var shape = figure.Shape;
            RemoveFigure(figure);
            DisplayShape(shape, figure.X, --figure.Y );
            Figures.Add(figure);
        }
        public void MoveFigureDown(Figure figure)
        {
            if (figure.Y + figure.Shape.GetLength(0) >= SCENE_HEIGTH) return;
            var shape = figure.Shape;
            RemoveFigure(figure);
            DisplayShape(shape, figure.X,  ++figure.Y);
            Figures.Add(figure);
        }
        public void MoveFigureLeft(Figure figure)
        {
            if (figure.X == 0) return;
            var shape = figure.Shape;
            RemoveFigure(figure);
            DisplayShape(shape, --figure.X , figure.Y);
            Figures.Add(figure);
        }
        public void MoveFigureRight(Figure figure)
        {
            if (figure.X + figure.Shape.GetLength(1) >= SCENE_WIDTH) return;
            var shape = figure.Shape;
            RemoveFigure(figure);
            DisplayShape(shape,  ++figure.X, figure.Y);
            Figures.Add(figure);
        }

        public void AddFigure(Figure figure)
        {
            Figures.Add(figure);
            DisplayShapes();
        }

        public void RemoveFigure(Figure figure)
        {
            Figures.Remove(figure);
            scene = new char[SCENE_HEIGTH, SCENE_WIDTH];
            DisplayShapes();
        }

        public Figure GetFigureById(int id)
        {
            return Figures.FirstOrDefault(n => n.Id == id);
        }

        public void DisplayShapes()
        {
            foreach (Figure f in Figures)
            {
                for (int i = f.Y; i < f.Shape.GetLength(0) + f.Y; i++)
                {
                    for (int j = f.X; j < f.Shape.GetLength(1) + f.X; j++)
                    {
                        if (f.Shape[i - f.Y, j - f.X] != 0 && f.Shape[i - f.Y, j - f.X] != 32)
                        {
                            scene[i, j] = f.Shape[i - f.Y, j - f.X];
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
        public void OrderFiguresById()
        {
            Figures = Figures.OrderBy(n => n.Id).ToList<Figure>();
            scene = new char[SCENE_HEIGTH, SCENE_WIDTH];
            DisplayShapes();
        }
        public void OrderFiguresBySquare()
        {
            Figures = Figures.OrderBy(n => n.Shape.Length).ToList<Figure>();
            scene = new char[SCENE_HEIGTH, SCENE_WIDTH];
            DisplayShapes();
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
