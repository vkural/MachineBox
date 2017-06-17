using MachineBox.Core.CardReaders;
using MachineBox.Core.Models;
using Nancy;

namespace MachineBox.SelfHost.Modules
{
    public class USBHIDModule : NancyModule
    {
        public USBHIDModule()
        {
            Get["/api/usbhid/read"] = parameters =>
            {
                var response = new USBHIDReader().Read();

                return Response.AsJson(new ApiResponse<string> {
                    Status  = (int)response.Status,
                    Message = response.Status.ToString(),
                    Data    = response.Data
                });
            };
        }
    }
}
