using CardsApi.Models;
using CardsApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardDbContext _context;

        public CardController(CardDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _context.Cards.ToListAsync();

            return Ok(cards);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCardById(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FirstOrDefaultAsync(c=>c.Id == id);

            if (card == null)
            {
                return BadRequest();
            }

            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> AddCard(CardViewModel cardViewModel)
        {

            Card card = new Card()
            {
                Name = cardViewModel.Name,
                Number = cardViewModel.Number,
                ExpireMonth = cardViewModel.ExpireMonth,
                ExpireYear = cardViewModel.ExpireYear,
                CVC = cardViewModel.CVC


            };

            await _context.Cards.AddAsync(card);

            await _context.SaveChangesAsync();

            return Ok();

        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCard(int? id,CardViewModel cardViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            if (card == null)
            {
                return BadRequest();
            }

            card.Name = cardViewModel.Name;
            card.Number = cardViewModel.Number;
            card.ExpireMonth = cardViewModel.ExpireMonth;
            card.ExpireYear = cardViewModel.ExpireYear;
            card.CVC = cardViewModel.CVC;

            _context.Cards.Update(card);

            await _context.SaveChangesAsync();

            return Ok();
            
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Id == id);

            if (card == null)
            {
                return BadRequest();
            }

            _context.Cards.Remove(card);

            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}
