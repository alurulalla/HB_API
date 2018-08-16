using System.Threading.Tasks;
using HummingBoxApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HummingBoxApp.API.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private readonly IHBRepository _repo;

        public ItemsController(IHBRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _repo.GetItems();

            return Ok(items);
        }

    }
}