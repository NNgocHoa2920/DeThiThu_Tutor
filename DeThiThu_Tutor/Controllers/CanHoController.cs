using DeThiThu_Tutor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DeThiThu_Tutor.Controllers
{
    public class CanHoController : Controller
    {
        //gọi db sang bên này để sử dụng
        private readonly AppDbContext _db;
        public CanHoController(AppDbContext db)
        {
            _db = db;   
        }
             
        // GET: CanHoController
        public ActionResult Index()
        {
            var canHoList = _db.canHos.ToList();
            return View(canHoList);
        }

        // GET: CanHoController/Details/5
        public ActionResult Details(string hi)  // hi chính là tham số truyeefn vào của mình/ nó ddajji diện cho khóa chính
        {
            //tìm ra canho muốn xem chi tiết
            var canho = _db.canHos.Find(hi);
            return View(canho);
        }

        // GET: CanHoController/Create
        public ActionResult Create() // tạo ra view create
        {
            return View();
        }

        // POST: CanHoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CanHo canHo)
        {
           _db.canHos.Add(canHo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CanHoController/Edit/5
        public ActionResult Edit(string hi) // tạo ra view edit có chứa thhoong tin cần edit
        {
            //tìm kiếm đối tượng cần edit

            var canhho = _db.canHos.Find(hi);
            //chuyển dữ liệu sang dạng json
            var jsonData = JsonConvert.SerializeObject(canhho);
            //lư vào session
            HttpContext.Session.SetString("edited", jsonData);

            return View(canhho);
        }

        // POST: CanHoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CanHo canho)
        {
            _db.canHos.Update(canho);
            _db.SaveChanges();  
            return RedirectToAction("Index");
        }

        // GET: CanHoController/Delete/5
        public ActionResult Delete(string hi)
        {
            //tìm ra doituong can delete

            var canho = _db.canHos.Find(hi);
            //sau klhi tìm đc đối tượng cần xóa thì lưu luôn vào session
            //chuyển dữ liệu sang dạng json
            var jsonData = JsonConvert.SerializeObject(canho);
            //lư vào session
            HttpContext.Session.SetString("deleted", jsonData);
            //xóa đối tượng vừa tìm
            _db.canHos.Remove(canho);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult RollBack()
        {
            //var data = HttpContext.Session.GetString("deleted");
            var data = HttpContext.Session.GetString("edited");
            //taJO 1 ĐỐI TƯỢNG Y HỆT ĐỐI TƯỢNG CŨ
            //CONVEERT VỀ KIỂU BÌNH THƯỜNG
            var deleteData = JsonConvert.DeserializeObject<CanHo>(data);

            //theem lại vào csdl
            //_db.canHos.Add(deleteData);
            _db.canHos.Update(deleteData);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
