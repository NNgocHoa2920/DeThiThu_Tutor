namespace DeThiThu_Tutor.Models
{
    public class ToaNha
    {
        public string Id {  get; set; }
        public string DiaChhi {  get; set; }

        /// <summary>
        /// thiết lập mqh 1-n vs căn hộ
        /// ilist,. list,. collection
        /// </summary>
        public ICollection<CanHo> CanHos { get; set; }
    }
}
