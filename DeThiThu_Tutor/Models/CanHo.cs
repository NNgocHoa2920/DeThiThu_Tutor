namespace DeThiThu_Tutor.Models
{
    public class CanHo
    {
        public string ID { get; set; }
        public string Ten { get; set; }
        public double DienTich {  get; set; }           
        public string So {  get; set; }
        public ToaNha ? ToaNha { get; set; }      // khóa ngoại của các bạn
        //cho dấu ? để theer hiện khóa ngoại dc phép null

    }
}
