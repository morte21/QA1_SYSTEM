using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QA1_SYSTEM.Models
{
    public class ComputerHistory
    {
        [Key]
        public int CompHistoryId { get; set; }

        [ForeignKey("Computers")]
        public int ComputerId { get; set; }
        public Computers Computers { get; set; }

        [Required]
        [DisplayName("Trouble Encounter")]
        public string? trouble_encounter { get; set; } = "";

        [Required]
        [DisplayName("Date Encounter")]
        public string? trouble_date { get; set; } = "";

        [Required]
        [DisplayName("Remarks")]
        public string? remarks { get; set; } = "";
    }
}
