using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    public class CartController: ControllerBase
    {
        CartRepository _repo;

        public CartController(CartRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetHightlights(int id)
        {
            var cart= await _repo.GetCartAsync(id);
            return Ok(cart);
        }

        public async Task<bool> AddHightlight(int id,int UserId)
        {
            bool delete = await _repo.AddCartProductAsync(id, UserId);
            return delete;
        }
        public async Task<bool> DeleteHightlight(int id,int UserId)
        {
            bool delete = await _repo.RemoveCartProductAsync(id, UserId);
            return delete;
        }
    }
}
