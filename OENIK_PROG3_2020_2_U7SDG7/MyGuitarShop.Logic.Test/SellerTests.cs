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
    /// Has the tests of SellerLogic.
    /// </summary>
    [TestFixture]
    public class SellerTests
    {
        // GetAllGuitars, GetAmpById -> CRUD -> Verify()

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
        /// Tests GetAllGuitars Seller Logic method.
        /// </summary>
        [Test]
        public void TestGetAllGuitars()
        {
            var logic = this.CreateSellerLogicWithMocks();

            var res = logic.GetAllGuitars();

            this.mockedGuitarRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedGuitarRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Tests GetAmpById Seller Logic method.
        /// </summary>
        [Test]
        public void TestGetAmpById()
        {
            var logic = this.CreateSellerLogicWithMocks();

            var res = logic.GetAmpById(2);

            this.mockedAmpRepo.Verify(repo => repo.GetOne(2), Times.Once);
            this.mockedAmpRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Once);
            this.mockedAmpRepo.Verify(repo => repo.GetAll(), Times.Never);
        }

        private SellerLogic CreateSellerLogicWithMocks()
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
            List<Amp> amps = new List<Amp>()
            {
                new Amp() { AmpId = 1, Brand = "Orange", Modell = "CR120C", Power = 120, Type = "Transistor", Price = 244000 },
                new Amp() { AmpId = 2, Brand = "Fender", Modell = "Tone Master Deluxe Reverb", Power = 100, Type = "Tube", Price = 315000 },
                new Amp() { AmpId = 3, Brand = "Boss", Modell = "Katana", Power = 100, Type = "Transistor", Price = 160000 },
            };

            this.mockedGuitarRepo.Setup(repo => repo.GetAll()).Returns(guitars.AsQueryable());
            this.mockedAmpRepo.Setup(repo => repo.GetAll()).Returns(amps.AsQueryable());
            return new SellerLogic(this.mockedGuitarRepo.Object, this.mockedAmpRepo.Object, this.mockedAccessoryRepo.Object);
        }
    }
}
