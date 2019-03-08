using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contactos.Models;
using Microsoft.AspNetCore.Mvc;

namespace contactos.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactosContext _context;

        public ContactController(ContactosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Contacto> GetAll()
        {
            return _context.Contacto.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetById(long id)
        {
            var item = await _context.Contacto.FindAsync(id);
            if(item==null)
            {
                return NotFound();
            }

            return item;
        }
    }
}