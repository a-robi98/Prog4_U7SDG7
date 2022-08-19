namespace MyGuitarShop.Logic.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using MyGuitarShop.Data;
    using MyGuitarShop.Repository;
    using NUnit.Framework;

    /// <summary>
    /// Has the tests of ProcurementLogic.
    /// </summary>
    [TestFixture]
    public class ProcurementTests
    {
        // ChangeAmpBrand, InsertAccessory -> CRUD -> Verify

        /// <summary>
        /// Mocked Guitar Repository used for tests.
        /// </summary>
        private Mock<IGuitarRepository> mockedGuitarRepo;

        /// <summary>
        /// Mocked Amp Repository used for tests.
        /// </summary>
        private Mock<IAmpRepository> mockedAmpRepo;

        /// <summary>
        /// Mocked Accessory Repository used for tests.
        /// </summary>
        private Mock<IAccessoryRepository> mockedAccessoryRepo;

        /// <summary>
        /// Tests ChangeAmpBrand Procurement Logic method.
        /// </summary>
        [Test]
        public void TestChangeAmpBrand()
        {
            var logic = this.CreateProcurementLogicWithMocks();

            logic.ChangeAmpBrand(3, "Yamaha");

            this.mockedAmpRepo.Verify(repo => repo.ChangeBrand(3, "Yamaha"), Times.Once);
            this.mockedAmpRepo.Verify(repo => repo.ChangeBrand(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
            this.mockedAmpRepo.Verify(repo => repo.ChangeModell(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        /// <summary>
        /// Tests ChangeAmpBrand Procurement Logic method.
        /// </summary>
        [Test]
        public void TestInsertAccessory()
        {
            var logic = this.CreateProcurementLogicWithMocks();

            Accessory acc = new Accessory() { AccessoryId = 1, Determination = "Guitar Strings", Brand = "Ernie Ball", Modell = "EXL 110", Quantity = 1, Price = 3000, DiscountPrice = 2000 };

            logic.InsertAccessory(acc);

            this.mockedAccessoryRepo.Verify(repo => repo.Insert(acc), Times.Once);
            this.mockedAccessoryRepo.Verify(repo => repo.Insert(It.IsAny<Accessory>()), Times.Once);
            this.mockedAccessoryRepo.Verify(repo => repo.ChangeModell(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        private ProcurementLogic CreateProcurementLogicWithMocks()
        {
            this.mockedGuitarRepo = new Mock<IGuitarRepository>();
            this.mockedAmpRepo = new Mock<IAmpRepository>();
            this.mockedAccessoryRepo = new Mock<IAccessoryRepository>();

            List<Guitar> guitars = new List<Guitar>()
            {
                new Guitar() { GuitarId = 1, Brand = "Gibson", Modell = "Les Paul 500", Category = "Electric Guitar", Type = "Les Paul", Price = 200000, FretNumber = 20 },
                new Guitar() { GuitarId = 2, Brand = "Fender", Modell = "American Stratocaster", Category = "Electric Guitar", Type = "Stratocaster", Price = 220000, FretNumber = 18 },
                new Guitar() { GuitarId = 3, Brand = "Fender", Modell = "Deluxe Stratocaster", Category = "Electric Guitar", Type = "Stratocaster", Price = 300000, FretNumber = 20 },
            };
            List<Accessory> acc = new List<Accessory>()
            {
                new Accessory() { AccessoryId = 1, Determination = "Guitar Strings", Brand = "Ernie Ball", Modell = "EXL 110", Quantity = 1, Price = 3000, DiscountPrice = 2000 },
                new Accessory() { AccessoryId = 2, Determination = "Guitar Strings", Brand = "D'Addario", Modell = "EZ-900", Quantity = 1, Price = 2090, DiscountPrice = 1590 },
                new Accessory() { AccessoryId = 3, Determination = "Guitar Strings", Brand = "Rotosound", Modell = "NXA10", Quantity = 1, Price = 8000, DiscountPrice = 7200 },
            };

            this.mockedGuitarRepo.Setup(repo => repo.GetAll()).Returns(guitars.AsQueryable());
            this.mockedAccessoryRepo.Setup(repo => repo.GetAll()).Returns(acc.AsQueryable());
            return new ProcurementLogic(this.mockedGuitarRepo.Object, this.mockedAmpRepo.Object, this.mockedAccessoryRepo.Object);
        }
    }
}
