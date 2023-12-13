using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QA1_SYSTEM.Models
{
    public class Consumables
    {
        [Key]
        public int ConsumbleId { get; set; }

        [Required]
        [DisplayName("Request Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? date_reg { get; set; }

        [Required]
        [DisplayName("Category")]
        public string? item_category { get; set; } = "";

        [Required]
        [DisplayName("Part Number")]
        public string? part_number { get; set; } = "";

        [Required]
        [DisplayName("Description/Specs")]
        public string? item_description { get; set; } = "";

        [Required]
        [DisplayName("Maker")]
        public string? maker { get; set; } = "";

        [Required]
        [DisplayName("Supplier")]
        public string? supplier { get; set; } = "";


        [DisplayName("Total quantity")]
        public string? total_qty { get; set; } = "";

        [Required]
        [DisplayName("Consumable stocks")]
        public string? consum_qty { get; set; } = "";

        [Required]
        [DisplayName("Safety stocks")]
        public string? safety_qty { get; set; } = "";

        [Required]
        [DisplayName("Unit")]
        public string? item_unit { get; set; } = "";

        [DisplayName("Unit price")]
        public string? unit_price { get; set; } = "";

        [DisplayName("Total price")]
        public string? total_price { get; set; } = "";

        [Required]
        [DisplayName("Remarks")]
        public string? item_remarks { get; set; } = "";

        [DisplayName("Currency")]
        public string? currency { get; set; } = "";

        [DisplayName("Picture")]
        public string? item_picture { get; set; } = "";

        [NotMapped]
        public IFormFile _pathPic { get; set; }

        //public virtual ICollection<Requestor>? Requestor { get; set; }
        public virtual List<Requestor> Requestor { get; set; } = new List<Requestor>();
    }
}
