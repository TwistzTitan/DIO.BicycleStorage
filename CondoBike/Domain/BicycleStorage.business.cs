using System.Collections.Generic;
using System.Linq;
using CondoBike.Model;
using CondoBike.Service;

namespace CondoBike.Model
{
    public interface VehicleStorage<T>
    {
        bool Store(T item);
        bool Take(T item);

        double StorageOcupation();
        bool CancelFromStorage(int id);
     }

    public partial class BicycleStorage : VehicleStorage<Bicycle>
    {   
        BicycleIdentificator identificator = new BicycleIdentificator();
        public bool CancelFromStorage(int id)
        {
            throw new System.NotImplementedException();
        }

        public double StorageOcupation()
        {
           return (Bicycles.Count()/BicycleStorageCapacity) * 100 ;
        }

        public virtual bool Store(Bicycle item)
        {
            if(item.BicycleOwner != null && BicycleStorageCapacity > Bicycles.Count)
            {
                identificator.GenerateIdentification(item);
                item.BicycleStorage = this;
                item.BicycleStatus = BicycleStatus.Guarded;
                Bicycles.Add(item);
                return true;
            }
            return false;
        }
        public bool Take(Bicycle item)
        {
            if(Bicycles.Contains(item))
            {
                Bicycles.Where(b => b == item).SingleOrDefault().BicycleStatus = BicycleStatus.NotGuarded;
                return true;
            }
            return false;
        }
    }

}