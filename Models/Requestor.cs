using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QA1_SYSTEM.Models
{
    public class Requestor
    {
        [Key]
        public int RequestId { get; set; }

        [ForeignKey("Consumables")]
        public int ConsumbleId { get; set; }
        public Consumables Consumables { get; set; }

        [Required]
        [DisplayName("Request Date")]
        public DateTime? request_ate { get; set; }

        [Required]
        [DisplayName("Part Number")]
        public string? part_number { get; set; } = "";

        [Required]
        [DisplayName("Description/Specs")]
        public string? item_description { get; set; } = "";

        [Required]
        [DisplayName("Request quantity")]
        public string? request_qty { get; set; } = "";

        [Required]
        [DisplayName("Requestor")]
        public string? requestor_name { get; set; } = "";

        [Required]
        [DisplayName("Remarks")]
        public string? reason_request { get; set; } = "";

        

    }
}
