//using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json;

namespace FigureDrawing
{
    class Program
    {
        private void RunMainMenu()
        {
            string logo = @"______ _                       ______                    _             
|  ___(_)                      |  _  \                  (_)            
| |_   _  __ _ _   _ _ __ ___  | | | |_ __ __ ___      ___ _ __   __ _ 
|  _| | |/ _` | | | | '__/ _ \ | | | | '__/ _` \ \ /\ / / | '_ \ / _` |
| |   | | (_| | |_| | | |  __/ | |/ /| | | (_| |\ V  V /| | | | | (_| |
\_|   |_|\__, |\__,_|_|  \___| |___/ |_|  \__,_| \_/\_/ |_|_| |_|\__, |
          __/ |                                                   __/ |
         |___/                                                   |___/ 
Created by Denys Sakadel
";
            string[] options = { "Scene Menu", "Open last saved scene", "Exit" };
            Menu menu = new Menu(logo, options);
            int selected = menu.Run();
            switch (selected)
            {
                case 0:
                    Scene scene = new Scene();
                    SceneMenu(scene);
                    break;
                case 1:
                    Scene sceneFromJson = FromJson();
                    SceneMenu(sceneFromJson);
                    break;
                case 2:
                    Exit();
                    break;
            }
            RunMainMenu();
        }
        private void SceneMenu(Scene scene)
        {
            Console.Clear();
            Console.WriteLine(scene.PrintScene());
            string[] options = { "Add figure", "Move figure", "Delete figure", "Order figures by id", "Order figures by square",
                "Save scene to file", "Return to main menu" };
            Menu menu = new Menu(scene, options);
            int selected = menu.Run();

            switch (selected)
            {
                case 0:
                    AddFigure(scene);
                    break;
                case 1:
                    MoveFigure(scene);
                    break;
                case 2:
                    DeleteFigure(scene);
                    break;
                case 3:
                    OrderFiguresById(scene);
                    break;
                case 4:
                    OrderFiguresBySquare(scene);
                    break;
                case 5:
                    ToJson(scene);
                    break;
                case 6:
                    ReturnToMainMenu(scene);
                    break;
            }
        }

        private void AddFigure(Scene scene)
        {
            string[] options = { "Triangle", "Rectangle", "Circle", "Line" };
            Menu menu = new Menu(scene, options);
            int selected = menu.Run();
            int property = 0;
            switch (selected)
            {
                case 0:
                    property = CheckInput();
                    if (property < 1)
                    {
                        Console.WriteLine("Property value can't be < 1");
                        Console.ReadKey(true);
                        break;
                    }
                    if (property > Scene.SCENE_HEIGTH)
                    {
                        Console.WriteLine("Property value can't be > scene hight");
                        Console.ReadKey(true);
                        break;
                    }
                    scene.AddFigure(new Triangle(scene, property));
                    break;
                case 1:
                    property = CheckInput();
                    if (property < 1)
                    {
                        Console.WriteLine("Property value can't be < 1");
                        Console.ReadKey(true);
                        break;
                    }
                    if (property > Scene.SCENE_HEIGTH)
                    {
                        Console.WriteLine("Property value can't be > scene hight");
                        Console.ReadKey(true);
                        break;
                    }
                    scene.AddFigure(new Rectangle(scene, property));
                    break;
                case 2:
                    property = CheckInput();
                    if (property < 2)
                    {
                        Console.WriteLine("Property value can't be < 2");
                        Console.ReadKey(true);
                        break;
                    }
                    if (property > Scene.SCENE_HEIGTH)
                    {
                        Console.WriteLine("Property value can't be > scene hight");
                        Console.ReadKey(true);
                        break;
                    }
                    scene.AddFigure(new Circle(scene, property));
                    break;
                case 3:
                    property = CheckInput();
                    if (property < 1)
                    {
                        Console.WriteLine("Property value can't be < 1");
                        Console.ReadKey(true);
                        break;
                    }
                    if (property > Scene.SCENE_WIDTH)
                    {
                        Console.WriteLine("Property value can't be > scene hight");
                        Console.ReadKey(true);
                        break;
                    }
                    scene.AddFigure(new Line(scene, property));
                    break;
            }
            
            SceneMenu(scene);
        }
        private void MoveFigure(Scene scene)
        {
            Console.WriteLine("Enter id of figure to start move =>");
            int property = CheckInput();
            Figure searchFigure = scene.GetFigureById(property);
            if (searchFigure == null)
            {
                Console.WriteLine("Figure with this id didn't exist!");
                Console.ReadKey(true);
                SceneMenu(scene);
                return;
            }
            Console.WriteLine("You can move figure by arrows");
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine(scene.PrintScene());
                ConsoleKeyInfo info = Console.ReadKey(true);
                key = info.Key;
                
                if (key == ConsoleKey.UpArrow)
                {
                    scene.MoveFigureUp(searchFigure);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    scene.MoveFigureDown(searchFigure);
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    scene.MoveFigureLeft(searchFigure);
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    scene.MoveFigureRight(searchFigure);
                }

            } while (key != ConsoleKey.Enter);
            scene.OrderFiguresById();
            SceneMenu(scene);
        }
        private void DeleteFigure(Scene scene)
        {
            Console.WriteLine("Enter id of figure to delete =>");
            int property = CheckInput();

            Console.WriteLine("Do you realy want to delete figure? yes or no =>");
            string s = Console.ReadLine();
            if(s.Trim().ToLower().Equals("yes"))
            scene.RemoveFigure(scene.GetFigureById(property));
            SceneMenu(scene);
        }
        private void OrderFiguresById(Scene scene)
        {
            scene.OrderFiguresById();
            SceneMenu(scene);
        }
        private void OrderFiguresBySquare(Scene scene)
        {
            scene.OrderFiguresBySquare();
            SceneMenu(scene);
        }

        private void ReturnToMainMenu(Scene scene)
        {
            Console.WriteLine("Your progress will lost, save the progress before leaving!");
            Console.WriteLine("Do you want realy to return to main menu? yes or no =>");
            string s = Console.ReadLine();
            if (s.Trim().ToLower().Equals("yes")) RunMainMenu();
            else SceneMenu(scene);
        }
        private void Exit()
        {
            Console.WriteLine("Press any key to exit :(");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
        private int CheckInput()
        {
            Console.WriteLine("Enter pls property value");
            int property = 0;
            try
            {
                property = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Enter pls number of property");
            }
            return property;
        }



        static void Main(string[] args)
        {
            Console.SetWindowSize(71, 35);
            Program program = new Program();
            program.RunMainMenu();

        }

        public static void ToJson(Scene scene)
        {
            //var js = JsonConvert.SerializeObject(scene, Formatting.Indented);
            var js = JsonSerializer.Serialize(scene);   //<-- didnt work with char[,] and char[][]
            File.WriteAllText("scene.json", js);
        }
        public static Scene FromJson()
        {
            var jsonString = File.ReadAllText("scene.json");
            var sc = JsonSerializer.Deserialize<Scene>(jsonString);   //<-- didnt work with char[,] and char[][]
            // var sc = JsonConvert.DeserializeObject<Scene>(jsonString);

            sc.scene = new char[Scene.SCENE_HEIGTH][];
            for (int i = 0; i < sc.scene.Length; i++)
            {
                sc.scene[i] = new char[Scene.SCENE_WIDTH];
            }
            sc.DisplayShapes();
            return sc;
        }
    }
}
