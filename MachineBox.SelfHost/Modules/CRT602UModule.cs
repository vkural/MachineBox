using MachineBox.Core.CardReaders;
using MachineBox.Core.Models;
using Nancy;

namespace MachineBox.SelfHost.Modules
{
    public class CRT602UModule : NancyModule
    {
        public CRT602UModule()
        {
            Get["/api/crt602u/read"] = parameters =>
            {
                var response = new CRT602UReader().Read();

                return Response.AsJson(new ApiResponse<string> {
                    Status  = (int)response.Status,
                    Message = response.X,
                    Data    = response.Data
                });
            };
        }
    }
}
