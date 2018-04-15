using System.Collections.Generic;

namespace Model.DTO
{
    public class AnswerSheetTS
    {
        public int IDThiSinh { get; set; }
        public int DiemSo { get; set; }
        public double DiemThuc { get; set; }
        public int RemainTime { get; set; }
        public List<AnswerAAnswerSheet> answerSheet { get; set; }
    }
}
