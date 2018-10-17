using System.ComponentModel.DataAnnotations;

namespace MtgCubeManagerServer.Models
{
    public class Card
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public string Lang { get; set; }
        public string PrintsSearchUri { get; set; }
        public string RulingsUri { get; set; }
        public string ScryfallUri { get; set; }
        public string Uri { get; set; }

        public decimal? Cmc { get; set; }
        public string Colors { get; set; }
        public string ColorIdentity { get; set; }
        public string ColorIndicator { get; set; }
        public bool? Foil { get; set; }
        public string Layout { get; set; }
        public string Loyalty { get; set; }
        public string ManaCost { get; set; }
        public string OracleText { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string TypeLine { get; set; }

        public string Artist { get; set; }
        public string CollectorNumber { get; set; }
        public bool? Digital { get; set; }
        public string FlavorText { get; set; }
        public string Rarity { get; set; }
        public string ScryfallSetUri { get; set; }
        public string Set { get; set; }
        public string SetName { get; set; }
        public string SetSearchUri { get; set; }
        public string SetUri { get; set; }
        public bool? Timeshifted { get; set; }

        public string ImageUriPng { get; set; }
        public string ImageUriBorderCrop { get; set; }
        public string ImageUriArtCrop { get; set; }
        public string ImageUriLarge { get; set; }
        public string ImageUriNormal { get; set; }
        public string ImageUriSmall { get; set; }

        public string RelatedUriTcgplayerDecks { get; set; }
        public string RelatedUriEdhrec { get; set; }
        public string RelatedUriMtgtop8 { get; set; }
    }
}