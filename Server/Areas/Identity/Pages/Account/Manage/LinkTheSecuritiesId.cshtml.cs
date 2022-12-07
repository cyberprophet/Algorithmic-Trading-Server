using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShareInvest.Server.Areas.Identity.Pages.Account.Manage
{
    public partial class LinkTheSecuritiesIdModel : PageModel
    {
        public LinkTheSecuritiesIdModel(ILogger<LinkTheSecuritiesIdModel> logger)
        {
            this.logger = logger;
        }
        public IActionResult OnPost()
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.LogInformation("Post Exception: { }",
                                      ex.Message);
            }
            return Page();
        }
        public IActionResult OnGet()
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.LogInformation("Get Exception: { }",
                                      ex.Message);
            }
            return Page();
        }
        readonly ILogger<LinkTheSecuritiesIdModel> logger;
    }
}