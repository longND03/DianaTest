using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PremaritalCounseling.Repository.DBContext;
using PremaritalCounseling.Repository.Models;
using PremaritalCounseling.Service.Interfaces;

namespace PremaritalCounseling.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PostsController : Controller
    {
        private readonly IPostService _potService;

        public PostsController(IPostService potService) => _potService = potService;



        // GET: api/<PotsController>
        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await _potService.GetAll();
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<int> Post(Post post)
        {
            return await _potService.Create(post);
        }

        // PUT api/<BookingController>/5
        [HttpPut]
        public async Task<int> Put(Post post)
        {
            return await _potService.Update(post);
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _potService.Delete(id);
        }

    }
}
