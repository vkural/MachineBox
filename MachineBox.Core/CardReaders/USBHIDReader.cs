using MachineBox.Core.Enums;
using MachineBox.Core.Globals;
using MachineBox.Core.Hooks;
using MachineBox.Core.Models;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace MachineBox.Core.CardReaders
{
    public class USBHIDReader
    {
        public CardReaderResponse Read()
        {
            var response = new CardReaderResponse { Status = DeviceStatus.FAILURE };
            var start    = DateTime.Now;

            try
            {
                USBHIDGlobal.Text = string.Empty;
                USBHIDGlobal.Wait = false;
            }
            catch(Exception e)
            {
                response.X = e.ToString();
                return response;
            }


            while (true)
            {
                if ((DateTime.Now - start).TotalSeconds >= int.Parse(ConfigurationManager.AppSettings["readTimeout"]))
                {
                    response.Status = DeviceStatus.TIMEOUT_EXPIRED;
                    break;
                }

                if (USBHIDGlobal.Wait)
                {
                    response.Status = DeviceStatus.SUCCESS;
                    response.Data   = USBHIDGlobal.Text;
                    break;
                }
            }

            USBHIDGlobal.Wait = true;

            return response;
        }

    }
}