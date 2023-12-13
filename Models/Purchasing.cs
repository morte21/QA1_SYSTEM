using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace QA1_SYSTEM.Models
{
    public class Purchasing
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Request Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? date_request { get; set; }

        [Required]
        [DisplayName("Purchase Department")]
        public string? purchase_dept { get; set; } = "";

        [Required]
        [DisplayName("Category")]
        public string? category { get; set; } = "";

        [Required]
        [DisplayName("Part number")]
        public string? part_number { get; set; } = "";

        [Required]
        [DisplayName("Description")]
        public string? item_description { get; set; } = "";

        [Required]
        [DisplayName("Maker")]
        public string? maker { get; set; } = "";

        [Required]
        [DisplayName("Supplier")]
        public string? supplier { get; set; } = "";

        [Required]
        [DisplayName("Request Qty")]
        public string? request_qty { get; set; } = "";

        [Required]
        [DisplayName("Unit")]
        public string? request_unit { get; set; } = "";

        [Required]
        [DisplayName("Unit Price")]
        public string? unit_price { get; set; } = "";

        [Required]
        [DisplayName("Total Price")]
        public string? total_price { get; set; } = "";

        [Required]
        [DisplayName("Currency")]
        public string? item_currency { get; set; } = "";

        [Required]
        [DisplayName("Remarks")]
        public string? request_reason { get; set; } = "";

        [Required]
        [DisplayName("Purchase Status")]
        public string? request_status { get; set; } = "";

        [Required]
        [DisplayName("Submit Request date")]
        public string? date_submitPR { get; set; } = "";


        [DisplayName("Person Received")]
        public string? person_submitPR { get; set; } = "";

        
        [DisplayName("Purchase Order")]
        public string? purchase_order { get; set; } = "";

        
        [DisplayName("Purchase Order Doc")]
        public string? po_path { get; set; } = "";

        [NotMapped]
        public IFormFile _pathDoc { get; set; }

        
        [DisplayName("ETA")]
        public string? est_time_arrival { get; set; } = "";

        [DisplayName("Date Needed")]
        public string? date_needed { get; set; } = "";

        [DisplayName("Date Received")]
        public string? date_received { get; set; } = "";

        [DisplayName("Received Quantity")]
        public string? received_qty { get; set; } = "";

        [DisplayName("Comment")]
        public string? item_comment { get; set; } = "";

        [DisplayName("Purchase Request Number")]
        public string? pr_number { get; set; } = "";

        [DisplayName("Purchase Request DOC")]
        public string? pr_path { get; set; } = "";

        [NotMapped]
        public IFormFile _pathDoc2 { get; set; }
    }
}
