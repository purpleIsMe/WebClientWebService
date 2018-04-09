using System;

namespace Model.DTO
{
    public class AllQuestionDTO
    {
        public int ID { get; set; }
        public string MaDeTron { get; set; }
        public Guid QuestionID { get; set; }
        public int DapAn { get; set; }
        public byte[] PicQues { get; set; }
        public byte[] PicAns1 { get; set; }
        public byte[] PicAns2 { get; set; }
        public byte[] PicAns3 { get; set; }
        public byte[] PicAns4 { get; set; }
        public string sQues { get; set; }
        public string sAns1 { get; set; }
        public string sAns2 { get; set; }
        public string sAns3 { get; set; }
        public string sAns4 { get; set; }
    }
}
