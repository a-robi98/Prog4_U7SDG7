namespace MyGuitarShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Entity class Amp.
    /// </summary>
    [Table("Amps")]
    public class Amp
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Amp"/> class.
        /// </summary>
        public Amp()
        {
            this.GuitarAmps = new HashSet<GuitarAmp>();
        }

        /// <summary>
        /// Gets or sets the Id of an Amp entity.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AmpId { get; set; }

        /// <summary>
        /// Gets or sets the brand of an Amp entity.
        /// </summary>
        [Required]
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the modell of an Amp entity.
        /// </summary>
        [Required]
        public string Modell { get; set; }

        /// <summary>
        /// Gets or sets the power of an Amp entity.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Gets or sets the type of an Amp entity.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the price of an Amp entity.
        /// </summary>
        [Required]
        public int Price { get; set; }

        /// <summary>
        /// Gets a formatted string of an Amp entity.
        /// </summary>
        [NotMapped]
        public string MainData => $"[{this.AmpId}] : Brand: {this.Brand} Modell: {this.Modell} - Power: {this.Power} - Type: {this.Type} - Price: {this.Price}";

        /// <summary>
        ///  Gets or sets a collection of GuitarAmps.
        /// </summary>
        [NotMapped]
        public virtual ICollection<GuitarAmp> GuitarAmps { get; set; }

        /// <summary>
        /// Decides that the given object is identical to this instance.
        /// </summary>
        /// <param name="obj">The object we want to compare to this instance.</param>
        /// <returns>A 0 if the two object isn't equal, a 1 if the two object is equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Amp)
            {
                Amp other = obj as Amp;
                return this.AmpId == other.AmpId &&
                    this.Brand == other.Brand &&
                    this.Modell == other.Modell &&
                    this.Power == other.Power &&
                    this.Type == other.Type &&
                    this.Price == other.Price;
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
            return this.AmpId.GetHashCode() + this.Brand.GetHashCode(StringComparison.Ordinal) + this.Modell.GetHashCode(StringComparison.Ordinal) + this.Power.GetHashCode() + this.Type.GetHashCode(StringComparison.Ordinal) + this.Price.GetHashCode();
        }
    }
}
