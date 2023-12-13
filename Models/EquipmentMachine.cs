using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace QA1_SYSTEM.Models
{
    public class EquipmentMachine
    {
        [Key]
        public int EQPid { get; set; }

        [Required]
        [DisplayName("Request Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public string? date_reg { get; set; }

        [Required]
        [DisplayName("Category")]
        public string? equipment_category { get; set; } = "";

        [Required]
        [DisplayName("Part Number")]
        public string? part_number { get; set; } = "";

        [Required]
        [DisplayName("Description")]
        public string? description { get; set; } = "";

        [Required]
        [DisplayName("Machine Type")]
        public string? machine_type { get; set; } = "";

        [Required]
        [DisplayName("Active User")]
        public string? active_user { get; set; } = "";

        [DisplayName("Image")]
        public string? path_pic { get; set; } = "";

        [NotMapped]
        public IFormFile _pathPic { get; set; }


        public List<EquipmentMachineHistory> equipmentMachineHistory { get; set; } = new List<EquipmentMachineHistory>();
        public List<FixedAssetEQP> fixedAssetEQP { get; set; } = new List<FixedAssetEQP>();
    }
}
