namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class is used when a GetGuitarAmpCombos() method returns a list.
    /// </summary>
    public class GuitarAmpCombos
    {
        /// <summary>
        /// Gets or sets the GuitarId of GuitarAmpCombos.
        /// </summary>
        public int GuitarId { get; set; }

        /// <summary>
        /// Gets or sets the GuitarBrand of GuitarAmpCombos.
        /// </summary>
        public string GuitarBrand { get; set; }

        /// <summary>
        /// Gets or sets the GuitarModell of GuitarAmpCombos.
        /// </summary>
        public string GuitarModell { get; set; }

        /// <summary>
        /// Gets or sets the AmpId of GuitarAmpCombos.
        /// </summary>
        public int AmpId { get; set; }

        /// <summary>
        /// Gets or sets the AmpBrand of GuitarAmpCombos.
        /// </summary>
        public string AmpBrand { get; set; }

        /// <summary>
        /// Gets or sets the AmpModell of GuitarAmpCombos.
        /// </summary>
        public string AmpModell { get; set; }

        /// <summary>
        /// Gets a formatted string of a GuitarAmpCombo instance.
        /// </summary>
        /// <returns>A string which contains the properties of a GuitarAmpCombo instance.</returns>
        public override string ToString()
        {
            return $" [{this.GuitarId}] - GuitarBrand: {this.GuitarBrand} - GuitarModell: {this.GuitarModell} --- [{this.AmpId}] - AmpBrand: {this.AmpBrand} - AmpModell: {this.AmpModell}";
        }

        /// <summary>
        /// Decides that the given object is identical to this instance.
        /// </summary>
        /// <param name="obj">Type object which we want to liken to this instance.</param>
        /// <returns>A 0 if the two object isn't equal, a 1 if the two object is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is GuitarAmpCombos)
            {
                GuitarAmpCombos other = obj as GuitarAmpCombos;
                return this.GuitarId == other.GuitarId &&
                    this.GuitarBrand == other.GuitarBrand &&
                    this.GuitarModell == other.GuitarModell &&
                    this.AmpId == other.AmpId &&
                    this.AmpModell == other.AmpModell &&
                    this.AmpBrand == other.AmpBrand;
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
            return this.GuitarId.GetHashCode() + this.GuitarBrand.GetHashCode(StringComparison.Ordinal) + this.GuitarModell.GetHashCode(StringComparison.Ordinal) + this.AmpId.GetHashCode() + this.AmpModell.GetHashCode(StringComparison.Ordinal) + this.AmpBrand.GetHashCode(StringComparison.Ordinal);
        }
    }
}
