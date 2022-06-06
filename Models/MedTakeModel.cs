using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedManager.Models
{
    [Table("Medtakes")]
    public class MedTakeModel
    {
        [Key]
        public int MedId { get; set; }
        [DisplayName("Nazwa leku")]
        [Required(ErrorMessage = "Nazwa leku jest wymagana.")]
        [MaxLength(50)]
        public string? Name { get; set; }
        [DisplayName("Dawka")]
        [Required(ErrorMessage = "Dawka leku jest wymagana.")]
        [MaxLength(2000)]
        public string? Dose { get; set; }
        [DisplayName("Godzina")]
        [MaxLength(50)]
        public string? Hour { get; set; }
        public bool Done { get; set; }

        }
}
