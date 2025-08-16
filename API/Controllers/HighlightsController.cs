using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    public class HighlightsController: ControllerBase
    {
        HighligtsRepository _repo;

        public HighlightsController(HighligtsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetHightlights()
        {
            var hightligts= await _repo.GetAllAsync();
            return Ok(hightligts);
        }

        public async Task<bool> AddHightlight(int id)
        {
            bool delete = await _repo.RemoveAsync(id);
            return delete;
        }
        public async Task<bool> DeleteHightlight(int id)
        {
            bool delete = await _repo.RemoveAsync(id);
            return delete;
        }
    }
}
