﻿namespace MtgCubeManagerServer.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class ScryfallCard
    {
        [JsonProperty("object")]
        public Object Object { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("oracle_id")]
        public Guid OracleId { get; set; }

        [JsonProperty("multiverse_ids")]
        public List<string> MultiverseIds { get; set; }

        [JsonProperty("mtgo_id")]
        public int? MtgoId { get; set; }

        [JsonProperty("mtgo_foil_id")]
        public int? MtgoFoilId { get; set; }

        [JsonProperty("arena_id")]
        public int? ArenaId { get; set; }

        [JsonProperty("tcgplayer_id")]
        public int? TcgplayerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("released_at")]
        public DateTimeOffset ReleasedAt { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("scryfall_uri")]
        public Uri ScryfallUri { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("highres_image")]
        public bool HighresImage { get; set; }

        [JsonProperty("image_uris")]
        public ImageUris ImageUris { get; set; }

        [JsonProperty("mana_cost")]
        public string ManaCost { get; set; }

        [JsonProperty("cmc")]
        public decimal Cmc { get; set; }

        [JsonProperty("type_line")]
        public string TypeLine { get; set; }

        [JsonProperty("oracle_text")]
        public string OracleText { get; set; }

        [JsonProperty("colors")]
        public List<string> Colors { get; set; }

        [JsonProperty("color_identity")]
        public List<string> ColorIdentity { get; set; }

        [JsonProperty("color_indicator")]
        public List<string> ColorIndicator { get; set; }

        [JsonProperty("legalities")]
        public Legalities Legalities { get; set; }

        [JsonProperty("games")]
        public List<string> Games { get; set; }

        [JsonProperty("reserved")]
        public bool Reserved { get; set; }

        [JsonProperty("foil")]
        public bool Foil { get; set; }

        [JsonProperty("nonfoil")]
        public bool Nonfoil { get; set; }

        [JsonProperty("oversized")]
        public bool Oversized { get; set; }

        [JsonProperty("promo")]
        public bool Promo { get; set; }

        [JsonProperty("reprint")]
        public bool Reprint { get; set; }

        [JsonProperty("set")]
        public string Set { get; set; }

        [JsonProperty("set_name")]
        public string SetName { get; set; }

        [JsonProperty("set_uri")]
        public Uri SetUri { get; set; }

        [JsonProperty("set_search_uri")]
        public Uri SetSearchUri { get; set; }

        [JsonProperty("scryfall_set_uri")]
        public Uri ScryfallSetUri { get; set; }

        [JsonProperty("rulings_uri")]
        public Uri RulingsUri { get; set; }

        [JsonProperty("prints_search_uri")]
        public Uri PrintsSearchUri { get; set; }

        [JsonProperty("collector_number")]
        public string CollectorNumber { get; set; }

        [JsonProperty("digital")]
        public bool Digital { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("watermark")]
        public string Watermark { get; set; }

        [JsonProperty("illustration_id")]
        public Guid IllustrationId { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("border_color")]
        public string BorderColor { get; set; }

        [JsonProperty("frame")]
        public string Frame { get; set; }

        [JsonProperty("frame_effect")]
        public string FrameEffect { get; set; }

        [JsonProperty("full_art")]
        public bool FullArt { get; set; }

        [JsonProperty("story_spotlight")]
        public bool StorySpotlight { get; set; }

        [JsonProperty("related_uris")]
        public RelatedUris RelatedUris { get; set; }

        [JsonProperty("power")]
        public string Power { get; set; }

        [JsonProperty("toughness")]
        public string Toughness { get; set; }

        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty("edhrec_rank")]
        public int? EdhrecRank { get; set; }

        [JsonProperty("loyalty")]
        public string Loyalty { get; set; }
    }

    public partial class ImageUris
    {
        [JsonProperty("small")]
        public Uri Small { get; set; }

        [JsonProperty("normal")]
        public Uri Normal { get; set; }

        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("png")]
        public Uri Png { get; set; }

        [JsonProperty("art_crop")]
        public Uri ArtCrop { get; set; }

        [JsonProperty("border_crop")]
        public Uri BorderCrop { get; set; }
    }

    public partial class Legalities
    {
        [JsonProperty("standard")]
        public string Standard { get; set; }

        [JsonProperty("future")]
        public string Future { get; set; }

        [JsonProperty("frontier")]
        public string Frontier { get; set; }

        [JsonProperty("modern")]
        public string Modern { get; set; }

        [JsonProperty("legacy")]
        public string Legacy { get; set; }

        [JsonProperty("pauper")]
        public string Pauper { get; set; }

        [JsonProperty("vintage")]
        public string Vintage { get; set; }

        [JsonProperty("penny")]
        public string Penny { get; set; }

        [JsonProperty("commander")]
        public string Commander { get; set; }

        [JsonProperty("1v1")]
        public string The1V1 { get; set; }

        [JsonProperty("duel")]
        public string Duel { get; set; }

        [JsonProperty("brawl")]
        public string Brawl { get; set; }
    }

    public partial class RelatedUris
    {
        [JsonProperty("tcgplayer_decks")]
        public Uri TcgplayerDecks { get; set; }

        [JsonProperty("edhrec")]
        public Uri Edhrec { get; set; }

        [JsonProperty("mtgtop8")]
        public Uri Mtgtop8 { get; set; }
    }
}
