using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBoxData
{
    public class Box
    {
		private const string ExMsg = "{0} cannot be zero or negative.";

        private double length;
		private double width;
		private double height;
		public Box(double length, double width, double height)
		{
			Length= length;
			Width= width;
			Height= height;
		}
		public double Height
		{
			get { return height; }
			init 
			{
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExMsg, nameof(Height)));
                }

                height = value; 
			}
		}

		public double Width
        {
			get => width;
			init 
			{
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ExMsg, nameof(Width)));
                }

                width = value; 
			}
		}

		public double Length 
		{
			get => length;
			init 
			{
				if (value <= 0)
				{
					throw new ArgumentException(string.Format(ExMsg, nameof(Length)));
				}

				length = value; 
			}
		}

		public double SurfaceArea() => (2 * Length * Width) + LateralSurfaceArea();
		 
        public double LateralSurfaceArea() => 2 * Length * Height + 2 * Width * Height;

		public double Volume() => Length*Width*Height;





    }
}
