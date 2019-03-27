
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MtgCubeManagerServer.Models
{
    public class Card
    {
        public Card(ScryfallCard scryfallCard)
        {
            ScryfallId = scryfallCard.Id;
            OracleId = scryfallCard.OracleId;
            MultiverseId = scryfallCard.MultiverseIds.Count > 0 ? scryfallCard.MultiverseIds.First() : null;
            MtgoId = scryfallCard.MtgoId;
            MtgoFoilId = scryfallCard.MtgoFoilId;
            ArenaId = scryfallCard.ArenaId;
            TcgplayerId = scryfallCard.TcgplayerId;
            CardName = scryfallCard.Name;
            Lang = scryfallCard.Lang;
            ReleasedAt = scryfallCard.ReleasedAt;
            Uri = scryfallCard.Uri.ToString();
            ScryfallUri = scryfallCard.ScryfallUri.ToString();
            Layout = scryfallCard.Layout;
            HighresImage = scryfallCard.HighresImage;
            ImageUriPng = scryfallCard.ImageUris.Png.ToString();
            ImageUriBorderCrop = scryfallCard.ImageUris.BorderCrop.ToString();
            ImageUriArtCrop = scryfallCard.ImageUris.ArtCrop.ToString();
            ImageUriLarge = scryfallCard.ImageUris.Large.ToString();
            ImageUriNormal = scryfallCard.ImageUris.Normal.ToString();
            ImageUriSmall = scryfallCard.ImageUris.Small.ToString();
            ManaCost = scryfallCard.ManaCost;
            Cmc = scryfallCard.Cmc;
            TypeLine = scryfallCard.TypeLine;
            OracleText = scryfallCard.OracleText;
            Colors = string.Join(",", scryfallCard.Colors);
            ColorIdentity = string.Join(",", scryfallCard.ColorIdentity);
            ColorIndicator = string.Join(",", scryfallCard.ColorIndicator);
            LegalityStandard = scryfallCard.Legalities.Standard == "legal";
            LegalityFuture = scryfallCard.Legalities.Future == "legal";
            LegalityModern = scryfallCard.Legalities.Modern == "legal";
            LegalityLegacy = scryfallCard.Legalities.Legacy == "legal";
            LegalityPauper = scryfallCard.Legalities.Pauper == "legal";
            LegalityVintage = scryfallCard.Legalities.Vintage == "legal";
            LegalityCommander = scryfallCard.Legalities.Commander == "legal";
            AvailableArena = scryfallCard.Games.Contains("arena");
            AvailableMtgo = scryfallCard.Games.Contains("mtgo");
            AvailablePaper = scryfallCard.Games.Contains("paper");
            Reserved = scryfallCard.Reserved;
            Foil = scryfallCard.Foil;
            Nonfoil = scryfallCard.Nonfoil;
            Oversized = scryfallCard.Oversized;
            Promo = scryfallCard.Promo;
            Reprint = scryfallCard.Reprint;
            SetCode = scryfallCard.Set;
            SetName = scryfallCard.SetName;
            SetUri = scryfallCard.SetUri.ToString();
            SetSearchUri = scryfallCard.SetSearchUri.ToString();
            ScryfallSetUri = scryfallCard.ScryfallSetUri.ToString();
            RulingsUri = scryfallCard.RulingsUri.ToString();
            PrintsSearchUri = scryfallCard.PrintsSearchUri.ToString();
            CollectorNumber = scryfallCard.CollectorNumber;
            Digital = scryfallCard.Digital;
            Rarity = scryfallCard.Rarity;
            Watermark = scryfallCard.Watermark;
            IllustrationId = scryfallCard.IllustrationId;
            Artist = scryfallCard.Artist;
            BorderColor = scryfallCard.BorderColor;
            Frame = scryfallCard.Frame;
            FrameEffect = scryfallCard.FrameEffect;
            FullArt = scryfallCard.FullArt;
            StorySpotlight = scryfallCard.StorySpotlight;
            RelatedUriTcgplayerDecks = scryfallCard.RelatedUris.TcgplayerDecks.ToString();
            RelatedUriEdhrec = scryfallCard.RelatedUris.Edhrec.ToString();
            RelatedUriMtgtop8 = scryfallCard.RelatedUris.Mtgtop8.ToString();
            Power = scryfallCard.Power;
            Toughness = scryfallCard.Toughness;
            FlavorText = scryfallCard.FlavorText;
            EdhrecRank = scryfallCard.EdhrecRank;
            Loyalty = scryfallCard.Loyalty;
        }

        /*
public Card(CardScryfallDto cardScryfallDto)
{
   ScryfallId = cardScryfallDto.id scryfallCard.
   CardName = cardScryfallDto.name scryfallCard.
   Artist = cardScryfallDto.artist scryfallCard.
   Cmc = cardScryfallDto.cmc scryfallCard.
   CollectorNumber = cardScryfallDto.collector_number scryfallCard.
   Colors = cardScryfallDto.colors scryfallCard.
   ColorIdentity = cardScryfallDto.color_identity scryfallCard.
   ColorIndicator = cardScryfallDto.color_indicator scryfallCard.
   Digital = cardScryfallDto.digital scryfallCard.
   FlavorText = cardScryfallDto.flavor_text scryfallCard.
   Foil = cardScryfallDto.foil scryfallCard.
   Lang = cardScryfallDto.lang scryfallCard.
   Layout = cardScryfallDto.layout scryfallCard.
   Loyalty = cardScryfallDto.loyalty scryfallCard.
   ManaCost = cardScryfallDto.manaCost scryfallCard.
   OracleText = cardScryfallDto.oracle_text scryfallCard.
   Power = cardScryfallDto.power scryfallCard.
   Rarity = cardScryfallDto.rarity scryfallCard.
   SetCode = cardScryfallDto.set scryfallCard.
   SetName = cardScryfallDto.set_name scryfallCard.
   Timeshifted = cardScryfallDto.timeshifted scryfallCard.
   Toughness = cardScryfallDto.toughness scryfallCard.
   TypeLine = cardScryfallDto.type_line scryfallCard.
   PrintsSearchUri = cardScryfallDto.prints_search_uri scryfallCard.
   RulingsUri = cardScryfallDto.rulings_uri scryfallCard.
   ScryfallUri = cardScryfallDto.scryfall_uri scryfallCard.
   SetSearchUri = cardScryfallDto.setSearch_uri scryfallCard.
   SetUri = cardScryfallDto.set_uri scryfallCard.
   Uri = cardScryfallDto.uri scryfallCard.
   ImageUriPng = cardScryfallDto.image_uris.png scryfallCard.
   ImageUriBorderCrop = cardScryfallDto.image_uris.borderCrop scryfallCard.
   ImageUriArtCrop = cardScryfallDto.image_uris.artCrop scryfallCard.
   ImageUriLarge = cardScryfallDto.image_uris.large scryfallCard.
   ImageUriNormal = cardScryfallDto.image_uris.normal scryfallCard.
   ImageUriSmall = cardScryfallDto.image_uris.small scryfallCard.
   RelatedUriTcgplayerDecks = cardScryfallDto.related_uris.tcgplayer_decks scryfallCard.
   RelatedUriEdhrec = cardScryfallDto.related_uris.edhrec scryfallCard.
   RelatedUriMtgtop8 = cardScryfallDto.related_uris.mtgtop8 scryfallCard.
}
*/

        /*
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CardId { get scryfallCard. set scryfallCard. }
    public string ScryfallId { get scryfallCard. set scryfallCard. }
    public string CardName { get scryfallCard. set scryfallCard. }

    public string Artist { get scryfallCard. set scryfallCard. }
    public decimal? Cmc { get scryfallCard. set scryfallCard. }
    public string CollectorNumber { get scryfallCard. set scryfallCard. }
    public string Colors { get scryfallCard. set scryfallCard. }
    public string ColorIdentity { get scryfallCard. set scryfallCard. }
    public string ColorIndicator { get scryfallCard. set scryfallCard. }
    public bool? Digital { get scryfallCard. set scryfallCard. }
    public string FlavorText { get scryfallCard. set scryfallCard. }
    public bool? Foil { get scryfallCard. set scryfallCard. }
    public string Lang { get scryfallCard. set scryfallCard. }
    public string Layout { get scryfallCard. set scryfallCard. }
    public string Loyalty { get scryfallCard. set scryfallCard. }
    public string ManaCost { get scryfallCard. set scryfallCard. }
    public string OracleText { get scryfallCard. set scryfallCard. }
    public string Power { get scryfallCard. set scryfallCard. }
    public string Rarity { get scryfallCard. set scryfallCard. }
    public string SetCode { get scryfallCard. set scryfallCard. }
    public string SetName { get scryfallCard. set scryfallCard. }
    public bool? Timeshifted { get scryfallCard. set scryfallCard. }
    public string Toughness { get scryfallCard. set scryfallCard. }
    public string TypeLine { get scryfallCard. set scryfallCard. }

    public string PrintsSearchUri { get scryfallCard. set scryfallCard. }
    public string RulingsUri { get scryfallCard. set scryfallCard. }
    public string ScryfallUri { get scryfallCard. set scryfallCard. }
    public string ScryfallSetUri { get scryfallCard. set scryfallCard. }
    public string SetUri { get scryfallCard. set scryfallCard. }
    public string SetSearchUri { get scryfallCard. set scryfallCard. }
    public string Uri { get scryfallCard. set scryfallCard. }

    public string ImageUriPng { get scryfallCard. set scryfallCard. }
    public string ImageUriBorderCrop { get scryfallCard. set scryfallCard. }
    public string ImageUriArtCrop { get scryfallCard. set scryfallCard. }
    public string ImageUriLarge { get scryfallCard. set scryfallCard. }
    public string ImageUriNormal { get scryfallCard. set scryfallCard. }
    public string ImageUriSmall { get scryfallCard. set scryfallCard. }

    public string RelatedUriTcgplayerDecks { get scryfallCard. set scryfallCard. }
    public string RelatedUriEdhrec { get scryfallCard. set scryfallCard. }
    public string RelatedUriMtgtop8 { get scryfallCard. set scryfallCard. }
    */

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }
        public Guid ScryfallId { get; set; }
        public Guid OracleId { get; set; }
        public string MultiverseId { get; set; }
        public int? MtgoId { get; set; }
        public int? MtgoFoilId { get; set; }
        public int? ArenaId { get; set; }
        public int? TcgplayerId { get; set; }
        public string CardName { get; set; }
        public string Lang { get; set; }
        public DateTimeOffset ReleasedAt { get; set; }
        public string Uri { get; set; }
        public string ScryfallUri { get; set; }
        public string Layout { get; set; }
        public bool HighresImage { get; set; }
        public string ImageUriPng { get; set; }
        public string ImageUriBorderCrop { get; set; }
        public string ImageUriArtCrop { get; set; }
        public string ImageUriLarge { get; set; }
        public string ImageUriNormal { get; set; }
        public string ImageUriSmall { get; set; }
        public string ManaCost { get; set; }
        public decimal Cmc { get; set; }
        public string TypeLine { get; set; }
        public string OracleText { get; set; }
        public string Colors { get; set; }
        public string ColorIdentity { get; set; }
        public string ColorIndicator { get; set; }
        public bool LegalityStandard { get; set; }
        public bool LegalityFuture { get; set; }
        public bool LegalityModern { get; set; }
        public bool LegalityLegacy { get; set; }
        public bool LegalityPauper { get; set; }
        public bool LegalityVintage { get; set; }
        public bool LegalityCommander { get; set; }
        public bool AvailablePaper { get; set; }
        public bool AvailableArena { get; set; }
        public bool AvailableMtgo { get; set; }
        public bool Reserved { get; set; }
        public bool Foil { get; set; }
        public bool Nonfoil { get; set; }
        public bool Oversized { get; set; }
        public bool Promo { get; set; }
        public bool Reprint { get; set; }
        public string SetCode { get; set; }
        public string SetName { get; set; }
        public string SetUri { get; set; }
        public string SetSearchUri { get; set; }
        public string ScryfallSetUri { get; set; }
        public string RulingsUri { get; set; }
        public string PrintsSearchUri { get; set; }
        public string CollectorNumber { get; set; }
        public bool Digital { get; set; }
        public string Rarity { get; set; }
        public string Watermark { get; set; }
        public Guid IllustrationId { get; set; }
        public string Artist { get; set; }
        public string BorderColor { get; set; }
        public string Frame { get; set; }
        public string FrameEffect { get; set; }
        public bool FullArt { get; set; }
        public bool StorySpotlight { get; set; }
        public string RelatedUriTcgplayerDecks { get; set; }
        public string RelatedUriEdhrec { get; set; }
        public string RelatedUriMtgtop8 { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string FlavorText { get; set; }
        public int? EdhrecRank { get; set; }
        public string Loyalty { get; set; }
    }
}