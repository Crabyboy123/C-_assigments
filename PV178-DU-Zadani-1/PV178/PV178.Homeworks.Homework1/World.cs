using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework1
{
    class World : IWorld
    {
        private readonly int width;
        private readonly int height;
        private int freeTiles;
        private Dictionary<ICoordinates, IBuilding> map;

        public World(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentException("Width is invalid");
            if (height <= 0)
                throw new ArgumentException("Height is invalid");

            this.width = width;
            this.height = height;
            this.freeTiles = width * height;
            this.map = new Dictionary<ICoordinates, IBuilding>();

        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public int FreeTiles
        {
            get
            {
                return freeTiles;
            }
        }

        public ICoordinates GetBuildingLocation(IBuilding building)
        {
            if (building == null)
                throw new ArgumentNullException("Building is null");

            ICoordinates result = null;
            result = map.FirstOrDefault(x => x.Value == building).Key;
            if (result == null)
                throw new InvalidOperationException("Building is not in map");

            return result;
        }

        public IBuilding GetBuildingAt(ICoordinates coordinates)
        {
            if (coordinates == null)
                throw new ArgumentNullException("Coordinates are null");
            if (!coordinates.IsInRectangle(0, 0, width, height))
                throw new ArgumentOutOfRangeException("Coordinates are out of range");
            IBuilding result = null;
            try
            {
                result = map[coordinates];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
            return result;
        }

        public void Build(ICoordinates coordinates, IBuilding building)
        {
            if (building == null)
                throw new ArgumentNullException("Building is null");
            if (coordinates == null)
                throw new ArgumentNullException("Coordinates are null");
            if (!coordinates.IsInRectangle(0, 0, width, height))
                throw new ArgumentOutOfRangeException("Coordinates are out of range");
            if (map.ContainsValue(building))
                throw new InvalidOperationException("Building is already built");
            if (map.ContainsKey(coordinates))
                throw new InvalidOperationException("Coordinates are used");

            map.Add(coordinates, building);
            building.World = this;
            freeTiles--;
        }

       public decimal CalculateLandTax()
        {
            decimal res_tax = 0;
            foreach(var pair in map)
            {
                res_tax += pair.Value.CalculateLandTax(); 
            }
            return res_tax;
        }

    }


}
