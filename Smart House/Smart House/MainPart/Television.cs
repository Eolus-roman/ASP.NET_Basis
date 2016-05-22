using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public class Television : Device, IChangeEnum, IVolume, ITelevisionMark
    {
        private int currentVolume; // текущая громкость
        private TVChannels channel;
        const int MinVoluve = 0;
        const int MaxVolume = 100;
        public Television(bool status, string name, TVChannels channel, int currentVolume)
            : base(status, name)
        {
            this.channel = channel;
            CurrentVolume = currentVolume;
        }
        public int MaxChannel { get; set; }
        public int ChannelNumber { get; set; }
        public int CurrentVolume
        {
            get
            {
                return currentVolume;
            }
            set
            {
                if (value >= MinVoluve && value <= MaxVolume)
                {
                    currentVolume = value;
                }
            }
        }
        public override void On()
        {
            if (Status == false)
            {
                Status = true;

            }
        }
        public void PlusVolume()
        {
            if (Status)
            {
                if (CurrentVolume < 100)
                {
                    CurrentVolume += 5;
                }
            }
        }
        public void MinusVolume()
        {
            if (Status)
            {
                if (CurrentVolume > 0)
                {
                    CurrentVolume -= 5;
                }
            }
        }
        public void Mute()
        {
            if (Status)
            {
                CurrentVolume = 0;
            }
        }

        public void NextEnum()
        {
            if (Status)
            {
                if ((int)channel < System.Enum.GetValues(typeof(TVChannels)).Length - 1)
                {
                    channel++;
                }
                else { }
            }
        }
        public void PreviousEnum()
        {
            if (Status)
            {
                if ((int)channel > 0)
                {
                    channel--;
                }
                else { }
            }
        }
        public void SetVolume(int input)
        {
            if (Status)
            {
                CurrentVolume = input;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "; громкость: " + CurrentVolume + "; текущий канал: " + channel.ToString() + ";\n";
        }
    }
}
