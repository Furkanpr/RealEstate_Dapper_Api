using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Models.ViewComponents.Layout

{   
    public class HeaderViewComponentPartial : ViewComponent
    {
        public IViewComponentResult ınvoke()
        {
            return View();
        }
        
    }
}
