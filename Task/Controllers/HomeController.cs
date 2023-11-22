using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task.Data;
using Task.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNewUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewUser(InformationUser model)
        {
            if (ModelState.IsValid)
            {
                _db.informationUsers.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("DisplayAllUsers");
            }
            return View(model);
        }

        public IActionResult DisplayAllUsers()
        {
            var result = _db.informationUsers.ToList();
            return View(result);
        }
        public IActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("DisplayAllUsers", "Home");
            }
            var pro = _db.informationUsers.Find(id);
            if (pro == null)
            {
                return RedirectToAction("DisplayAllUsers", "Home");
            }

            return View(pro);
        }
        [HttpPost]
        public IActionResult DeleteUser(InformationUser model)
        {
            _db.informationUsers.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("DisplayAllUsers");

        }

        public async Task<IActionResult> UpdateUser(int? id)
        {
            var user = await _db.informationUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new InformationUser
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Guender = user.Guender,
                Salary=user.Salary,
                BirthDate=user.BirthDate,
                Address=user.Address,
                Age=user.Age,
               Country=user.Country,
               City=user.City,


            });
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(InformationUser model, int id)
        {
            if (ModelState.IsValid)
            {
                var user = await _db.informationUsers.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.FullName = model.FullName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Guender = model.Guender;
                user.Salary = model.Salary;
                user.BirthDate = model.BirthDate;
                user.Address = model.Address;
                user.Age = model.Age;
                user.Country = model.Country;
                user.City = model.City;



                _db.informationUsers.Update(user);
                await _db.SaveChangesAsync();
                return RedirectToAction("DisplayAllUsers");
            }

            return View(model);
        }
        public IActionResult DetailsUser(int? id)
        {
            if(id== null)
            {
                return RedirectToAction("Index");
            }
            var findUser=_db.informationUsers.Find(id);
            if(findUser == null)
            {
                return RedirectToAction("Index");

            }
            return View(findUser);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}