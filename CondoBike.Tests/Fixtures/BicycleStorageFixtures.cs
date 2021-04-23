using System;
using System.Collections.Generic;
using CondoBike.Model;
using Bogus;
using CondoBike.Service;

namespace CondoBike.Tests.Fixtures
{
    public class BicycleStorageFixtures
    {
        BicycleFixtures bicycleFixtures = new BicycleFixtures();
        BicycleIdentificator bicycleIdentificator = new BicycleIdentificator();
        public BicycleStorage GetRandomBicyleStorageWithoutBicycles()
        {
            var randomBicyleStorage = new Faker<BicycleStorage>()
                .RuleFor(bs => bs.BicycleStorageID, set => set.Random.Number(30000,40000))
                .RuleFor(bs => bs.BicycleStorageCapacity, set => set.Random.Number(30,100))
                .RuleFor(bs => bs.BicycleStorageDescription, set => set.Company.CompanyName())
                .Generate();
            return randomBicyleStorage;
        }

        public BicycleStorage GetCorrectBicycleStorageFully()
        {
            var randomBicyleStorage = new Faker<BicycleStorage>()
               .RuleFor(bs => bs.BicycleStorageID, set => set.Random.Number(30000, 40000))
               .RuleFor(bs => bs.BicycleStorageCapacity, set => set.Random.Number(30, 100))
               .RuleFor(bs => bs.Bicycles, (set,bs) => bicycleFixtures.GetCorrectBicycleForStorage(bs,bs.BicycleStorageCapacity))
               .RuleFor(bs => bs.BicycleStorageDescription, set => set.Company.CompanyName())
               .Generate();
            
            foreach (var b in randomBicyleStorage.Bicycles)
                bicycleIdentificator.GenerateIdentification(b);


            return randomBicyleStorage;
        }

    }
}