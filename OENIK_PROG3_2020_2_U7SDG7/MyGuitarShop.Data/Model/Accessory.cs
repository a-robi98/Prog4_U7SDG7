namespace MyGuitarShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Entity class Accessory.
    /// </summary>
    [Table("Accessories")]
    public class Accessory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Accessory"/> class.
        /// </summary>
        public Accessory()
        {
            this.GuitarAccessories = new HashSet<GuitarAccessory>();
        }

        /// <summary>
        /// Gets or sets the Id of an Accessory entity.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccessoryId { get; set; }

        /// <summary>
        /// Gets or sets the determination of an Accessory entity.
        /// </summary>
        [Required]
        public string Determination { get; set; }

        /// <summary>
        /// Gets or sets the brand of an Accessory entity.
        /// </summary>
        [Required]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the modell of an Accessory entity.
        /// </summary>
        [Required]
        public string Modell { get; set; }

        /// <summary>
        /// Gets or sets the quantity of an Accessory entity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price of an Accessory entity.
        /// </summary>
        [Required]
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the discount price of an Accessory entity.
        /// </summary>
        public int? DiscountPrice { get; set; }

        /// <summary>
        /// Gets a formatted string of an Accessory entity.
        /// </summary>
        [NotMapped]
        public string MainData => $"[{this.AccessoryId}] : Determination: {this.Determination} - Brand : {this.Brand} - Modell: {this.Modell} - Quantity: {this.Quantity} - Price: {this.Price} - DiscountPrice: {this.DiscountPrice}";

        /// <summary>
        /// Gets or sets a collection of GuitarAccessories.
        /// </summary>
        [NotMapped]
        public virtual ICollection<GuitarAccessory> GuitarAccessories { get; set; }

        /// <summary>
        /// Decides that the given object is identical to this instance.
        /// </summary>
        /// <param name="obj">The object we want to compare to this instance.</param>
        /// <returns>A 0 if the two object isn't equal, a 1 if the two object is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Accessory)
            {
                Accessory other = obj as Accessory;
                return this.AccessoryId == other.AccessoryId &&
                    this.Determination == other.Determination &&
                    this.Brand == other.Brand &&
                    this.Modell == other.Modell &&
                    this.Quantity == other.Quantity &&
                    this.Price == other.Price &&
                    this.DiscountPrice == other.DiscountPrice;
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
            return this.AccessoryId.GetHashCode() + this.Determination.GetHashCode(StringComparison.Ordinal) + this.Brand.GetHashCode(StringComparison.Ordinal) + this.Modell.GetHashCode(StringComparison.Ordinal) + this.Quantity.GetHashCode() + this.Price.GetHashCode() + this.DiscountPrice.GetHashCode();
        }
    }
}
