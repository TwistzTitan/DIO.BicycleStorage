using System.Collections.Generic;


namespace CondoBike.Model
{
    public partial class BicycleStorage
    {
        public int BicycleStorageID {get ; set; }

        public string BicycleStorageDescription {get ; set ;}

        public List<Bicycle> Bicycles { get ; set; } = new List<Bicycle>();

        public int BicycleStorageCapacity {get ; set ; } = 30;
    }
}