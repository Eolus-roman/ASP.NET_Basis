using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public interface IVolume
    {
        int CurrentVolume { get; set; }
        void PlusVolume();
        void MinusVolume();
        void Mute();
    }
}
