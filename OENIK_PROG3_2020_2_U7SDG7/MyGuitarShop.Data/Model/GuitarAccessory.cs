namespace MyGuitarShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Entity class for GuitarAccessory junction table.
    /// </summary>
    public class GuitarAccessory
    {
        /// <summary>
        /// Gets or sets the Id (Foreign Key) of a Guitar entity.
        /// </summary>
        [ForeignKey(nameof(Guitar))]
        public int GuitarId { get; set; }

        /// <summary>
        /// Gets or sets the related Guitar entity.
        /// </summary>
        [NotMapped]
        public virtual Guitar Guitar { get; set; }

        /// <summary>
        /// Gets or sets the Id (Foreign Key) of an Accessory entity.
        /// </summary>
        [ForeignKey(nameof(Accessory))]
        public int AccessoryId { get; set; }

        /// <summary>
        /// Gets or sets the related Accessory entity.
        /// </summary>
        [NotMapped]
        public virtual Accessory Accessory { get; set; }

        /// <summary>
        /// Gets a formatted string of a GuitarAccessory entity.
        /// </summary>
        [NotMapped]
        public string MainData => $"[{this.GuitarId}]: {this.Guitar.GuitarId} -- [{this.AccessoryId}]: {this.Accessory.AccessoryId}";
    }
}
