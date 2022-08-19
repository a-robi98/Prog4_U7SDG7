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
    /// Has the tests of ManagementLogic.
    /// </summary>
    [TestFixture]
    public class ManagementTests
    {
        // GuitarAccessoryCount, GetPriceForGuitarAmpCombos, GetPriceForGuitarAccessoryCombos, RemoveFromGuitar

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
        /// Mocked Accessory Repository used for tests.
        /// </summary>
        private Mock<IGuitarAmpRepository> mockedGuitarAmpRepo;

        /// <summary>
        /// Mocked Accessory Repository used for tests.
        /// </summary>
        private Mock<IGuitarAccessoryRepository> mockedGuitarAccessoryRepo;

        /// <summary>
        /// Contains the expected GuitarAccessory Combo Prices which is used in TestGetPriceForGuitarAccessoryCombos method.
        /// </summary>
        private List<GuitarAccessoryComboPrice> expectedGuitarAccComboPrices;

        /// <summary>
        /// Contains the expected GuitarAmp Combo Prices which is used in TestGetPriceForGuitarAmpCombos method.
        /// </summary>
        private List<GuitarAmpComboPrice> expectedGuitarAmpComboPrices;

        /// <summary>
        /// Contains the expected GuitarAccessory Counts which is used in TestGuitarAccessoryCount method.
        /// </summary>
        private List<GuitarAccessoryCount> expectedGuitarAccCount;

        /// <summary>
        /// Tests RemoveFromGuitar logic method.
        /// </summary>
        [Test]
        public void TestRemoveFromGuitar()
        {
            var logic = this.CreateManagementLogicWithMocks();

            Guitar guitar = new Guitar() { GuitarId = 1, Brand = "Gibson", Modell = "Les Paul 500", Category = "Electric Guitar", Type = "Les Paul", Price = 200000, FretNumber = 20 };

            logic.RemoveFromGuitar(guitar);

            this.mockedGuitarRepo.Verify(repo => repo.Remove(guitar), Times.Once);
            this.mockedGuitarRepo.Verify(repo => repo.Remove(It.IsAny<Guitar>()), Times.Once);
            this.mockedGuitarRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Tests GuitarAccessoryCount ManagementLogic method.
        /// </summary>
        [Test]
        public void TestGuitarAccessoryCount()
        {
            var logic = this.CreateManagementLogicWithMocks();

            var guitarAccCountResult = logic.GuitarAccessoryCount().ToList();

            Assert.That(guitarAccCountResult, Is.EquivalentTo(this.expectedGuitarAccCount));
            this.mockedGuitarRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedGuitarAccessoryRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedAccessoryRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedAmpRepo.Verify(repo => repo.GetAll(), Times.Never);
            this.mockedGuitarAmpRepo.Verify(repo => repo.GetAll(), Times.Never);
        }

        /// <summary>
        /// Tests GetPriceForGuitarAccessoryCombos ManagementLogic method.
        /// </summary>
        [Test]
        public void TestGetPriceForGuitarAccessoryCombos()
        {
            var logic = this.CreateManagementLogicWithMocks();

            var guitarAccPriceResult = logic.GetPriceForGuitarAccessoryCombos().ToList();

            Assert.That(guitarAccPriceResult, Is.EquivalentTo(this.expectedGuitarAccComboPrices));
            this.mockedGuitarRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedGuitarAccessoryRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedAccessoryRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedAmpRepo.Verify(repo => repo.GetAll(), Times.Never);
            this.mockedGuitarAmpRepo.Verify(repo => repo.GetAll(), Times.Never);
        }

        /// <summary>
        /// Tests GetPriceForGuitarAccessoryCombos ManagementLogic method.
        /// </summary>
        [Test]
        public void TestGetPriceForGuitarAmpCombos()
        {
            var logic = this.CreateManagementLogicWithMocks();

            var guitarAmpPriceResult = logic.GetPriceForGuitarAmpCombos().ToList();

            Assert.That(guitarAmpPriceResult, Is.EquivalentTo(this.expectedGuitarAmpComboPrices));
            this.mockedGuitarRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedGuitarAccessoryRepo.Verify(repo => repo.GetAll(), Times.Never);
            this.mockedAccessoryRepo.Verify(repo => repo.GetAll(), Times.Never);
            this.mockedAmpRepo.Verify(repo => repo.GetAll(), Times.Once);
            this.mockedGuitarAmpRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        private ManagementLogic CreateManagementLogicWithMocks()
        {
            this.mockedGuitarRepo = new Mock<IGuitarRepository>();
            this.mockedAmpRepo = new Mock<IAmpRepository>();
            this.mockedAccessoryRepo = new Mock<IAccessoryRepository>();
            this.mockedGuitarAmpRepo = new Mock<IGuitarAmpRepository>();
            this.mockedGuitarAccessoryRepo = new Mock<IGuitarAccessoryRepository>();

            List<Guitar> guitars = new List<Guitar>()
            {
                new Guitar() { GuitarId = 1, Brand = "Gibson", Modell = "Les Paul 500", Category = "Electric Guitar", Type = "Les Paul", Price = 200000, FretNumber = 20 },
                new Guitar() { GuitarId = 2, Brand = "Fender", Modell = "American Stratocaster", Category = "Electric Guitar", Type = "Stratocaster", Price = 220000, FretNumber = 18 },
            };
            List<Amp> amps = new List<Amp>()
            {
                new Amp() { AmpId = 1, Brand = "Orange", Modell = "CR120C", Power = 120, Type = "Transistor", Price = 244000 },
                new Amp() { AmpId = 2, Brand = "Fender", Modell = "Tone Master Deluxe Reverb", Power = 100, Type = "Tube", Price = 315000 },
            };
            List<Accessory> acc = new List<Accessory>()
            {
                new Accessory() { AccessoryId = 1, Determination = "Guitar Strings", Brand = "Ernie Ball", Modell = "EXL 110", Quantity = 1, Price = 3000, DiscountPrice = 2000 },
                new Accessory() { AccessoryId = 2, Determination = "Guitar Strings", Brand = "D'Addario", Modell = "EZ-900", Quantity = 1, Price = 2090, DiscountPrice = 1590 },
            };
            List<GuitarAmp> guitarAmps = new List<GuitarAmp>()
            {
                new GuitarAmp() { GuitarId = guitars[0].GuitarId, AmpId = amps[0].AmpId },
                new GuitarAmp() { GuitarId = guitars[0].GuitarId, AmpId = amps[1].AmpId },
            };
            List<GuitarAccessory> guitarAccs = new List<GuitarAccessory>()
            {
                new GuitarAccessory() { GuitarId = guitars[0].GuitarId, AccessoryId = acc[0].AccessoryId },
                new GuitarAccessory() { GuitarId = guitars[1].GuitarId, AccessoryId = acc[0].AccessoryId },
            };

            this.expectedGuitarAccCount = new List<GuitarAccessoryCount>()
            {
                new GuitarAccessoryCount() { GuitarName = "Gibson", AccessoryCount = 1 },
                new GuitarAccessoryCount() { GuitarName = "Fender", AccessoryCount = 1 },
            };

            List<GuitarAccessoryCombos> guitarAccCombos = new List<GuitarAccessoryCombos>()
            {
                new GuitarAccessoryCombos() { GuitarId = guitars[0].GuitarId, GuitarBrand = guitars[0].Brand, GuitarModell = guitars[0].Modell, AccessoryId = acc[0].AccessoryId, AccessoryBrand = acc[0].Brand, AccessoryModell = acc[0].Modell },
                new GuitarAccessoryCombos() { GuitarId = guitars[1].GuitarId, GuitarBrand = guitars[1].Brand, GuitarModell = guitars[1].Modell, AccessoryId = acc[0].AccessoryId, AccessoryBrand = acc[0].Brand, AccessoryModell = acc[0].Modell },
            };
            this.expectedGuitarAccComboPrices = new List<GuitarAccessoryComboPrice>()
            {
                new GuitarAccessoryComboPrice() { GuitarAccessoryCombosData = guitarAccCombos[0], GuitarAccessoryPrice = 203000 },
                new GuitarAccessoryComboPrice() { GuitarAccessoryCombosData = guitarAccCombos[1], GuitarAccessoryPrice = 223000 },
            };

            List<GuitarAmpCombos> guitarAmpCombos = new List<GuitarAmpCombos>()
            {
                new GuitarAmpCombos() { GuitarId = guitars[0].GuitarId, GuitarBrand = guitars[0].Brand, GuitarModell = guitars[0].Modell, AmpId = amps[0].AmpId, AmpBrand = amps[0].Brand, AmpModell = amps[0].Modell },
                new GuitarAmpCombos() { GuitarId = guitars[0].GuitarId, GuitarBrand = guitars[0].Brand, GuitarModell = guitars[0].Modell, AmpId = amps[1].AmpId, AmpBrand = amps[1].Brand, AmpModell = amps[1].Modell },
            };
            this.expectedGuitarAmpComboPrices = new List<GuitarAmpComboPrice>()
            {
                new GuitarAmpComboPrice() { GuitarAmpCombosData = guitarAmpCombos[0], GuitarAmpPrice = 444000 },
                new GuitarAmpComboPrice() { GuitarAmpCombosData = guitarAmpCombos[1], GuitarAmpPrice = 515000 },
            };

            this.mockedGuitarRepo.Setup(repo => repo.GetAll()).Returns(guitars.AsQueryable());
            this.mockedAmpRepo.Setup(repo => repo.GetAll()).Returns(amps.AsQueryable());
            this.mockedAccessoryRepo.Setup(repo => repo.GetAll()).Returns(acc.AsQueryable());
            this.mockedGuitarAmpRepo.Setup(repo => repo.GetAll()).Returns(guitarAmps.AsQueryable());
            this.mockedGuitarAccessoryRepo.Setup(repo => repo.GetAll()).Returns(guitarAccs.AsQueryable());
            return new ManagementLogic(this.mockedGuitarRepo.Object, this.mockedAmpRepo.Object, this.mockedAccessoryRepo.Object, this.mockedGuitarAmpRepo.Object, this.mockedGuitarAccessoryRepo.Object);
        }
    }
}
