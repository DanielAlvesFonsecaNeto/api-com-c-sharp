using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        // essa é uma rota pra retornar tudo mas não detalhado
        [HttpGet]
        public IActionResult GetAll(){
            var stock = _context.Stock.ToList();
            return Ok(stock);
        }

        // essa rota retorna o objeto especifico mas detalhado
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var stock = _context.Stock.Find(id);
            if (stock == null){
                return NotFound();
            }
            return Ok(stock);
        }


    }
}