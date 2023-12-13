using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QA1_SYSTEM.Models
{
    public class EquipmentMachineHistory
    {
        [Key]
        public int EqpMacId { get; set; }

        [ForeignKey("EquipmentMachine")]
        public int EQPid { get; set; }
        public EquipmentMachine EquipmentMachine { get; set; }

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
