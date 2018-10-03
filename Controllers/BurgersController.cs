using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repository;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurgersController : Controller
    {
        BurgersRepository _repo;
        public BurgersController(BurgersRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IEnumerable<Burger> Get()
        {
            return _repo.GetAll();
        }

        [HttpPost]
        public Burger Post([FromBody] Burger burger)
        {
            if (ModelState.IsValid)
            {
                burger = new Burger(burger.Name, burger.Description, burger.Price);
                return _repo.Create(burger);
            }
            throw new Exception("Invalid burg!");
        }
        [HttpPut]
        public Burger Put([FromBody] Burger burger)
        {
            return _repo.Update(burger);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }

}