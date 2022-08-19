// <copyright file="ProgramClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyGuitarShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using ConsoleTools;
    using MyGuitarShop.Data;
    using MyGuitarShop.Logic;
    using MyGuitarShop.Repository;

    /// <summary>
    /// Program layer ProgramClass class.
    /// </summary>
    public static class ProgramClass
    {
        /// <summary>
        /// Main method, where everything gets initialized.
        /// </summary>
        public static void Main()
        {
            GuitarContext ctx = new GuitarContext();
            GuitarRepository grepo = new GuitarRepository(ctx);
            AmpRepository amprepo = new AmpRepository(ctx);
            AccessoryRepository accrepo = new AccessoryRepository(ctx);
            GuitarAmpRepository guamrepo = new GuitarAmpRepository(ctx);
            GuitarAccessoryRepository guaccrepo = new GuitarAccessoryRepository(ctx);
            SellerLogic sellerLogic = new SellerLogic(grepo, amprepo, accrepo, guamrepo, guaccrepo);
            ProcurementLogic procLogic = new ProcurementLogic(grepo, amprepo, accrepo);
            ManagementLogic managementLogic = new ManagementLogic(grepo, amprepo, accrepo, guamrepo, guaccrepo);

            var menu = new ConsoleMenu()
                .Add(">> LIST All", () => ListAll(sellerLogic))
                .Add(">> GET BY ID", () => GetById(sellerLogic))
                .Add(">> UPDATE DATA", () => UpdateData(procLogic, sellerLogic))
                .Add(">> INSERT DATA", () => CreateData(procLogic, sellerLogic))
                .Add(">> REMOVE DATA", () => RemoveData(managementLogic, sellerLogic))
                .Add(">> LIST GUITAR/AMP COMBOS", () => ListGuitarAmpCombos(sellerLogic))
                .Add(">> LIST GUITAR/ACCESSORY COMBOS", () => ListGuitarAccessoryCombos(sellerLogic))
                .Add(">> GET GUITAR/AMP COMBO PRICES", () => GetGuitarAmpComboPrices(managementLogic))
                .Add(">> GET GUITAR/AMP COMBO PRICES [ASYNC]", () => GetGuitarAmpComboPricesAsync(managementLogic))
                .Add(">> GET GUITAR/ACCESSORY COMBO PRICES", () => GetGuitarAccessoryComboPrices(managementLogic))
                .Add(">> GET GUITAR/ACCESSORY COMBO PRICES [ASYNC]", () => GetGuitarAccessoryComboPricesAsync(managementLogic))
                .Add(">> GET GUITAR/ACCESSORY COUNT", () => GetGuitarAccessoryCount(managementLogic))
                .Add(">> GET GUITAR/ACCESSORY COUNT [ASYNC]", () => GetGuitarAccessoryCountAsync(managementLogic))
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();
            ctx.Dispose();
        }

        private static void ListAll(SellerLogic logic)
        {
            Console.WriteLine("WHICH TABLE: ");

            string table = Console.ReadLine().ToLower(CultureInfo.CurrentCulture);

            Console.WriteLine();

            if (table == "guitar" || table == "guitars")
            {
                Console.WriteLine("\n ALL GUITARS \n");
                logic.GetAllGuitars()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.MainData));
            }
            else if (table == "amp" || table == "amps")
            {
                Console.WriteLine("\n ALL AMPS \n");
                logic.GetAllAmps()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.MainData));
            }
            else if (table == "accessory" || table == "accessories")
            {
                Console.WriteLine("\n ALL ACCESSORIES \n");
                logic.GetAllAccessories()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.MainData));
            }

            Console.ReadLine();
        }

        private static void GetById(SellerLogic sellerLogic)
        {
            try
            {
                Console.WriteLine("\n GET BY ID \n");
                Console.WriteLine("WHICH TABLE: ");
                string table = Console.ReadLine().ToLower(CultureInfo.CurrentCulture);
                Console.WriteLine("ID: ");
                int id = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);

                if (table == "guitar" || table == "guitars")
                {
                    Console.WriteLine("\n SEARCHED GUITAR: \n");
                    var guitar = sellerLogic.GetGuitarById(id);
                    Console.WriteLine(guitar.MainData);
                }
                else if (table == "amp" || table == "amps")
                {
                    Console.WriteLine("\n SEARCHED AMP: \n");
                    var amp = sellerLogic.GetAmpById(id);
                    Console.WriteLine(amp.MainData);
                }
                else if (table == "accessory" || table == "accessories")
                {
                    Console.WriteLine("\n SEARCHED ACCESSORY: \n");
                    var acc = sellerLogic.GetAccessoryById(id);
                    Console.WriteLine(acc.MainData);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("PLEASE, GIVE A VALID ID!");
            }
            catch (FormatException)
            {
                Console.WriteLine("PLEASE, IF PROGRAM ASKS FOR STRING ENTER STRING, IF ASKS FOR NUMBER ENTER NUMBER!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("PLEASE, CHECK THE NUMBER YOU ENTERED! IT MAY BE TOO LARGE!");
            }

            Console.ReadLine();
        }

        private static void UpdateData(ProcurementLogic procLogic, SellerLogic sellerLogic)
        {
            try
            {
                Console.WriteLine("\n UPDATE DATA \n");

                Console.WriteLine("WHICH TABLE: ");
                string table = Console.ReadLine().ToLower(CultureInfo.CurrentCulture);

                Console.WriteLine("WHICH ID: ");
                var id = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);

                Console.WriteLine("COLUMN NAME: ");
                var columnname = Console.ReadLine().ToLower(CultureInfo.CurrentCulture);

                Console.WriteLine("NEW DATA: ");
                var newData = Console.ReadLine();

                Console.WriteLine();
                if (table == "guitar" || table == "guitars")
                {
                    Console.WriteLine("BEFORE UPDATE: ");
                    var guitarBefore = sellerLogic.GetGuitarById(id);
                    Console.WriteLine(guitarBefore.MainData);
                    switch (columnname)
                    {
                        case "brand":
                            procLogic.ChangeGuitarBrand(id, newData);
                            break;
                        case "modell":
                            procLogic.ChangeGuitarModell(id, newData);
                            break;
                        case "price":
                            procLogic.ChangeGuitarPrice(id, int.Parse(newData, CultureInfo.CurrentCulture));
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("AFTER UPDATE: ");
                    var guitarAfter = sellerLogic.GetGuitarById(id);
                    Console.WriteLine(guitarAfter.MainData);
                }
                else if (table == "amp" || table == "amps")
                {
                    Console.WriteLine("BEFORE UPDATE: ");
                    var ampBefore = sellerLogic.GetAmpById(id);
                    Console.WriteLine(ampBefore.MainData);
                    switch (columnname)
                    {
                        case "brand":
                            procLogic.ChangeAmpBrand(id, newData);
                            break;
                        case "modell":
                            procLogic.ChangeAmpModell(id, newData);
                            break;
                        case "price":
                            procLogic.ChangeAmpPrice(id, int.Parse(newData, CultureInfo.CurrentCulture));
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("AFTER UPDATE: ");
                    var ampAfter = sellerLogic.GetAmpById(id);
                    Console.WriteLine(ampAfter.MainData);
                }
                else if (table == "accessory" || table == "accessories")
                {
                    Console.WriteLine("BEFORE UPDATE: ");
                    var accessoryBefore = sellerLogic.GetAccessoryById(id);
                    Console.WriteLine(accessoryBefore.MainData);
                    switch (columnname)
                    {
                        case "determination":
                            procLogic.ChangeAccessoryDetermination(id, newData);
                            break;
                        case "modell":
                            procLogic.ChangeAccessoryModell(id, newData);
                            break;
                        case "quantity":
                            procLogic.ChangeAccessoryQuantity(id, int.Parse(newData, CultureInfo.CurrentCulture));
                            break;
                        case "price":
                            procLogic.ChangeAccessoryPrice(id, int.Parse(newData, CultureInfo.CurrentCulture));
                            break;
                        case "discountprice":
                            procLogic.ChangeAccessoryDiscountPrice(id, int.Parse(newData, CultureInfo.CurrentCulture));
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine("AFTER UPDATE: ");
                    var accessoryAfter = sellerLogic.GetAccessoryById(id);
                    Console.WriteLine(accessoryAfter.MainData);
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("PLEASE GIVE VALID DATA!");
            }
            catch (FormatException)
            {
                Console.WriteLine("PLEASE, IF PROGRAM ASKS FOR STRING ENTER STRING, IF ASKS FOR NUMBER ENTER NUMBER!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("PLEASE, CHECK THE NUMBER YOU ENTERED! IT MAY BE TOO LARGE!");
            }

            Console.ReadLine();
        }

        private static void CreateData(ProcurementLogic procLogic, SellerLogic sellerLogic)
        {
            try
            {
                Console.WriteLine("WHICH TABLE: ");
                string table = Console.ReadLine().ToLower(CultureInfo.CurrentCulture);

                if (table == "guitar" || table == "guitars")
                {
                    Guitar guitar = new Guitar();
                    Console.WriteLine("BRAND: ");
                    string brand = Console.ReadLine();
                    guitar.Brand = brand;
                    Console.WriteLine("MODELL: ");
                    string modell = Console.ReadLine();
                    guitar.Modell = modell;
                    Console.WriteLine("CATEGORY: ");
                    string cat = Console.ReadLine();
                    guitar.Category = cat;
                    Console.WriteLine("TYPE: ");
                    string type = Console.ReadLine();
                    guitar.Type = type;
                    Console.WriteLine("PRICE: ");
                    int price = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
                    guitar.Price = price;
                    Console.WriteLine("FRET NUMBER: ");
                    int fret = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
                    guitar.FretNumber = fret;

                    procLogic.InsertGuitar(guitar);
                    Console.WriteLine("\n THE GUITAR TABLE AFTER INSERT");
                    sellerLogic.GetAllGuitars()
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.MainData));
                }
                else if (table == "amp" || table == "amps")
                {
                    Amp amp = new Amp();
                    Console.WriteLine("BRAND: ");
                    string brand = Console.ReadLine();
                    amp.Brand = brand;
                    Console.WriteLine("MODELL: ");
                    string modell = Console.ReadLine();
                    amp.Modell = modell;
                    Console.WriteLine("POWER: ");
                    int power = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
                    amp.Power = power;
                    Console.WriteLine("TYPE: ");
                    string type = Console.ReadLine();
                    amp.Type = type;
                    Console.WriteLine("PRICE: ");
                    int price = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
                    amp.Price = price;

                    procLogic.InsertAmp(amp);
                    Console.WriteLine("\n THE AMP TABLE AFTER INSERT");
                    sellerLogic.GetAllAmps()
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.MainData));
                }
                else if (table == "accessory" || table == "accessories")
                {
                    Accessory acc = new Accessory();
                    Console.WriteLine("DETERMINATION: ");
                    string det = Console.ReadLine();
                    acc.Determination = det;
                    Console.WriteLine("BRAND: ");
                    string brand = Console.ReadLine();
                    acc.Brand = brand;
                    Console.WriteLine("MODELL: ");
                    string modell = Console.ReadLine();
                    acc.Modell = modell;
                    Console.WriteLine("QUANTITY: ");
                    int quantity = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
                    acc.Quantity = quantity;
                    Console.WriteLine("PRICE: ");
                    int price = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
                    acc.Price = price;
                    Console.WriteLine("DISCOUNT PRICE: ");
                    int disprice = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
                    acc.DiscountPrice = disprice;

                    procLogic.InsertAccessory(acc);
                    Console.WriteLine("\n THE ACCESSORY TABLE AFTER INSERT");
                    sellerLogic.GetAllAccessories()
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.MainData));
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("PLEASE GIVE VALID DATA!");
            }
            catch (FormatException)
            {
                Console.WriteLine("PLEASE, IF PROGRAM ASKS FOR STRING ENTER STRING, IF ASKS FOR NUMBER ENTER NUMBER!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("PLEASE, CHECK THE NUMBER YOU ENTERED! IT MAY BE TOO LARGE!");
            }

            Console.ReadLine();
        }

        private static void RemoveData(ManagementLogic manLogic, SellerLogic sellerLogic)
        {
            try
            {
                Console.WriteLine("WHICH TABLE: ");
                string table = Console.ReadLine().ToLower(CultureInfo.CurrentCulture);
                Console.WriteLine("WHICH ID: ");
                int id = int.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);

                if (table == "guitar" || table == "guitars")
                {
                    Guitar guitar = sellerLogic.GetGuitarById(id);
                    Console.WriteLine("GUITAR TABLE BEFORE REMOVE: ");
                    sellerLogic.GetAllGuitars()
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.MainData));
                    manLogic.RemoveFromGuitar(guitar);
                    Console.WriteLine();
                    Console.WriteLine("AFTER REMOVE: ");
                    sellerLogic.GetAllGuitars()
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.MainData));
                }
                else if (table == "amp" || table == "amps")
                {
                    Amp amp = sellerLogic.GetAmpById(id);
                    Console.WriteLine("AMP TABLE BEFORE REMOVE: ");
                    sellerLogic.GetAllAmps()
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.MainData));
                    manLogic.RemoveFromAmp(amp);
                    Console.WriteLine();
                    Console.WriteLine("AFTER REMOVE: ");
                    sellerLogic.GetAllAmps()
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.MainData));
                }
                else if (table == "accessory" || table == "accessories")
                {
                    Accessory acc = sellerLogic.GetAccessoryById(id);
                    Console.WriteLine("ACCESSORY TABLE BEFORE REMOVE: ");
                    sellerLogic.GetAllAccessories()
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.MainData));
                    manLogic.RemoveFromAccessory(acc);
                    Console.WriteLine();
                    Console.WriteLine("AFTER REMOVE: ");
                    sellerLogic.GetAllAccessories()
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.MainData));
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("PLEASE, GIVE VALID ID!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("PLEASE, GIVE VALID ID!");
            }
            catch (FormatException)
            {
                Console.WriteLine("PLEASE, IF PROGRAM ASKS FOR STRING ENTER STRING, IF ASKS FOR NUMBER ENTER NUMBER!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("PLEASE, CHECK THE NUMBER YOU ENTERED! IT MAY BE TOO LARGE!");
            }

            Console.ReadLine();
        }

        private static void ListGuitarAmpCombos(SellerLogic sellerLogic)
        {
            Console.WriteLine("\n ALL GUITAR/AMP COMBOS \n");
            sellerLogic.GetGuitarAmpCombos()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void ListGuitarAccessoryCombos(SellerLogic sellerLogic)
        {
            Console.WriteLine("\n ALL GUITAR/ACCESSORY COMBOS \n");
            sellerLogic.GetGuitarAccessoryCombos()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void GetGuitarAmpComboPrices(ManagementLogic manLogic)
        {
            Console.WriteLine("\n ALL GUITAR/AMP COMBO PRICES \n");
            manLogic.GetPriceForGuitarAmpCombos()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void GetGuitarAmpComboPricesAsync(ManagementLogic manLogic)
        {
            Console.WriteLine("\n ALL GUITAR/AMP COMBO PRICES \n");
            Task<IList<GuitarAmpComboPrice>> task = manLogic.GetPriceForGuitarAmpCombosAsync();

            List<GuitarAmpComboPrice> result = task.Result.ToList();
            result.ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        private static void GetGuitarAccessoryComboPrices(ManagementLogic manLogic)
        {
            Console.WriteLine("\n ALL GUITAR/ACCESSORY PRICES \n");
            manLogic.GetPriceForGuitarAccessoryCombos()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void GetGuitarAccessoryComboPricesAsync(ManagementLogic manLogic)
        {
            Console.WriteLine("\n ALL GUITAR/ACCESSORY COMBO PRICES \n");
            Task<IList<GuitarAccessoryComboPrice>> task = manLogic.GetPriceForGuitarAccessoryCombosAsync();

            List<GuitarAccessoryComboPrice> result = task.Result.ToList();
            result.ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        private static void GetGuitarAccessoryCount(ManagementLogic manLogic)
        {
            Console.WriteLine("\n ALL GUITAR/ACCESSORY COUNT \n");
            manLogic.GuitarAccessoryCount()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine();
            Console.ReadLine();
        }

        private static void GetGuitarAccessoryCountAsync(ManagementLogic managementLogic)
        {
            Console.WriteLine("\n ALL GUITAR/ACCESSORY COUNT \n");
            Task<IList<GuitarAccessoryCount>> task = managementLogic.GuitarAccessoryCountAsync();

            List<GuitarAccessoryCount> result = task.Result.ToList();
            result.ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }
    }
}
