using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kald_Geometrical_Shapes
{
   abstract class Shape
    {
        public double Area { get; set; }

        public double Perimeter { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }


        public abstract double GetArea();

        public abstract double GetPerimeter();




    }
}
