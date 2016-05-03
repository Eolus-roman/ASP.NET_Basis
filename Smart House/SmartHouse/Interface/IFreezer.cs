using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public interface IFreezer
    {
        bool PowerStatusFreezer { get; set; }
        double TemperatureFreezer { get; set; }
        void ChangeThePowerStatusFreezer();
        void NextTempFreezer();
        void PreviousTempFreezer();

    }
}
