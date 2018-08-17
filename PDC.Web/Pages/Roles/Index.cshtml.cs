using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Data;
using PDC.Web.Models;

namespace PDC.Web.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(PDC.Web.Models.PDCContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public IList<IdentityRole> roles { get;set; }

        public async Task OnGetAsync()
        {
            roles = await _context.Roles.ToListAsync();
        }
    }
}
