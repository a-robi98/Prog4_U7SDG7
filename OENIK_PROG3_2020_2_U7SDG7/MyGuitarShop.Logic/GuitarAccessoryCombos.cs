namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class is used when a GetGuitarAccessoryCombos() method returns a list.
    /// </summary>
    public class GuitarAccessoryCombos
    {
        /// <summary>
        /// Gets or sets the GuitarId of GuitarAccessoryCombos.
        /// </summary>
        public int GuitarId { get; set; }

        /// <summary>
        /// Gets or sets the GuitarBrand of GuitarAccessoryCombos.
        /// </summary>
        public string GuitarBrand { get; set; }

        /// <summary>
        /// Gets or sets the GuitarModell of GuitarAccessoryCombos.
        /// </summary>
        public string GuitarModell { get; set; }

        /// <summary>
        /// Gets or sets the AccessoryId of GuitarAccessoryCombos.
        /// </summary>
        public int AccessoryId { get; set; }

        /// <summary>
        /// Gets or sets the AccessoryBrand of GuitarAccessoryCombos.
        /// </summary>
        public string AccessoryBrand { get; set; }

        /// <summary>
        /// Gets or sets the AccessoryModell of GuitarAccessoryCombos.
        /// </summary>
        public string AccessoryModell { get; set; }

        /// <summary>
        /// Gets a formatted string of a GuitarAccessoryCombo instance.
        /// </summary>
        /// <returns>A string which contains the properties of a GuitarAccessoryCombo instance.</returns>
        public override string ToString()
        {
            return $" [{this.GuitarId}] - GuitarBrand: {this.GuitarBrand} - GuitarModell: {this.GuitarModell} --- [{this.AccessoryId}] - AccessoryBrand: {this.AccessoryBrand} - AccessoryModell: {this.AccessoryModell}";
        }

        /// <summary>
        /// Decides that the given object is identical to this instance.
        /// </summary>
        /// <param name="obj">Type object which we want to liken to this instance.</param>
        /// <returns>A 0 if the two object isn't equal, a 1 if the two object is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is GuitarAccessoryCombos)
            {
                GuitarAccessoryCombos other = obj as GuitarAccessoryCombos;
                return this.GuitarId == other.GuitarId &&
                    this.GuitarBrand == other.GuitarBrand &&
                    this.GuitarModell == other.GuitarModell &&
                    this.AccessoryId == other.AccessoryId &&
                    this.AccessoryModell == other.AccessoryModell &&
                    this.AccessoryBrand == other.AccessoryBrand;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the hashcode of this instance.
        /// </summary>
        /// <returns>An unique int.</returns>
        public override int GetHashCode()
        {
            return this.GuitarId.GetHashCode() + this.GuitarBrand.GetHashCode(StringComparison.Ordinal) + this.GuitarModell.GetHashCode(StringComparison.Ordinal) + this.AccessoryId.GetHashCode() + this.AccessoryModell.GetHashCode(StringComparison.Ordinal) + this.AccessoryBrand.GetHashCode(StringComparison.Ordinal);
        }
    }
}
