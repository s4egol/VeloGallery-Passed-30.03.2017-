namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public int? ExtensionId { get; set; }

        public int? AlbumId { get; set; }

        public bool IsTradable { get; set; }

        public virtual Album Album { get; set; }

        public virtual Extension Extension { get; set; }
    }
}
