namespace MyGuitarShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Entity class Guitar.
    /// </summary>
    [Table("Guitars")]
    public class Guitar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Guitar"/> class.
        /// </summary>
        public Guitar()
        {
            this.GuitarAmps = new HashSet<GuitarAmp>();
            this.GuitarAccessories = new HashSet<GuitarAccessory>();
        }

        /// <summary>
        /// Gets or sets the Id of an Guitar entity.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GuitarId { get; set; }

        /// <summary>
        /// Gets or sets the brand of an Guitar entity.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the modell of an Guitar entity.
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string Modell { get; set; }

        /// <summary>
        /// Gets or sets the category of an Guitar entity.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the type of an Guitar entity.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the price of an Guitar entity.
        /// </summary>
        [Required]
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the number of frets of an Guitar entity.
        /// </summary>
        public int? FretNumber { get; set; }

        /// <summary>
        /// Gets a formatted string of a Guitar entity.
        /// </summary>
        [NotMapped]
        public string MainData => $"[{this.GuitarId}] : Brand: {this.Brand} Modell: {this.Modell} - Category: {this.Category} - Type: {this.Type} - Price: {this.Price}";

        /// <summary>
        /// Gets or sets a collection of GuitarAmps.
        /// </summary>
        [NotMapped]
        public virtual ICollection<GuitarAmp> GuitarAmps { get; set; }

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
            if (obj is Guitar)
            {
                Guitar other = obj as Guitar;
                return this.GuitarId == other.GuitarId &&
                    this.Brand == other.Brand &&
                    this.Modell == other.Modell &&
                    this.Category == other.Category &&
                    this.Type == other.Type &&
                    this.Price == other.Price &&
                    this.FretNumber == other.FretNumber;
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
            return this.GuitarId.GetHashCode() + this.Brand.GetHashCode(StringComparison.Ordinal) + this.Modell.GetHashCode(StringComparison.Ordinal) + this.Category.GetHashCode(StringComparison.Ordinal) + this.Type.GetHashCode(StringComparison.Ordinal) + this.Price.GetHashCode() + this.FretNumber.GetHashCode();
        }
    }
}
