using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QA1_SYSTEM.Models
{
    public class FixedAssetEQP
    {
        [Key]
        public int EQPassetId { get; set; }

        [ForeignKey("EquipmentMachine")]
        public int EQPid { get; set; }
        public EquipmentMachine EquipmentMachine { get; set; }


        [DisplayName("Fixed Asset")]
        public string? fixed_asset_no { get; set; } = "";

        [DisplayName("Fixed Asset date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public string? fixed_asset_date { get; set; } = "";

        [DisplayName("Inventory Found")]
        public string? inventory_found { get; set; } = "";

        [DisplayName("Inventory Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public string? inventory_date { get; set; }

        [DisplayName("Inventory Year")]
        public string? inventory_year { get; set; }

        [DisplayName("Location")]
        public string? item_location { get; set; }

        [DisplayName("Picture")]
        public string? pic_path { get; set; }

        [NotMapped]
        public IFormFile _pathPic { get; set; }
    }
}
