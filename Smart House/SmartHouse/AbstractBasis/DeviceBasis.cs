using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public abstract class DeviceBasis : IPower
    { 
        public DeviceBasis(string nameDevice, bool powerStatus)
        {
            PowerStatus = powerStatus;
            NameDevice = nameDevice;
        }
        public bool PowerStatus { get; set; }
        public string NameDevice { get; set; }
        public virtual void СhangeTheStatusPower()
        {
            if (PowerStatus == true)
            {
                PowerStatus = false;
            }
            else if (PowerStatus == false)
            {
                PowerStatus = true;
            }
        }
        public override string ToString()
        {
            return "Name: " + NameDevice + "; Power Status: " + PowerStatus.ToString() +";";
        }
    }
}
