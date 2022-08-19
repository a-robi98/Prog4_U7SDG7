namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class is used when a GetPriceForGuitarAmpCombos() method returns a list.
    /// </summary>
    public class GuitarAmpComboPrice
    {
        /// <summary>
        /// Gets or sets GuitarAmpCombos to this GuitarAmpComboPrice instance.
        /// </summary>
        public GuitarAmpCombos GuitarAmpCombosData { get; set; }

        /// <summary>
        /// Gets or sets the GuitarAmp combos's Price.
        /// </summary>
        public int GuitarAmpPrice { get; set; }

        /// <summary>
        /// Gets a formatted string of a GuitarAmpComboPrice instance.
        /// </summary>
        /// <returns>A string which contains the properties of a GuitarAmpComboPrice instance.</returns>
        public override string ToString()
        {
            return $"{this.GuitarAmpCombosData.ToString()} --- GUITAR/AMP PRICE: {this.GuitarAmpPrice} ";
        }

        /// <summary>
        /// Decides that the given object is identical to this instance.
        /// </summary>
        /// <param name="obj">Type object which we want to liken to this instance.</param>
        /// <returns>A 0 if the two object isn't equal, a 1 if the two object is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is GuitarAmpComboPrice)
            {
                GuitarAmpComboPrice other = obj as GuitarAmpComboPrice;
                return this.GuitarAmpCombosData.Equals(other.GuitarAmpCombosData) && this.GuitarAmpPrice.Equals(other.GuitarAmpPrice);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the hashcode of this instance.
        /// </summary>
        /// <returns>An unique to this instance int.</returns>
        public override int GetHashCode()
        {
            return this.GuitarAmpCombosData.GetHashCode() + this.GuitarAmpPrice.GetHashCode();
        }
    }
}
