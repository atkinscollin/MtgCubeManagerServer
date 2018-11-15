using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MtgCubeManagerServer.Models
{
    public class Cube
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CubeId { get; set; }

        [Required]
        [MaxLength(50)] // TODO - Implement on frontend
        public string CubeName { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public string CreatedById { get; set; }
        
        public DateTime UpdatedDate { get; set; }

        public string UpdatedById { get; set; }

        public virtual ICollection<CubeCard> CubeCards { get; set; }
    }
}