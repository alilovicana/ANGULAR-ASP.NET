using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt3.Data;
using Projekt3.Models;

namespace Projekt3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KontaktiController : Controller
    {
        private readonly KontaktiDbContext kontaktiDbContext;

        public KontaktiController(KontaktiDbContext kontaktiDbContext)
        {
            this.kontaktiDbContext = kontaktiDbContext;
        }
        //GetAllKontakti
        [HttpGet]

        public async Task<IActionResult> GetAllKontakti()
        {
            var kontakti = await kontaktiDbContext.Kontakti.ToListAsync();
            return Ok(kontakti);
        }
        //GetSingleKontakt
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetKontakt")]
        public async Task<IActionResult> GetKontakt([FromRoute] Guid id)
        {
            var kontakt = await kontaktiDbContext.Kontakti.FirstOrDefaultAsync(x => x.Id == id);
            if (kontakt != null) { return Ok(kontakt); }
            else { return NotFound("Kontakt Not Found!"); }
        }
        //AddKontakt
        [HttpPost]
        public async Task<IActionResult> AddKontakt([FromBody] Kontakt kontakt)
        {
            kontakt.Id = Guid.NewGuid();
            await kontaktiDbContext.Kontakti.AddAsync(kontakt);
            await kontaktiDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetKontakt), new { id = kontakt.Id }, kontakt);
        }
        //UpdatingAKontakt
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateKontakt([FromRoute] Guid id, [FromBody] Kontakt kontakt)
        {
            var existingKontakt = await kontaktiDbContext.Kontakti.FirstOrDefaultAsync(x => x.Id == id);
            if (existingKontakt != null)
            {
                existingKontakt.Name = kontakt.Name;
                existingKontakt.Surname = kontakt.Surname;
                existingKontakt.Adress = kontakt.Adress;
                existingKontakt.PhoneNumber = kontakt.PhoneNumber;
                existingKontakt.Email = kontakt.Email;
                existingKontakt.Tag = kontakt.Tag;
                await kontaktiDbContext.SaveChangesAsync();
                return Ok(existingKontakt);
            }
            return NotFound("Contact not found!");
        }
        //DeletingAKontakt
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteKontakt([FromRoute] Guid id)
        {
            var existingKontakt = await kontaktiDbContext.Kontakti.FirstOrDefaultAsync(x => x.Id == id);
            if (existingKontakt != null)
            {
                kontaktiDbContext.Kontakti.Remove(existingKontakt);
                await kontaktiDbContext.SaveChangesAsync();
                return Ok(existingKontakt);
            }
            return NotFound("Contact not found!");
        }
    }
}
