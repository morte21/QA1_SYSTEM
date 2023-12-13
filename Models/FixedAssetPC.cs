using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QA1_SYSTEM.Models
{
    public class FixedAssetPC
    {
        [Key]
        public int FixedAssetPCId { get; set; }

        [ForeignKey("Computers")]
        public int ComputerId { get; set; }
        public Computers Computers { get; set; }

        [Required]
        [DisplayName("Fixed Asset")]
        public string? fixed_asset_no { get; set; } = "";

        [Required]
        [DisplayName("Fixed Asset date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public string? fixed_asset_date { get; set; } = "";

        [Required]
        [DisplayName("Inventory Found")]
        public string? inventory_found { get; set; } = "";

        [Required]
        [DisplayName("Inventory Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public string? inventory_date { get; set; } = "";

        [Required]
        [DisplayName("Inventory Year")]
        public string? inventory_year { get; set; } = "";

        [Required]
        [DisplayName("Location")]
        public string? item_location { get; set; } = "";

        [DisplayName("Picture")]
        public string? pic_path { get; set; } = "";

        [NotMapped]
        public IFormFile _pathPic { get; set; }

    }
}
