using QA1_SYSTEM.Controllers;

namespace QA1_SYSTEM.Models
{
    public class Global
    {
        public Computers Computers { get; set; }
        public ComputerHistory ComputerHistory { get; set; }
        public Consumables Consumables { get; set; }
        public EquipmentMachine EquipmentMachine { get; set; }
        public EquipmentMachineHistory EquipmentMachineHistory { get; set; }
        public FixedAssetEQP FixedAssetEQP { get; set; }
        public FixedAssetPC FixedAssetPC { get; set; }
        public ItemRequest ItemRequest { get; set; }
        public Purchasing Purchasing { get; set; }
        public Requestor Requestor { get; set; }

        public int totalComputersCount { get; set; }
        public int totalEqpCount { get; set; }

        public int totalArrivalCount { get; set; }
        public int totalApprovalCount { get; set; }

        public int totalReceivedCount { get; set; }

        public int totalStocksCount { get; set; }



        public IEnumerable<Computers> computers { get; set; }
        public IEnumerable<ComputerHistory> computerHistory { get; set; }
        public IEnumerable<Consumables> consumables { get; set; }
        public IEnumerable<EquipmentMachine> equipmentMachine { get; set; }
        public IEnumerable<EquipmentMachineHistory> equipmentMachineHistory { get; set; }
        public IEnumerable<FixedAssetEQP> fixedAssetEQP { get; set; }
        public IEnumerable<FixedAssetPC> fixedAssetPC { get; set; }
        public IEnumerable<ItemRequest> itemRequest { get; set; }
        public IEnumerable<Purchasing> purchasing { get; set; }
        public IEnumerable<Requestor> requestor { get; set; }

       
    }
}
