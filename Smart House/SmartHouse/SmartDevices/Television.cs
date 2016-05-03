using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class Television : DeviceBasis, IBrightness, IChannels, ILoudness, IAspectRatio
    {
        public Television(string nameDevice, bool powerStatus, TVChannels channel,
            AspectRatio aspectRat, int loudness, int stepLoudness,
            int brightness, int stepBrightness)
            : base(nameDevice, powerStatus)
        {
            this.channel = channel;
            this.aspectRat = aspectRat;
            Loudness = loudness;
            StepLoudness = stepLoudness;
            Brightness = brightness;
            StepBrightness = stepBrightness;

        }
        public int Loudness { get; set; }
        public int StepLoudness { get; set; }
        public int Brightness { get; set; }
        public int StepBrightness { get; set; }

        private TVChannels channel;
        private AspectRatio aspectRat;
        const int MaxBrightness = 100;
        const int MinBrightness = 0;
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
                else { }
            }
            else { }
        }
        public void ControlBrightness()
        {
            if (PowerStatus == true)
            {
                if (Brightness > MaxBrightness)
                {
                    Brightness = MaxBrightness;
                }
                else if (Brightness < MinBrightness)
                {
                    Brightness = MinBrightness;
                }
                else { }
            }
            else { }
        }
        public void UpBrightness()
        {
            if (PowerStatus == true)
            {
                if (Brightness < MaxBrightness && Brightness > MinBrightness)
                {
                    Brightness += StepBrightness;
                }
                else if (Brightness <= MinBrightness)
                {
                    Brightness = MinBrightness;
                }
                else
                {
                    Brightness = MaxBrightness;
                }
                ControlBrightness();
            }
            else { }
        }
        public void DownBrightness()
        {
            if (PowerStatus == true)
            {
                if (Brightness < MaxBrightness && Brightness > MinBrightness)
                {
                    Brightness -= StepBrightness;
                }
                else if (Brightness <= MinBrightness)
                {
                    Brightness = MinBrightness;
                }
                else
                {
                    Brightness = MaxBrightness;
                }
                ControlBrightness();
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
        public void NextAspectRatio()
        {
            if (PowerStatus == true)
            {
                if ((int)aspectRat < System.Enum.GetValues(typeof(AspectRatio)).Length - 1)
                {
                    aspectRat++;
                }
                else { }
            }
            else { }
        }
        public void PreviousAspectRatio()
        {
            if (PowerStatus == true)
            {
                if ((int)aspectRat > 0)
                {
                    aspectRat--;
                }
                else { }
            }
            else { }
        }
        public override string ToString()
        {
            return base.ToString() +
                "\nChannel: " + channel.ToString() + "; " + "Aspect Ratio: " + aspectRat.ToString() + ";" +
                "\nCurrent Loudness: " + Loudness + "; " + "Current Brightness: " + Brightness + ";";
        }
    }
}
