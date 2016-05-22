using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public interface IChannel
    {
        int MaxChannel { get; set; }
        void NextChannel();
        void PreviousChannel();
        void GoToChannel(int input);
    }
}
