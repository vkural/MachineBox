using MachineBox.Core.Enums;

namespace MachineBox.Core.Models
{
    public class CardReaderResponse
    {
        public DeviceStatus Status { get; set; }
        public string       Data   { get; set; }
        public string X { get; set; }
    }
}