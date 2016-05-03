using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public interface IFridge
    {
        double TemperatureFridge { get; set; }
        void NextTempFridge();
        void PreviousTempFridge();

    }
}
