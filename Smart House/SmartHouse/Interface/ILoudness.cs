using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public interface ILoudness
    {
        int StepLoudness { get; set; }
        int Loudness { get; set; }
        void ControlLoudness();
        void UpLoudness();
        void DownLoudness();
    }
}
