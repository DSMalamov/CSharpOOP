using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            
            Radius = radius;
        }

        public double Radius { get => radius; set => radius = value; }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * Radius * 2;
        }

        public override string Draw()
        {
            return $"Drawing {GetType().Name}";
        }
    }
}
