namespace MtgCubeManagerServer.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class ScryfallBulkData
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("compressed_size")]
        public long CompressedSize { get; set; }

        [JsonProperty("permalink_uri")]
        public Uri PermalinkUri { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("content_encoding")]
        public string ContentEncoding { get; set; }
    }
}
