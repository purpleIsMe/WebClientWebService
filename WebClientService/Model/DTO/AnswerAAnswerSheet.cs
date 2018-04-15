using System;

namespace Model.DTO
{
    public class AnswerAAnswerSheet
    {
        public int ThuTuCauHoi { get; set; }
        public int Answer { get; set; }
        public Guid QuestionID { get; set; }
        public int DapAn { get; set; }
    }
}
