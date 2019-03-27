using MtgCubeManagerServer.Models;

namespace MtgCubeManagerServer.Dtos
{
    public class CardDtos
    {
        /*
        public class CardScryfallDto
        {
            public CardScryfallDto()
            {
            }

            // todo generate class through json to c# class converter
        }
        */

        public class CardSearchInfoDto
        {
            public CardSearchInfoDto()
            {
            }

            public CardSearchInfoDto(Card card)
            {
                CardId = card.CardId;
                CardName = card.CardName;
                ImageUriSmall = card.ImageUriSmall;
                Rarity = card.Rarity;
                Set = card.SetCode;
                SetName = card.SetName;
            }

            public int CardId { get; set; }
            public string CardName { get; set; }
            public string ImageUriSmall { get; set; }
            public string Rarity { get; set; }
            public string Set { get; set; }
            public string SetName { get; set; }
        }
    }
}