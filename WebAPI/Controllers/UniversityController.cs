using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Models;

namespace WebAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UniversityController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UniversityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/University?pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<ActionResult<PagedResult<University>>> GetUniversities(int pageNumber = 1, int pageSize = 10)
        {
            var universities = _context.Universities.AsQueryable();

            var totalCount = await universities.CountAsync();
            var items = await universities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var result = new PagedResult<University>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = pageSize,
                PageNumber = pageNumber
            };

            return result;
        }
    }
}