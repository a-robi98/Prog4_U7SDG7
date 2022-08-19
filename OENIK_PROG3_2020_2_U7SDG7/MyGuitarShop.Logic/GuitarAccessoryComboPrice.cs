namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class is used when a GetPriceForGuitarAccessoryCombos() method returns a list.
    /// </summary>
    public class GuitarAccessoryComboPrice
    {
        /// <summary>
        /// Gets or sets GuitarAccessoryCombos to this GuitarAccessoryComboPrice instance.
        /// </summary>
        public GuitarAccessoryCombos GuitarAccessoryCombosData { get; set; }

        /// <summary>
        /// Gets or sets the GuitarAccessory combos's Price.
        /// </summary>
        public int GuitarAccessoryPrice { get; set; }

        /// <summary>
        /// Gets a formatted string of a GuitarAccesoryComboPrice instance.
        /// </summary>
        /// <returns>A string which contains the properties of a GuitarAccessoryComboPrice instance.</returns>
        public override string ToString()
        {
            return $"{this.GuitarAccessoryCombosData.ToString()} --- GUITAR/AMP PRICE: {this.GuitarAccessoryPrice} ";
        }

        /// <summary>
        /// Decides that the given object is identical to this instance.
        /// </summary>
        /// <param name="obj">Type object which we want to liken to this instance.</param>
        /// <returns>A 0 if the two object isn't equal, a 1 if the two object is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is GuitarAccessoryComboPrice)
            {
                GuitarAccessoryComboPrice other = obj as GuitarAccessoryComboPrice;
                return this.GuitarAccessoryCombosData.Equals(other.GuitarAccessoryCombosData) && this.GuitarAccessoryPrice.Equals(other.GuitarAccessoryPrice);
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
            return this.GuitarAccessoryCombosData.GetHashCode() + this.GuitarAccessoryPrice.GetHashCode();
        }
    }
}
