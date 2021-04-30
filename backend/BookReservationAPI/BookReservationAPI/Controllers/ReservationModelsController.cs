using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookReservationAPI.DatabaseContext;
using BookReservationAPI.Models;

namespace BookReservationAPI.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationModelsController : ControllerBase
    {
        private readonly ReservationContext _context;

        public ReservationModelsController(ReservationContext context)
        {
            _context = context;
        }

        // GET: api/ReservationModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationModel>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        // GET: api/ReservationModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationModel>> GetReservationModel(int id)
        {
            var reservationModel = await _context.Reservations.FindAsync(id);

            if (reservationModel == null)
            {
                return NotFound();
            }

            return reservationModel;
        }

        // PUT: api/ReservationModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationModel(int id, ReservationModel reservationModel)
        {
            if (id != reservationModel.UserID)
            {
                return BadRequest();
            }

            _context.Entry(reservationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReservationModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReservationModel>> PostReservationModel(ReservationModel reservationModel)
        {
            _context.Reservations.Add(reservationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationModel", new { id = reservationModel.UserID }, reservationModel);
        }

        // DELETE: api/ReservationModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReservationModel>> DeleteReservationModel(int id)
        {
            var reservationModel = await _context.Reservations.FindAsync(id);
            if (reservationModel == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservationModel);
            await _context.SaveChangesAsync();

            return reservationModel;
        }

        private bool ReservationModelExists(int id)
        {
            return _context.Reservations.Any(e => e.UserID == id);
        }
    }
}
