namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class is used when a GuitarAccessouryCount() method returns a list.
    /// </summary>
    public class GuitarAccessoryCount
    {
        /// <summary>
        /// Gets or sets the GuitarName of GuitarAccessoryCount.
        /// </summary>
        public string GuitarName { get; set; }

        /// <summary>
        /// Gets or sets the Accessory of GuitarAccessoryCount.
        /// </summary>
        public int AccessoryCount { get; set; }

        /// <summary>
        /// Decides that the given object is identical to this instance.
        /// </summary>
        /// <param name="obj">Type object which we want to liken to this instance.</param>
        /// <returns>A 0 if the two object isn't equal, a 1 if the two object is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is GuitarAccessoryCount)
            {
                GuitarAccessoryCount other = obj as GuitarAccessoryCount;
                return this.GuitarName == other.GuitarName && this.AccessoryCount == other.AccessoryCount;
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
            return this.GuitarName.GetHashCode(StringComparison.Ordinal) + this.AccessoryCount;
        }

        /// <summary>
        /// Gets a formatted string of a GuitarAccessoryCount instance.
        /// </summary>
        /// <returns>A string which contains the properties of a GuitarAccessoryCount instance.</returns>
        public override string ToString()
        {
            return $"GUITAR BRAND: {this.GuitarName} -- COUNT: {this.AccessoryCount}";
        }
    }
}
