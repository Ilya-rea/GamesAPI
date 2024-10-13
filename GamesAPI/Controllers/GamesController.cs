using System;
using System.Linq;
using System.Threading.Tasks;
using GamesAPI.Models;
using GamesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : Controller
	{
		private readonly IModelMapping _modelMapping;

		public GamesController(IModelMapping modelMapping)
		{
			_modelMapping = modelMapping;
		}

        [HttpGet]
        public async Task<IQueryable<GameForm>> Get(string? genre = null)
		{
            if (!string.IsNullOrEmpty(genre))
            {
                return _modelMapping.Get(genre);
            }
            return _modelMapping.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GameForm gameForm)
        {
            _modelMapping.Create(gameForm);
            return Ok();
        }

        
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] GameForm gameForm)
        {
            _modelMapping.Update(gameForm);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _modelMapping.Delete(id);
            return Ok();
        }

    }
}

