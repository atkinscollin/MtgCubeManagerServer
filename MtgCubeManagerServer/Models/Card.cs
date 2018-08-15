using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MtgCubeManagerServer.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cmc { get; set; }
        public string ColorIdentity { get; set; }
        public string Colors { get; set; }
        public string ImageName { get; set; }
        public string Layout { get; set; }
        //public object legalities { get; set; }
        public string ManaCost { get; set; }
        public string Power { get; set; }
        public string Printings { get; set; }
        public string Subtypes { get; set; }
        public string Text { get; set; }
        public string Toughness { get; set; }
        public string Type { get; set; }
        public string Types { get; set; }
    }
}