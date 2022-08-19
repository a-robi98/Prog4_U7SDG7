namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MyGuitarShop.Data;
    using MyGuitarShop.Repository;

    /// <summary>
    /// This Logic class is responsible for Management related functions.
    /// </summary>
    public class ManagementLogic : IManagementLogic
    {
        private IGuitarRepository guitarRepo;

        private IAmpRepository ampRepo;

        private IAccessoryRepository accRepo;

        private IGuitarAmpRepository guamRepo;

        private IGuitarAccessoryRepository guaccRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementLogic"/> class.
        /// </summary>
        /// <param name="guitarrepo">A RepositoryClass class, which implements IGuitarRepository interface.</param>
        /// <param name="amprepo">A RepositoryClass class, which implements IAmpRepository interface.</param>
        /// <param name="accrepo">A RepositoryClass class, which implements IAccessoryRepository interface.</param>
        /// <param name="guamrepo">A RepositoryClass class, which implements IGuitarAmpRepository interface.</param>
        /// <param name="guaccrepo">A RepositoryClass class, which implements IGuitarAccessoryRepository interface.</param>
        public ManagementLogic(IGuitarRepository guitarrepo, IAmpRepository amprepo, IAccessoryRepository accrepo, IGuitarAmpRepository guamrepo, IGuitarAccessoryRepository guaccrepo)
        {
            this.guitarRepo = guitarrepo;
            this.ampRepo = amprepo;
            this.accRepo = accrepo;
            this.guamRepo = guamrepo;
            this.guaccRepo = guaccrepo;
        }

        /// <summary>
        /// Gets the prices for the Guitar-Amp Combos.
        /// </summary>
        /// <returns>A list of GuitarAmpComboPrice.</returns>
        public IList<GuitarAmpComboPrice> GetPriceForGuitarAmpCombos()
        {
            var q = from guitar in this.guitarRepo.GetAll()
                    join guitaramp in this.guamRepo.GetAll() on guitar.GuitarId equals guitaramp.GuitarId
                    join amp in this.ampRepo.GetAll() on guitaramp.AmpId equals amp.AmpId
                    select new GuitarAmpComboPrice()
                    {
                        GuitarAmpCombosData = new GuitarAmpCombos()
                        {
                            GuitarId = guitar.GuitarId,
                            GuitarBrand = guitar.Brand,
                            GuitarModell = guitar.Modell,
                            AmpId = amp.AmpId,
                            AmpBrand = amp.Brand,
                            AmpModell = amp.Modell,
                        },
                        GuitarAmpPrice = guitar.Price + amp.Price,
                    };
            return q.ToList();
        }

        /// <summary>
        /// Gives the price for a Guitar Amp Combo but with parallelism.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<IList<GuitarAmpComboPrice>> GetPriceForGuitarAmpCombosAsync()
        {
            return Task.Run(() => this.GetPriceForGuitarAmpCombos());
        }

        /// <summary>
        /// Gets the prices of Guitar-Accessory Combos.
        /// </summary>
        /// <returns>A List with the GuitarAccessoryComboPrice.</returns>
        public IList<GuitarAccessoryComboPrice> GetPriceForGuitarAccessoryCombos()
        {
            var q = from guitar in this.guitarRepo.GetAll()
                    join guitaracc in this.guaccRepo.GetAll() on guitar.GuitarId equals guitaracc.GuitarId
                    join acc in this.accRepo.GetAll() on guitaracc.AccessoryId equals acc.AccessoryId
                    select new GuitarAccessoryComboPrice()
                    {
                        GuitarAccessoryCombosData = new GuitarAccessoryCombos()
                        {
                            GuitarId = guitar.GuitarId,
                            GuitarBrand = guitar.Brand,
                            GuitarModell = guitar.Modell,
                            AccessoryId = acc.AccessoryId,
                            AccessoryBrand = acc.Brand,
                            AccessoryModell = acc.Modell,
                        },
                        GuitarAccessoryPrice = guitar.Price + acc.Price,
                    };
            return q.ToList();
        }

        /// <summary>
        /// Gives the price for a Guitar Amp Combo but with parallelism.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<IList<GuitarAccessoryComboPrice>> GetPriceForGuitarAccessoryCombosAsync()
        {
            return Task.Run(() => this.GetPriceForGuitarAccessoryCombos());
        }

        /// <summary>
        /// Removes a specific Accessory from Accessory table.
        /// </summary>
        /// <param name="acc">The Accessory which we want to remove.</param>
        public void RemoveFromAccessory(Accessory acc)
        {
            this.accRepo.Remove(acc);
        }

        /// <summary>
        /// Removes a specific Amp from Amp table.
        /// </summary>
        /// <param name="amp">The Amp which we want to remove.</param>
        public void RemoveFromAmp(Amp amp)
        {
            this.ampRepo.Remove(amp);
        }

        /// <summary>
        /// Removes a specific Guitar from Guitar table.
        /// </summary>
        /// <param name="guitar">The Guitar which we want to remove.</param>
        public void RemoveFromGuitar(Guitar guitar)
        {
            this.guitarRepo.Remove(guitar);
        }

        /// <summary>
        /// Gives the count of how much Accessories are assigned to a specific Guitar.
        /// </summary>
        /// <returns>A list of GuitarAccessoryCount.</returns>
        public IList<GuitarAccessoryCount> GuitarAccessoryCount()
        {
            var q = from guitar in this.guitarRepo.GetAll()
                    join guitaracc in this.guaccRepo.GetAll() on guitar.GuitarId equals guitaracc.GuitarId
                    join acc in this.accRepo.GetAll() on guitaracc.AccessoryId equals acc.AccessoryId
                    let item = new { GuitarBrand = guitar.Brand, AccCount = acc.AccessoryId }
                    group item.AccCount by item.GuitarBrand into grp
                    select new GuitarAccessoryCount()
                    {
                        GuitarName = grp.Key,
                        AccessoryCount = grp.Count(),
                    };
            return q.ToList();
        }

        /// <summary>
        /// Gives the count of how much Accessories are assigned to a specific Guitar but with parallelism.
        /// </summary>
        /// <returns>A task out of lists out of GuitarAccessoryCount.</returns>
        public Task<IList<GuitarAccessoryCount>> GuitarAccessoryCountAsync()
        {
            return Task.Run(() => this.GuitarAccessoryCount());
        }
    }
}
