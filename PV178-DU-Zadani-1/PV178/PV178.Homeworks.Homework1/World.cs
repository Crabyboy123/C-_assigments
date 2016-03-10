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

        World(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentException("Width is invalid");
            if (height <= 0)
                throw new ArgumentException("Height is invalid");

            this.width = width;
            this.height = height;
            this.freeTiles = width * height;
            this.map = new Dictionary<ICoordinates, IBuilding>;

        }

        int Width
        {
            get
            {
                return width;
            }
        }

        int Height
        {
            get
            {
                return height;
            }
        }

        int FreeTiles
        {
            get
            {
                return freeTiles;
            }
        }

        ICoordinates GetBuildingLocation(IBuilding building)
        {
            if (building == null)
                throw new ArgumentNullException("Building is null");

            ICoordinates result = null;
            result = map.FirstOrDefault(x => x.Value == building).Key;
            if (result == null)
                throw new InvalidOperationException("Building is not in map");

            return result;
        }

        IBuilding GetBuildingAt(ICoordinates coordinates)
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

        void Build(ICoordinates coordinates, IBuilding building)
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
            freeTiles--;
        }

        decimal CalculateLandTax()
        {

        }

    }


}
