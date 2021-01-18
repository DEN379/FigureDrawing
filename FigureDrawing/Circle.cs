using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDrawing
{
    class Circle : Figure
    {
        public override char[,] Draw(int radius)
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
            char[][] ch = new char[width * 2][];
            for(int i = 0; i < ch.Length; i++) 
            {
                ch[i] = new char[length * 2];
            }
            int k = 0;
            foreach (string a in arr)
            {
                ch[k] = a.ToCharArray();
                k++;
            }

            char[,] circle = new char[width * 2, length * 2];


            for(int i=0; i<ch.Length; i++)
            {
                for(int j=0;j<ch[i].Length-1; j++)
                {
                    circle[i, j] = ch[i][j];
                }
            }
            Shape = circle;
            return circle;
        }
    }
}
