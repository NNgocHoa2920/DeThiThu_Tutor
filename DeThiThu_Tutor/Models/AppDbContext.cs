
using Microsoft.EntityFrameworkCore;

namespace DeThiThu_Tutor.Models
{
    public class AppDbContext : DbContext
    {
        //ctor
        public AppDbContext()
        {
            

        }
        //ctrl + . => genernate contructor 
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        //tajo dbset: nó đại diện cho 1 thực thể = ddajji diện cho 1 bảng ở trong csdl
        //trong moel có bn class thì có bấy nhiêu dbset
        ///luôn  luôn để public cho dbset
        public DbSet<CanHo> canHos { get; set; }
        public DbSet<ToaNha> toaNhas { get; set; }

        ///cách 1: để chuỗi kết nối ở trong dbcontext
        ///ctrl + . => generate overrider => tích OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NGUYEN_NGOC_HOA\\HOANN; Database=db_thithu_tUTOR;Trusted_Connection= True;" +
                                "TrustServerCertificate=True");
        }
        //CÁCH 2: ĐỂ CHUỖI KẾT NNOOSI Ở APPSETINNG.JSON
      

    }
}
