using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public interface IBrightness
    {
        int Brightness { get; set; }
        int StepBrightness { get; set; }
        void UpBrightness();
        void DownBrightness();
        void ControlBrightness();

    }
}
