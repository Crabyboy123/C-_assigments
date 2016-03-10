using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework1
{
    abstract class BaseBuilding : IBuilding
    {
        private readonly string constructionCompanyName;
        private IWorld world;

        public BaseBuilding(string constructionCompanyName)
        {
            this.constructionCompanyName = constructionCompanyName;
            world = null;
        }

        public string ConstructionCompanyName
        {
            get
            {
                return constructionCompanyName;
            }
        }

        public IWorld World
        {
            get
            {
                return world;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("World is null");
                if (world != null)
                    throw new InvalidOperationException("World is already set");
                world = value;

            }
        }

        abstract public decimal CalculateLandTax();

    }

    class ResidentialBuilding : BaseBuilding
    {
        public ResidentialBuilding(string constructionCompanyName) : base(constructionCompanyName) { 
        }

        public override decimal CalculateLandTax()
        {
            if (World == null)
                throw new InvalidOperationException("Building is not in world");
            ICoordinates coor = World.GetBuildingLocation(this);
            return (decimal)(20 + 1.1 * coor.Top);    
        }

        public override string ToString()
        {
            return String.Format("Residential Building at {0} build by {1} pays {2} FI$", World.GetBuildingLocation(this).ToString(), ConstructionCompanyName, CalculateLandTax());

        }
    }

    class IndustrialBuilding : BaseBuilding
    {
        public IndustrialBuilding(string constructionCompanyName) : base(constructionCompanyName)
        {
        }

        public override decimal CalculateLandTax()
        {
            if (World == null)
                throw new InvalidOperationException("Building is not in world");
            return 31.5m;
        }

        public override string ToString()
        {
            return String.Format("Industrial Building at {0} build by {1} pays {2} FI$", World.GetBuildingLocation(this).ToString(), ConstructionCompanyName, CalculateLandTax());
        }
    }
}
