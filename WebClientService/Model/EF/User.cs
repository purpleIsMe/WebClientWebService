namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

        [Required(ErrorMessage ="Bạn chưa nhập tên của tài khoản")]
        [StringLength(200)]
        [DisplayName("Họ và tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập ngày tháng năm sinh")]
        [DataType(DataType.Date)]
        [DisplayName("Năm sinh")]
        public DateTime Born { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập địa chỉ của tài khoản")]
        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập chức vụ của tài khoản")]
        [StringLength(100)]
        [DisplayName("Chức vụ")]
        public string Position { get; set; }

        [Required(ErrorMessage ="Bạn chưa nhập số điện thoại")]
        [Phone]
        [StringLength(15)]
        [DisplayName("Điện thoại")]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Skype { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Zalo { get; set; }

        [MaxLength(100)]
        public string Facebook { get; set; }

        [DisplayName("Cấp quyền hoạt động")]
        public bool Active { get; set; }

        public int IDPhanQuyen { get; set; }

        [Required(ErrorMessage ="Xin vui lòng nhập mật khẩu của tài khoản")]
        [DataType(DataType.Password)]
        [StringLength(200,ErrorMessage ="Độ dài mật khẩu phải từ 6 đến 50 kí tự",MinimumLength = 6)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Xin vui lòng nhập bí danh của tài khoản")]
        [StringLength(50)]
        [DisplayName("Bí danh")]
        public string UserName { get; set; }

        [DisplayName("Trạng thái chờ xử lý")]
        public bool Status { get; set; }

        [DisplayName("Ngày tạo tài khoản")]
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate { get; set; }

        [DisplayName("Người tạo tài khoản")]
        public int? CreateBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }

    }
}
