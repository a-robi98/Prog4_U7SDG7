namespace MyGuitarShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// Entity class for GuitarAmp junction table.
    /// </summary>
    public class GuitarAmp
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
        /// Gets or sets the Id (Foreign Key) of an Amp entity.
        /// </summary>
        [ForeignKey(nameof(Amp))]
        public int AmpId { get; set; }

        /// <summary>
        /// Gets or sets the related Amp entity.
        /// </summary>
        [NotMapped]
        public virtual Amp Amp { get; set; }
    }
}
