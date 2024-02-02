using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace website_CLB_HTSV.Models
{
    public class HoatDong
    {
        [Key]
        [StringLength(20)]
        public string? MaHoatDong { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Tên Hoạt Động")]
        public string? TenHoatDong { get; set; }


        [DisplayName("Mô Tả")]
        public string? MoTa { get; set; }

        [DisplayName("Thời Gian")]
        public DateTime ThoiGian { get; set; }

        [StringLength(255)]
        [DisplayName("Địa Điểm")]
        public string? DiaDiem { get; set; }

        [DisplayName("Học Kỳ")]
        public int HocKy { get; set; }

        [DisplayName("Năm Học")]
        public int NamHoc { get; set; }

        [StringLength(50)]
        [DisplayName("Trạng Thái")]
        public string? TrangThai { get; set; }


    }
}
