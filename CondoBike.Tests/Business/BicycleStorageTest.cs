using NUnit.Framework;
using Moq;
using CondoBike.Model;
using System.Collections.Generic;
using CondoBike.Tests.Fixtures;
using System.Linq;
using CondoBike.Service;

namespace CondoBike.Tests
{
    [TestFixture]
    public class BicycleStorageTest
    {
        
        Mock<BicycleStorage> _mockBicycleStorage;
        BicycleFixtures _bicycleFixture;
        BicycleStorageFixtures _bicycleStorageFixture;
        Bicycle _bicycleTest;
        BicycleStorage _bicycleStorageTest;

        BicycleIdentificator _identificator;

        [SetUp]
        public void SetupMock(){

            _mockBicycleStorage = new Mock<BicycleStorage>();

            _identificator = new BicycleIdentificator();
            
            _bicycleTest = new Bicycle();

            _bicycleStorageTest = new BicycleStorage();

            _bicycleFixture = new BicycleFixtures();

            _bicycleStorageFixture = new BicycleStorageFixtures();

        }
        
        
        [Test]
        public void StoreABike()
        {
            #region  Arrange

            _bicycleTest = _bicycleFixture.GetCorrectBicyclesOutOfStorage(1).FirstOrDefault();

            _bicycleStorageTest = _bicycleStorageFixture.GetRandomBicyleStorageWithoutBicycles();

            var bStorageBicyclesCount = _bicycleStorageTest.Bicycles.Count();
            
            #endregion

            #region Act
            
            var bStored = _bicycleStorageTest.Store(_bicycleTest);
                
            #endregion

            #region Assert

                Assert.IsTrue(bStored);
                Assert.IsTrue(_bicycleTest.HasOwner());
                Assert.IsTrue(_bicycleTest.HasIdentification());
                Assert.Greater(_bicycleStorageTest.Bicycles.Count,bStorageBicyclesCount);
                Assert.GreaterOrEqual(_bicycleStorageTest.BicycleStorageCapacity, _bicycleStorageTest.Bicycles.Count());
                Assert.AreEqual(_bicycleStorageTest.Bicycles.FirstOrDefault(), _bicycleTest);
                Assert.AreEqual(_bicycleTest.BicycleStorage, _bicycleStorageTest);
                
            #endregion
        }
              
        [Test]
        public void NotStoreABikeWithoutOwner()
        {
           #region  Arrange
           
            _bicycleTest = _bicycleFixture.GetBicycleWithoutOwnerOutOfStorage(1).FirstOrDefault();

            _bicycleStorageTest = _bicycleStorageFixture.GetRandomBicyleStorageWithoutBicycles();
           
           #endregion
           
           #region  Act

           var bSCount = _bicycleStorageTest.Bicycles.Count;
            
           var bNotStored = _bicycleStorageTest.Store(_bicycleTest);

           #endregion 
           
           #region  Assert  
           
           Assert.IsFalse(bNotStored);
           Assert.IsFalse(_bicycleTest.HasOwner());
           Assert.IsFalse(_bicycleTest.HasIdentification());
           Assert.AreEqual(_bicycleStorageTest.Bicycles.Count,bSCount);
           
           #endregion 
        }

        [Test]
        public void NotStoreABikeWhenCapacityEnds() 
        {
            
           _bicycleTest = _bicycleFixture.GetBicycleWithoutOwnerOutOfStorage(1).FirstOrDefault();

           _bicycleStorageTest = _bicycleStorageFixture.GetCorrectBicycleStorageFully();
            
           var bSCount = _bicycleStorageTest.Bicycles.Count;

           var bNotStored = _bicycleStorageTest.Store(_bicycleTest);
            
           Assert.IsFalse(bNotStored);
           Assert.AreEqual(_bicycleStorageTest.BicycleStorageCapacity, bSCount);
           Assert.AreEqual(_bicycleStorageTest.Bicycles.Count, bSCount);

        }
    
        [Test]
        public void TakeABike()
        {
            #region  Arrange

            _bicycleStorageTest = _bicycleStorageFixture.GetRandomBicyleStorageWithoutBicycles();
            foreach (var b in  _bicycleFixture.GetCorrectBicycleForStorage(_bicycleStorageTest, numberBicycle: 10)){
                _bicycleStorageTest.Store(b);
            }
            Bicycle bikeToTake = _bicycleStorageTest.Bicycles.FirstOrDefault();
            #endregion

            #region  Act

            var bsCount = _bicycleStorageTest.Bicycles.Count();
            
            var bTook = _bicycleStorageTest.Take(bikeToTake);

            #endregion

            #region Assert

            Assert.IsTrue(bTook);
            Assert.IsTrue(bikeToTake.HasOwner());
            Assert.IsTrue(bikeToTake.HasIdentification());
            Assert.AreEqual(_bicycleStorageTest.Bicycles.Where( b => b.BicycleID == bikeToTake.BicycleID).SingleOrDefault().BicycleStatus, BicycleStatus.NotGuarded);
            Assert.AreEqual(_bicycleStorageTest.Bicycles.Count(), bsCount);
            
            #endregion
            
        }
    }
}