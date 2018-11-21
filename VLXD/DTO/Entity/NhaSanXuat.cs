namespace DTO.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaSanXuat()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        public int MaNSX { get; set; }

        [StringLength(100)]
        public string TenCongTyNSX { get; set; }

        [StringLength(200)]
        public string DiaChiNSX { get; set; }

        [StringLength(50)]
        public string DienThoaiNSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
