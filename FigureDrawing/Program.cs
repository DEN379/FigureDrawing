using System;
using System.Linq;

namespace FigureDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Figure drawing, made by Denys Sakadel");

            Scene scene = new Scene();
            scene.AddFigure(new Triangle(scene, 9));
            scene.AddFigure(new Rectangle(scene, 4));
            scene.AddFigure(new Circle(scene, 20));
            scene.AddFigure(new Line(scene, 6));
            Console.WriteLine(scene.PrintScene());

            var removeFigure = scene.Figures.FirstOrDefault(n => n.Id == 1);
            scene.RemoveFigure(removeFigure);
            Console.WriteLine(scene.PrintScene());

        }
    }
}
