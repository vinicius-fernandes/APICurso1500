using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICurso1500.Data;
using APICurso1500.Models;

namespace APICurso1500.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly APICurso1500Context _context;

        public ContactsController(APICurso1500Context context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact()
        {
          if (_context.Contact == null)
          {
              return NotFound();
          }
            return await _context.Contact.ToListAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(string id)
        {
          if (_context.Contact == null)
          {
              return NotFound();
          }
            var contact = await _context.Contact.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // GET: api/Search/{tipo}/{email}/{app}
        [HttpGet("search/{tipo}")]
        public async Task<ActionResult<IEnumerable<Contact>>> Search(string tipo ,string ? email=null,string? app=null)
        {
            try
            {
                IQueryable<Contact> query = _context.Contact;
                if (!String.IsNullOrEmpty(email))
                {
                    query = query.Where(x => x.Email == email);
                }
                if (!String.IsNullOrEmpty(tipo))
                {
                    query = query.Where(x => x.Tipo == tipo);
                }
                if (!String.IsNullOrEmpty(app))
                {
                    query = query.Where(x => x.Email == app);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao obter as informações desejadas");
            }

        }


        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(string id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(contact).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return StatusCode(500, "Ocorreu um erro interno ao processar sua requisição!");
                    }
                }

                return NoContent();
            }
            return StatusCode(400, ModelState);
        }






        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
          if (_context.Contact == null)
          {
              return StatusCode(500,"Ocorreu um erro interno ao processar sua requisição!");
          }
            if (ModelState.IsValid)
            {
                contact.Id=Guid.NewGuid().ToString();
                _context.Contact.Add(contact);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {

                        return StatusCode(500, "Ocorreu um erro interno ao processar sua requisição!");
      
                }

                return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
            }
            return StatusCode(400,ModelState);

        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            if (_context.Contact == null)
            {
                return NotFound();
            }
            var contact = await _context.Contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactExists(string id)
        {
            return (_context.Contact?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
