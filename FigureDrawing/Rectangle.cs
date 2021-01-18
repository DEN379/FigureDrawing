using System.Linq;

namespace FigureDrawing
{
    class Rectangle : Figure
    {
        public Rectangle(Scene scene, int width)
        {
            if (scene.Figures.Count == 0) Id = 0;
            else
                Id = scene.Figures.Select(n => n.Id).Max() + 1;
            Draw(width);
        }
        public override char[,] Draw(int width)
        {
            char[,] rectangle = new char[width, width];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    rectangle[i, j] = (char)(Id + '0');
                }
            }
            Shape = rectangle;
            return rectangle;
        }

        public void setID()
        {
            
        }
    }
}
