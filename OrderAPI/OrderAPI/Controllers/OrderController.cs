using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly pharmvcContext db;
        public OrderController(pharmvcContext _db)
        {
            db = _db;
        }
        public static List<AddtoCart> atc = new List<AddtoCart>();
        //[HttpDelete]
        //public async Task<IActionResult> CancelOrder(int id)
        //{

        //    var atc = (await db.AddtoCarts.Where(p => p.Userid == id).ToListAsync());
        //    foreach (var item in atc)
        //    {
        //        db.AddtoCarts.Remove(item);
        //        await db.SaveChangesAsync();
        //    }

        //    return Ok();
        //}
        //[HttpGet]
        //public async Task<IActionResult> Myorders(int id)
        //{

        //    var atc = (await db.AddtoCarts.Where(p => p.Userid == id).ToListAsync());
        //    return Ok(atc);
        //}
        [HttpGet]
        [Route("GetCartByUserId")]
        public async Task<IActionResult> GetCartByUserId(int Userid)
        {
            List<AddtoCart> a = new List<AddtoCart>();
            a = (from i in db.AddtoCarts
                 where i.Userid == Userid
                 select i).ToList();
            return Ok(a);
        }
        [HttpDelete]
        [Route("DeleteCartByUserId")]
        public async Task<IActionResult> DeleteCartByUserId(int Userid)
        {
            List<AddtoCart> a = new List<AddtoCart>();
            a = (from i in db.AddtoCarts
                 where i.Userid == Userid
                 select i).ToList();
            foreach (AddtoCart item in a)
            {
                db.AddtoCarts.Remove(item);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
