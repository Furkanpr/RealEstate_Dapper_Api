using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.__ViewComponents.Layout
{
    public class _HeaderViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
