using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace website_CLB_HTSV.Models
{
    public class ThamGiaHoatDong
    {
        [Key]
        [StringLength(20)]
        public string? MaThamGiaHoatDong { get; set; }

        [StringLength(20)]
        public string? MaDangKy { get; set; }

        [DisplayName("Đã Tham Gia")]
        public bool DaThamGia { get; set; }

        [ForeignKey("MaDangKy")]
        [DisplayName("Đăng Ký Hoạt Động")]
        public DangKyHoatDong? DangKyHoatDong { get; set; }
    }
}
