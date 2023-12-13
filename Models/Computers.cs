using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QA1_SYSTEM.Models
{
    public class Computers
    {
        [Key]
        public int ComputerId { get; set; }

        [DisplayName("Registration Date")]
        public string? date_reg { get; set; } = "";

        [DisplayName("Category")]
        public string? computer_category { get; set; } = "";

        [DisplayName("Processor Name")]
        public string? processor_name { get; set; } = "";

        [DisplayName("Memory Capactiy Installed")]
        public string? ram_capacity { get; set; } = "";

        [DisplayName("HDD Capacity Installed")]
        public string? hdd_capacty { get; set; } = "";

        [DisplayName("OS")]
        public string? os_installed { get; set; } = "";

        [DisplayName("IP-SDP")]
        public string? ip_sdp { get; set; } = "";

        [DisplayName("IP-Local")]
        public string? ip_local { get; set; } = "";

        [DisplayName("Active User")]
        public string? active_user { get; set; } = "";

        [DisplayName("Image")]
        public string? path_pic { get; set; } = "";

        [NotMapped]
        public IFormFile _pathPic { get; set; }

        public virtual List<ComputerHistory> ComputerHistory { get; set; } = new List<ComputerHistory>();
        public virtual List<FixedAssetPC> FixedAssetPC { get; set; } = new List<FixedAssetPC>();
    }
}
