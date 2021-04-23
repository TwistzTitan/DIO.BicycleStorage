using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using CondoBike.Model;
using CondoBike.Service;

namespace CondoBike.Tests.Fixtures
{
    public class BicycleFixtures
    {
        
        OwnerFixture _ownerService = new OwnerFixture();
        public List<Bicycle> GetCorrectBicyclesOutOfStorage(int numberBicycle = 1)
        {
            
            var randomBicycles = new Faker<Bicycle>()
                .RuleFor( b => b.BicycleID, set => set.Random.Number(100,300))
                .RuleFor( b => b.BicycleOwner, (set,b) => _ownerService.GetCorrectOwnerForBicycle(b))
                .RuleFor( b => b.BicycleStatus, set => BicycleStatus.NotGuarded)
                .Generate(numberBicycle).ToList();
            
            return randomBicycles;
        }

        public List<Bicycle> GetBicycleWithoutOwnerOutOfStorage(int numberBicycle)
        {
            
            var randomBicyles = new Faker<Bicycle>()
                .RuleFor( b => b.BicycleID, set => set.Random.Number(100,300))
                .RuleFor( b => b.BicycleStatus, set => BicycleStatus.NotGuarded)
                .Generate(numberBicycle).ToList();
            
            return randomBicyles;
            
        }

        public List<Bicycle> GetCorrectBicycleForStorage(BicycleStorage bs,int numberBicycle = 1)
        {

            var randomBicycles = GetCorrectBicyclesOutOfStorage(numberBicycle);
            
            foreach (var b in randomBicycles)
                b.BicycleStorage = bs;
            
            return randomBicycles;

        }



    }
}