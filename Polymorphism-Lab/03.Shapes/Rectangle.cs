using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get => height; private set => height = value; }
        public double Width { get => width; private set => width = value; }

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
           return 2 * (Height + Width);
        }

        public override string Draw()
        {
            return $"Drawing {GetType().Name}";
        }
    }
}
