using MachineBox.Core.CardReaders;
using MachineBox.Core.Enums;
using MachineBox.Core.Models;
using Nancy;
using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace MachineBox.SelfHost.Modules
{
    public class MachineModule : NancyModule
    {
        public MachineModule()
        {
            Get["/api/machine/info"] = parameters =>
            {
                var result = new ApiResponse<InformationModel> { Status = (int)DeviceStatus.SUCCESS };

                try
                {
                    var activeNI = NetworkInterface.GetAllNetworkInterfaces()
                                                   .Where(x => x.NetworkInterfaceType != NetworkInterfaceType.Loopback
                                                            && x.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                                                            && x.OperationalStatus    == OperationalStatus   .Up
                                                            && !x.Name.StartsWith     ("vEthernet"  )
                                                            && !x.Description.Contains("Hyper-v"    )
                                                            && !x.Description.Contains("Check Point")).SingleOrDefault();

                    result.Data = new InformationModel
                    {
                        UserName    = Environment.UserName,
                        MachineName = Environment.MachineName,
                        DomainName  = IPGlobalProperties.GetIPGlobalProperties().DomainName,
                        MacAddress  = activeNI?.GetPhysicalAddress().ToString() ?? string.Empty,
                        IpAddress   = activeNI?.GetIPProperties   ().UnicastAddresses.Where(x => x.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).SingleOrDefault()?.Address.ToString() ?? string.Empty ?? string.Empty
                    };
                }
                catch (Exception e)
                {
                    result.Status = (int)DeviceStatus.FAILURE;
                    result.Message = e.Message;
                }

                return Response.AsJson(result);
            };
        }
    }
}
