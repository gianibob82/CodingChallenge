using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodingChallenge.Core.Abstract.Services;
using System.Threading.Tasks;
using CodingChallenge.Core.Exceptions;
using CodingChallenge.Core.Dto.Response;

namespace CodingChallenge.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IPetService _petService;
        public HomeController(IPetService petService)
        {
            _petService = petService;

        }
        public async Task<ActionResult> Index()
        {
            List<CatsByOwnerGenderResponseData> cats = null;
            try
            {
                cats = await _petService.ListCatNamesInAlphabeticalOrderGroupedByGenderAsync();

            }
            catch (ApiConnectionException apiex)
            {
                ViewBag.Error = "Connection error: " + apiex;
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some error: " + ex;
            }

            return View(cats);
        }
    }
}