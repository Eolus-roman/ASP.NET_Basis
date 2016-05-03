using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class Radioreceiver : DeviceBasis, ILoudness, IChannels
    {
        public Radioreceiver(string nameDevice, bool powerStatus, RadioChannels channel,
            int loudness, int stepLoudness)
            : base(nameDevice, powerStatus)
        {
            this.channel = channel;
            Loudness = loudness;
            StepLoudness = stepLoudness;
        }
        private RadioChannels channel;
        public int Loudness { get; set; }
        public int StepLoudness { get; set; }
        const int MaxLoudness = 100;
        const int MinLoudness = 0;
        public void NextChannel()
        {
            if (PowerStatus == true)
            {
                if ((int)channel < System.Enum.GetValues(typeof(TVChannels)).Length - 1)
                {
                    channel++;
                }
                else { }
            }
            else { }
        }
        public void PreviousChannel()
        {
            if (PowerStatus == true)
            {
                if ((int)channel > 0)
                {
                    channel--;
                }
            }
            else { }
        }
        public void ControlLoudness()
        {
            if (Loudness > MaxLoudness)
            {
                Loudness = MaxLoudness;
            }
            else if (Loudness < MinLoudness)
            {
                Loudness = MinLoudness;
            }
            else { }
        }
        public void UpLoudness()
        {
            if (PowerStatus == true)
            {
                if (Loudness < MaxLoudness && Loudness > MinLoudness)
                {
                    Loudness += StepLoudness;
                }
                else if (Loudness <= MinLoudness)
                {
                    Loudness = MinLoudness;
                }
                else
                {
                    Loudness = MaxLoudness;
                }
                ControlLoudness();
            }
            else { }
        }
        public void DownLoudness()
        {
            if (PowerStatus == true)
            {
                if (Loudness < MaxLoudness && Loudness > MinLoudness)
                {
                    Loudness -= StepLoudness;
                }
                else if (Loudness <= MinLoudness)
                {
                    Loudness = MinLoudness;
                }
                else
                {
                    Loudness = MaxLoudness;
                }
                ControlLoudness();
            }
            else { }
        }

        public override string ToString()
        {
            return base.ToString() + "\n Channel: " + channel.ToString()+ "; "+
                "Current Loudness: " + Loudness + ";";
        }
    }
}
