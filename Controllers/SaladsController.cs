using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repository;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaladsController : Controller
    {
        SaladsRepository _repo;
        public SaladsController(SaladsRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IEnumerable<Salad> Get()
        {
            return _repo.GetAll();
        }

        [HttpPost]
        public Salad Post([FromBody] Salad salad)
        {
            if (ModelState.IsValid)
            {
                salad = new Salad(salad.Name, salad.Description, salad.Price);
                return _repo.Create(salad);
            }
            throw new Exception("Invalid salad!");
        }

        [HttpPut]
        public Salad Put([FromBody] Salad salad)
        {
            return _repo.Update(salad);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}