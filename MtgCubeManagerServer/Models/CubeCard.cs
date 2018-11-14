using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtgCubeManagerServer.Models
{
    public class CubeCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CubeCardId { get; set; }

        [ForeignKey("Card")]
        public string CardId { get; set; }

        [ForeignKey("Cube")]
        public int CubeId { get; set; }

        //public Cube Cube { get; set; }

        //public Card Card { get; set; }

        public string CustomColorIdentity { get; set; }

        public int? CustomCmc { get; set; }

        public bool? IsFoil { get; set; }

        public bool? IsAltered { get; set; }

        public virtual Card Card { get; private set; }

        public virtual Cube Cube { get; private set; }
    }
}