using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ShareInvest.Server.Data;
using ShareInvest.Server.Data.Models;

namespace ShareInvest.Server.Areas.Identity.Pages.Account.Manage
{
    public partial class LinkTheSecuritiesIdModel : PageModel
    {
        public LinkTheSecuritiesIdModel(UserManager<CoreUser> manager, ILogger<LinkTheSecuritiesIdModel> logger, CoreContext context)
        {
            this.context = context;
            this.manager = manager;
            this.logger = logger;
        }
        public async Task<IActionResult> OnPostAsync([FromForm] int securities, [FromForm] string id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.LogInformation(nameof(OnPostAsync), ex.Message);
            }
            return Page();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {

            }
            catch (Exception ex)
            {
                logger.LogInformation(nameof(OnGetAsync), ex.Message);
            }
            return Page();
        }
        readonly CoreContext context;
        readonly UserManager<CoreUser> manager;
        readonly ILogger<LinkTheSecuritiesIdModel> logger;
    }
}