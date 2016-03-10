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
        Coordinates(int left, int top)
        {
            this.left = left;
            this.top = top;
        }
        
        int Left
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

        int Top
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

        public bool IsInRectangle(int top, int left, int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException("Width is in wrong range");

            if (height <= 0) 
                throw new ArgumentOutOfRangeException("Height is in wrong range");

            if ((top + height >= this.top) && (left + width >= this.left))
                return true;
            return false;
        }

        public String toString()
        {
            return String.Format("[{0};{1}]", left, top);
        }
    }

}
