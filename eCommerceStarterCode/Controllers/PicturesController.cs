using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Controllers
{
    [Route("api/pictures")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PicturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pictures value)
        {
            var userId = User.FindFirstValue("id");
            value.UserId = userId;
            try
            {
                _context.Pictures.Add(value);
                _context.SaveChanges();
                return StatusCode(201, value);
            }
            catch
            {
                return StatusCode(400, value);
            }

        }
        //[HttpDelete("{MerchId}/{UserId}")]
        //public IActionResult Remove(int MerchId, string UserId)
        //{
        //    var deleteProduct = _context.ShoppingCarts.Where(dp => dp.UserId == UserId && dp.MerchId == MerchId).SingleOrDefault();
        //    if (deleteProduct == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.ShoppingCarts.Remove(deleteProduct);
        //    _context.SaveChanges();
        //    return Ok(deleteProduct);
        //}
        //[HttpGet(), Authorize]
        //public IActionResult GetUserCart()
        //{
        //    var userId = User.FindFirstValue("id");
        //    var userCart = _context.ShoppingCarts.Include(uc => uc.Merch).ThenInclude(ac => ac.User).Where(uc => uc.UserId == userId).ToList().
        //        Select(e => new { merchName = e.Merch.Name, merchPrice = e.Merch.Price });
        //    if (userCart == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(userCart);
        //}
    }
}

