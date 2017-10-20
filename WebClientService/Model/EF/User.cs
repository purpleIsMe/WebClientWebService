namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Answers = new HashSet<Answer>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name ="Tên người dùng ")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Born { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Chức vụ")]
        public string Position { get; set; }

        [Required]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Điện thoại")]
        public string Mobile { get; set; }

        [StringLength(100)]
        [Display(Name ="Skype")]
        public string Skype { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100,ErrorMessage ="Nhập số điện thoại bạn đăng kí tài khoản zalo (nếu có), ví dụ: +841696893934")]
        [Display(Name = "Zalo")]
        public string Zalo { get; set; }

        [MaxLength(100,ErrorMessage = "Nhập địa chỉ URL đến facebook của bạn (nếu có), ví dụ: https://www.facebook.com/ITTuyetNhiPham")]
        [Display(Name = "Facebook")]
        [DataType(DataType.Url)]
        public byte[] Facebook { get; set; }

        public bool Active { get; set; }

        public int IDPhanQuyen { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Mật khẩu có độ dài ít nhất là 6 kí tự và có chữ cái hoa hoặc kí tự đặc biệt")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Tên đăng nhập")]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Trạng thái hoạt động")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
