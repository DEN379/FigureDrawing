using System;
using System.Linq;
using System.Text;

namespace FigureDrawing
{
    class Circle : Figure
    {
        public Circle(Scene scene, int width)
        {
            if (scene.Figures.Count == 0) Id = 0;
            else
                Id = scene.Figures.Select(n => n.Id).Max() + 1;
            X = 0;
            Y = 0;
            Draw(width);
        }
        public override char[][] Draw(int radius)
        {
            int width = radius;
            int length = (int)(radius * 1.5);
            var sb = new StringBuilder();
            for (int y = width; y >= -width; y -= 2)
            {
                for (int i = -length; i <= length; i++)
                {

                    if ((int)Math.Sqrt(Math.Pow(i, 2) + Math.Pow(y, 2)) == radius) sb.Append(Id);
                    else sb.Append(" ");

                }
                sb.Append("\n");
            }
            string s = sb.ToString();
            string[] arr = s.Split("\n");
            char[][] circle = new char[width * 2][];
            for(int i = 0; i < circle.Length; i++) 
            {
                circle[i] = new char[length * 2];
            }
            int k = 0;
            foreach (string a in arr)
            {
                circle[k] = a.ToCharArray();
                k++;
            }


            char[][] circle2 = new char[width * 2][];
            for (int i = 0; i < circle2.Length; i++)
            {
                circle2[i] = new char[length * 2];
            }

            for (int i = 0; i < circle.Length; i++)
            {
                for (int j = 0; j < circle[i].Length - 1; j++)
                {
                    circle2[i][j] = circle[i][j];
                }
            }
            Shape = circle2;
            return circle2;
        }
    }
}
