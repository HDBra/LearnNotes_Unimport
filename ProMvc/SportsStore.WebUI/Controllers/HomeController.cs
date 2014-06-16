using System.Linq;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private Person[] personData =
        {
            new Person
            {
                PersonId = 1,
                FirstName = "Adam",
                LastName = "Freeman",
                Role = Role.Admin
            },
            new Person
            {
                PersonId = 2,
                FirstName = "Steven",
                LastName = "Sanderson",
                Role = Role.Admin
            },
            new Person
            {
                PersonId = 3,
                FirstName = "Jacqui",
                LastName = "Griffyth",
                Role = Role.User
            },
            new Person
            {
                PersonId = 4,
                FirstName = "John",
                LastName = "Smith",
                Role = Role.User
            },
            new Person
            {
                PersonId = 5,
                FirstName = "Anne",
                LastName = "Jones",
                Role = Role.Guest
            }
        };

        public ActionResult Index(int id = 1)
        {
            Person dataItem = personData.Where(p => p.PersonId == id).First();
            return View(dataItem);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("Index", person);
        }
    }
}
