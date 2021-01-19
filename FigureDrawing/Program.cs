using Newtonsoft.Json;
using System;
using System.IO;
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
            scene.AddFigure(new Line(scene, 32));
            //Console.WriteLine(scene.PrintScene());

            //scene.MoveFigureDown(scene.GetFigureById(2));
            scene.MoveFigureDown(scene.GetFigureById(1));
            scene.MoveFigureDown(scene.GetFigureById(1));
            scene.MoveFigureDown(scene.GetFigureById(1));

            scene.MoveFigureRight(scene.GetFigureById(0));
            scene.MoveFigureRight(scene.GetFigureById(0));
            
            scene.MoveFigureDown(scene.GetFigureById(3));
            scene.MoveFigureDown(scene.GetFigureById(3));
            scene.MoveFigureDown(scene.GetFigureById(3));
            scene.MoveFigureDown(scene.GetFigureById(3));
            scene.OrderFiguresById();

            Console.WriteLine(scene.PrintScene());
            scene.OrderFiguresBySquare();
            Console.WriteLine(scene.PrintScene());




            //var scene2 = FromJson();


            //scene2.OrderFiguresById();
            //Console.WriteLine(scene2.PrintScene());

            //var removeFigure = scene.Figures.FirstOrDefault(n => n.Id == 1);
            //scene.RemoveFigure(removeFigure);
            //Console.WriteLine(scene.PrintScene());

        }

        public static void ToJson(Scene scene)
        {
            var js = JsonConvert.SerializeObject(scene, Formatting.Indented);
            File.WriteAllText("scene.json", js);
        }
        public static Scene FromJson()
        {
            var jsonString = File.ReadAllText("scene.json");
            return JsonConvert.DeserializeObject<Scene>(jsonString);
        }
    }
}
