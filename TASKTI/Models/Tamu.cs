namespace TASKTI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tamu")]
    public partial class Tamu
    {
        [Key]
        public int Id_Tamu { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName ("Nama Lengkap")]
        public string Nama_Tamu { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Alamat { get; set; }

        [Required]
        [DisplayName("Ucapan Selamat")]
        [DataType(DataType.MultilineText)]
        public string Ucapan_Selamat { get; set; }
    }
}
