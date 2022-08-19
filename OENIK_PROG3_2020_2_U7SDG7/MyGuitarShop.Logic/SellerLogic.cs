namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyGuitarShop.Data;
    using MyGuitarShop.Repository;

    /// <summary>
    /// Functions that a Seller uses.
    /// </summary>
    public class SellerLogic : ISellerLogic
    {
        private IGuitarRepository guitarRepo;

        private IAmpRepository ampRepo;

        private IAccessoryRepository accRepo;

        private IGuitarAmpRepository guamRepo;

        private IGuitarAccessoryRepository guaccRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="SellerLogic"/> class.
        /// </summary>
        /// <param name="guitarrepo">A RepositoryClass class, which implements IGuitarRepository interface.</param>
        /// <param name="amprepo">A RepositoryClass class, which implements IAmpRepository interface.</param>
        /// <param name="accrepo">A RepositoryClass class, which implements IAccessoryRepository interface.</param>
        /// <param name="guamrepo">A RepositoryClass class, which implements IGuitarAmpRepository interface.</param>
        /// <param name="guaccrepo">A RepositoryClass class, which implements IGuitarAccessoryRepository interface.</param>
        public SellerLogic(IGuitarRepository guitarrepo, IAmpRepository amprepo, IAccessoryRepository accrepo, IGuitarAmpRepository guamrepo, IGuitarAccessoryRepository guaccrepo)
        {
            this.guitarRepo = guitarrepo;
            this.ampRepo = amprepo;
            this.accRepo = accrepo;
            this.guamRepo = guamrepo;
            this.guaccRepo = guaccrepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SellerLogic"/> class with only the main repos.
        /// </summary>
        /// <param name="guitarrepo">A RepositoryClass class, which implements IGuitarRepository interface.</param>
        /// <param name="amprepo">A RepositoryClass class, which implements IAmpRepository interface.</param>
        /// <param name="accrepo">A RepositoryClass class, which implements IAccessoryRepository interface.</param>
        public SellerLogic(IGuitarRepository guitarrepo, IAmpRepository amprepo, IAccessoryRepository accrepo)
        {
            this.guitarRepo = guitarrepo;
            this.ampRepo = amprepo;
            this.accRepo = accrepo;
        }

        /// <summary>
        /// Gets a specific Accessory by given id.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <returns>An Accessory.</returns>
        public Accessory GetAccessoryById(int id)
        {
            return this.accRepo.GetOne(id);
        }

        /// <summary>
        /// Gets all the Accessories.
        /// </summary>
        /// <returns>A list of Accessories.</returns>
        public IList<Accessory> GetAllAccessories()
        {
            return this.accRepo.GetAll().ToList();
        }

        /// <summary>
        /// Gets all the Amps.
        /// </summary>
        /// <returns>A list of Amps.</returns>
        public IList<Amp> GetAllAmps()
        {
            return this.ampRepo.GetAll().ToList();
        }

        /// <summary>
        /// Gets all the Guitars.
        /// </summary>
        /// <returns>A list of Guitars.</returns>
        public IList<Guitar> GetAllGuitars()
        {
            return this.guitarRepo.GetAll().ToList();
        }

        /// <summary>
        /// Gets a specific Amp by given id.
        /// </summary>
        /// <param name="id">Id of the desired Amp.</param>
        /// <returns>An Amp.</returns>
        public Amp GetAmpById(int id)
        {
                return this.ampRepo.GetOne(id);
        }

        /// <summary>
        /// Gets all the Guitar-Amp Combos.
        /// </summary>
        /// <returns>A list of GuitarAmps.</returns>
        public IList<GuitarAmpCombos> GetGuitarAmpCombos()
        {
            var q = from guitar in this.guitarRepo.GetAll()
                    join guitaramp in this.guamRepo.GetAll() on guitar.GuitarId equals guitaramp.GuitarId
                    join amp in this.ampRepo.GetAll() on guitaramp.AmpId equals amp.AmpId
                    select new GuitarAmpCombos()
                    {
                        GuitarId = guitar.GuitarId,
                        GuitarModell = guitar.Modell,
                        GuitarBrand = guitar.Brand,
                        AmpId = amp.AmpId,
                        AmpModell = amp.Modell,
                        AmpBrand = amp.Brand,
                    };
            return q.ToList();
        }

        /// <summary>
        /// Gets all the Guitar-Accessory Combos.
        /// </summary>
        /// <returns>A list of GuitarAccessories.</returns>
        public IList<GuitarAccessoryCombos> GetGuitarAccessoryCombos()
        {
            IList<GuitarAccessoryCombos> guitarAccessoryCombos = new List<GuitarAccessoryCombos>();
            var q = from guitar in this.guitarRepo.GetAll()
                    join guitaracc in this.guaccRepo.GetAll() on guitar.GuitarId equals guitaracc.GuitarId
                    join acc in this.accRepo.GetAll() on guitaracc.AccessoryId equals acc.AccessoryId
                    select new GuitarAccessoryCombos()
                    {
                        GuitarId = guitar.GuitarId,
                        GuitarModell = guitar.Modell,
                        GuitarBrand = guitar.Brand,
                        AccessoryId = acc.AccessoryId,
                        AccessoryModell = acc.Modell,
                        AccessoryBrand = acc.Brand,
                    };
            return q.ToList();
        }

        /// <summary>
        /// Gets a specific Guitar by given id.
        /// </summary>
        /// <param name="id">Id of the desired Guitar.</param>
        /// <returns>A Guitar.</returns>
        public Guitar GetGuitarById(int id)
        {
            return this.guitarRepo.GetOne(id);
        }
    }
}
