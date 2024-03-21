using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.ViewComponents.HomePage;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultDiscountOfDayComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
