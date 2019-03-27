using MtgCubeManagerServer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static MtgCubeManagerServer.Dtos.CardDtos;

namespace MtgCubeManagerServer.Repositories
{
    public class CardsRepository
    {
        private readonly ApplicationDbContext _db;

        private static readonly Expression<Func<Card, CardSearchInfoDto>> AsCardSearchInfoDto =
            x => new CardSearchInfoDto(x);

        public CardsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Card>> GetCards()
        {
            return await _db.Cards.ToListAsync();
        }

        public async Task<List<CardSearchInfoDto>> GetCardSearchInfos()
        {
            return await _db.Cards
                .Select(AsCardSearchInfoDto)
                .ToListAsync();
        }

        public async Task<Card> GetCardById(int cardId)
        {
            return await _db.Cards.FindAsync(cardId);
        }

        public async Task<int> AddCard(Card card)
        {
            _db.Cards.Add(card);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> AddScryfallCard(ScryfallCard scryfallCard)
        {
            var card = new Card(scryfallCard);

            _db.Cards.Add(card);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> UpdateCard(Card card)
        {
            _db.Entry(card).State = EntityState.Modified;

            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteCard(Card card)
        {
            _db.Cards.Remove(card);

            return await _db.SaveChangesAsync();
        }
    }
}