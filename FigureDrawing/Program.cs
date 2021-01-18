using System;
using System.IO;
using System.Text;

namespace FigureDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Figure drawing, made by Denys Sakadel");

            //Console.SetWindowSize(60, 30);


            Scene scene = new Scene();
            Triangle triangle = new Triangle();
            triangle.Id = 1;
            triangle.Draw(9);
            Rectangle rectangle = new Rectangle();
            rectangle.Id = 2;
            rectangle.Draw(4);
            Circle circle = new Circle();
            circle.Id = 3;
            circle.Draw(14);
            Line line = new Line();
            line.Id = 4;
            line.Draw(6);


            scene.AddFigure(triangle);
            scene.AddFigure(rectangle);
            scene.AddFigure(circle);
            scene.AddFigure(line);
            Console.WriteLine(scene.PrintScene());
            //scene.RemoveFigure(triangle);
            //scene.RemoveFigure(rectangle);
            //Console.WriteLine(scene.PrintScene());



            //for (int i = 0; i < scene.GetLength(0); i++)
            //{
            //    for (int j = 0; j < scene.GetLength(1); j++)
            //    {
            //        Console.Write("{0}", scene[i, j]);
            //    }
            //    Console.WriteLine();
            //}



            //int i = 1;
            //while (i <= 9)
            //{
            //    int k = 9;
            //    int h = 1;

            //    chars[i - 1][h-1] = '\n';
            //    Console.WriteLine("");
            //    int rez = k - i;
            //    for (int j = 0; j < rez; j++)
            //    {
            //        chars[i - 1][h - 1]
            //    }
            //    //while (k > i)
            //    //{
            //    //    chars[i - 1][h - 1]
            //    //    Console.Write(" ");
            //    //    k--;
            //    //}
            //    while (h <= i)
            //    {
            //        Console.Write("11");
            //        h++;
            //    }
            //    i++;
            //}


            //var s = String.Join("", chars[]);

            //using (StreamWriter writer = new StreamWriter("triangle.txt"))
            //{
            //    var s = String.Join("", chars);
            //    writer.Write(s);
            //}
            //using (FileStream fstream = new FileStream($"triangle.txt", FileMode.OpenOrCreate))
            //{
            //    // преобразуем строку в байты
            //    byte[] array = System.Text.Encoding.Default.GetBytes(chars);
            //    // запись массива байтов в файл
            //    fstream.Write(array, 0, array.Length);
            //    Console.WriteLine("Текст записан в файл");
            //}
            //string value = String.Concat<char>(chars);
            //File.AppendAllText("triangle.txt", sb.ToString());

            //for (int i = 0; i < 9; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        Console.Write("{0}", chars[i, j]);
            //    }
            //    //Console.WriteLine();
            //}

            //int NumberOfLines = 5;
            //int count = 1;
            //while (NumberOfLines-- != 0)
            //{
            //    int c = count;
            //    while (c-- != 0)
            //    {

            //        Console.Write("2");
            //    }
            //    Console.WriteLine();
            //    count = count + 2;
            //}
        }
    }
}
