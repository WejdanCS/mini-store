using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace mini_store.Controllers;

public class CultureController : Controller
{
    public IActionResult SetLanguage(
        string culture,
        string returnUrl = "/")
    {
        string[] supportedCultures =
        [
            "ar",
            "en",
            "fr"
        ];

        if (!supportedCultures.Contains(culture))
        {
            culture = "ar"; // Default to Arabic if culture is not supported
        }

        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(culture)
            ),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true,
                HttpOnly = true,
                Secure = Request.IsHttps,
                SameSite = SameSiteMode.Lax
            }
        );

        if (!Url.IsLocalUrl(returnUrl))
        {
            returnUrl = "/";
        }

        return LocalRedirect(returnUrl);
    }
}