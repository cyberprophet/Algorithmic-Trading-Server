using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using ShareInvest.Server.Data;
using ShareInvest.Server.Data.Models;

namespace ShareInvest.Server.Areas.Identity.Pages.Account.Manage
{
    public class GrantAdminPrivilegesModel : PageModel
    {
        public GrantAdminPrivilegesModel(CoreContext context, UserManager<CoreUser> manager, ILogger<GrantAdminPrivilegesModel> logger)
        {
            this.context = context;
            this.manager = manager;
            this.logger = logger;
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
        public async Task<IActionResult> OnPostAsync([FromForm] string admin)
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
        readonly CoreContext context;
        readonly UserManager<CoreUser> manager;
        readonly ILogger<GrantAdminPrivilegesModel> logger;
    }
}