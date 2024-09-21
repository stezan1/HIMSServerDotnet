using Microsoft.AspNetCore.Mvc;
using PatientLibrary;

namespace HIMSServer.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult DisplayAddPatientForm()//load the UI
        {
            return View("AddPatient");
        }
        public IActionResult AddPatient(Patient obj)//take the button click
        {
            return View("DisplayPatient",obj);
        }
    }
}
