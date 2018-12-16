using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using PS.Nop.Plugin.ExternalAuth.LinkedIn;

namespace PS.Nop.Plugin.ExternalAuth.LinkedIn.Components
{
    [ViewComponent(Name = LinkedInExternalAuthConstants.ViewComponentName)]
    public class LinkedInAuthenticationViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/PS.ExternalAuth.linkedIn/Views/PublicInfo.cshtml");
        }
    }
}