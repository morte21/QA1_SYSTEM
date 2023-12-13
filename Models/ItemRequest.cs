using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QA1_SYSTEM.Models
{
    public class ItemRequest
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Request Date")]
        public string? req_date { get; set; } = "";

        [DisplayName("Description & Specification")]
        public string? description { get; set; } = "";

        [DisplayName("Request quantity")]
        public string? req_qty { get; set; } = "";

        [DisplayName("Reason | Purpose of request")]
        public string? reason { get; set; } = "";

        [DisplayName("Requestor Name")]
        public string? requestor { get; set; } = "";

        [DisplayName("Status")]
        public string? status { get; set; } = "";


    }
}
