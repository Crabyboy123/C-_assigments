using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework1
{
    struct Coordinates : ICoordinates
    {
        public int left, top;
        public Coordinates(int left, int top)
        {
            this.left = left;
            this.top = top;
        }
        
        public int Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        public int Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

        public bool IsInRectangle(int left, int top, int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException("Width is in wrong range");

            if (height <= 0) 
                throw new ArgumentOutOfRangeException("Height is in wrong range");
            return (((Left <= left + width) && (Left >= left)) && ((Top <= top + height) && (Top >= top)));
        }

        public override String ToString()
        {
            return String.Format("[{0};{1}]", Left, Top);
        }
    }

}
