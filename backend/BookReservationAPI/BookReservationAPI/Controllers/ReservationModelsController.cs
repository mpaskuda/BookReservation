using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookReservationAPI.DatabaseContext;
using BookReservationAPI.Models;
using BookReservationAPI.Repository;

namespace BookReservationAPI.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationModelsController : ControllerBase
    {
        private readonly IReservationRepository<ReservationModel> _dataRepository;
        private IEnumerable<ReservationModel> reservations2;
        public ReservationModelsController(IReservationRepository<ReservationModel> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/ReservationModel
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<ReservationModel> reservations = _dataRepository.GetAll(id);
            return Ok(reservations);
        }
        // GET: api/ReservationModel/5
        [HttpGet("{id}/{id2}")]
        public IActionResult Get(int id, int id2)
        {
            ReservationModel reservations = _dataRepository.Get(id, id2);
            if (reservations == null)
            {
                return NotFound("The ReservationModel record couldn't be found.");
            }
            return Ok(reservations);
        }
        // POST: api/ReservationModel
        [HttpPost]
        public IActionResult Post([FromBody] ReservationModel reservation)
        {
            if (reservation == null)
            {
                return BadRequest("ReservationModel is null.");
            }
            _dataRepository.Add(reservation);
            return CreatedAtRoute(
                  "Get",
                  new { Id = reservation.BookID },
                  reservation);
        }
        // PUT: api/ReservationModel/5
        [HttpPut]
        public IActionResult Put([FromBody] ReservationModel reservation)
        {
            if (reservation == null)
            {
                return BadRequest("ReservationModel is null.");
            }
            ReservationModel reservationToUpdate = _dataRepository.Get(reservation.BookID, reservation.UserID);
            if (reservationToUpdate == null)
            {
                return NotFound("The ReservationModel record couldn't be found.");
            }
            _dataRepository.Update(reservationToUpdate, reservation);
            return NoContent();
        }
        // DELETE: api/ReservationModel/5
        [HttpDelete("{id}/{id2}")]
        public IActionResult Delete(int id, int id2)
        {
            ReservationModel reservation = _dataRepository.Get(id, id2);
            if (reservation == null)
            {
                return NotFound("The ReservationModel record couldn't be found.");
            }
            _dataRepository.Delete(reservation);
            return NoContent();
        }
    }
}