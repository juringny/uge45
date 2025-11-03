using Microsoft.AspNetCore.Mvc;
using ValidateTheNameModelBinding.Models;
using ValidateTheNameModelBinding.Util;

namespace ValidateTheNameWebApplication.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", new { nameIsValid = false, showNameEvaluation = false });
        }

        [HttpPost]
        public IActionResult ValidateName(PersonDTO personDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new { nameIsValid = false, showNameEvaluation = true });
            }

            try
            {
                // Opret domæneprimitiver fra DTO
                var firstname = new Firstname(personDto.Firstname);
                var lastname  = new Lastname(personDto.Lastname);

                // Opret Person med domæneprimitiverne
                Person personWithInvariance = new Person(firstname, lastname);

                // Gem personen i repository
                PersonRepository personRepository = new PersonRepository();
                personRepository.AddPerson(personWithInvariance);

                return View("Index", new
                {
                    nameIsValid = true,
                    showNameEvaluation = true,
                    personFullName = personWithInvariance.ToString()
                });
            }
            catch (Exception ex)
            {
                // Hvis input ikke overholder domæneprimitiv-reglerne
                return View("Index", new
                {
                    nameIsValid = false,
                    showNameEvaluation = true,
                    errorMessage = ex.Message
                });
            }
        }

       
    }
}
