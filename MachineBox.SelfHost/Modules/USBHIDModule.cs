using MachineBox.Core.CardReaders;
using MachineBox.Core.Models;
using MachineBox.SelfHost.Abstractions;
using Nancy;

namespace MachineBox.SelfHost.Modules
{
    public class USBHIDModule : BaseModule
    {
        public USBHIDModule(): base("/api/usbhid/read")
        {
            Get["/api/usbhid/read"] = parameters =>
            {
                var response = new USBHIDReader().Read();

                return Response.AsJson(new ApiResponse<string> {
                    Status  = (int)response.Status,
                    Message = response.Status.ToString(),
                    Data    = response.Data
                }).WithHeader("Access-Control-Allow-Origin", "*");
            };
        }
    }
}
