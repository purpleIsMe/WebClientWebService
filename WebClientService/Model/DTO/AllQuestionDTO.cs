using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AllQuestionDTO
    {
        public int ID { get; set; }
        public string MaDeTron { get; set; }
        public Guid QuestionID { get; set; }
        public byte[] Question { get; set; }
        public byte[] Answer1 { get; set; }
        public byte[] Answer2 { get; set; }
        public byte[] Answer3 { get; set; }
        public byte[] Answer4 { get; set; }
        public int TheAnswer { get; set; }
        public int MaxAnswerLeng { get; set; }
        public int HV1 { get; set; }
        public int HV2 { get; set; }
        public int HV3 { get; set; }
        public int HV4 { get; set; }
        public int DapAn { get; set; }
        public string quesex { get; set; }

    }
}
