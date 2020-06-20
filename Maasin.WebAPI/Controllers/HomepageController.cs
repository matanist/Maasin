using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maasin.Datas.Models;
using Maasin.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Maasin.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class HomepageController : Controller
    {
        MaasDBContext _context;
        public HomepageController(MaasDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ApiResponse GetAllBranches()
        {
            var allBranches = _context.Branch.ToList();
            return new ApiResponse { Code = 200, Message = "Success", Set = allBranches };
        }
    }
}
