namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Music")]
    public partial class Music
    {
        public int MusicID { get; set; }

        public Guid QuestionID { get; set; }

        public byte[] DataMusic { get; set; }

        [StringLength(200)]
        public string NameMusic { get; set; }

        [StringLength(500)]
        public string TypeMusic { get; set; }

        public int? SizeMusic { get; set; }

        public Guid? ClassID { get; set; }

        public Guid? SubjectID { get; set; }
    }
}
