using System;
using CondoBike.Model;
namespace CondoBike.Service
{
    public class BicycleIdentificator
    {
        public void GenerateIdentification(Bicycle b)
        {
            b.BicycleStorageIdentification = "TESTE";
        }
    }
}