using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kald_Geometrical_Shapes
{
    class Square : Shape
    {

        public Square (double width)
        {
            Width = width;
            Height = width;
            GetArea();
            GetPerimeter();
        }

        public override double GetArea()
        {
            return Area = 4 * Width;
            
        }

        public override double GetPerimeter()
        {
            return Perimeter = Width * Width;
            
        }

        public override string ToString()
        {
            return $"Length: {Width} Area: {Area}, Perimeter: {Perimeter}";
        }
    }
}
