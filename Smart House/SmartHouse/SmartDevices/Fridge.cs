using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class Fridge : DeviceBasis, IFridge, IFreezer
    {

        public Fridge(string nameDevice, bool powerStatus, bool powerStatusFreezer,
            double temperatureFridge, double temperatureFreezer)
            : base(nameDevice, powerStatus)
        {
            TemperatureFridge = temperatureFridge;
            TemperatureFreezer = temperatureFreezer;
            PowerStatusFreezer = powerStatusFreezer;
        }
        public bool PowerStatusFreezer { get; set; }
        public double TemperatureFridge {get; set;}

        public double TemperatureFreezer { get; set; }
        public override void СhangeTheStatusPower()
        {
            if (PowerStatus == true)
            {
                PowerStatus = false;
                PowerStatusFreezer = false;

            }
            else if (PowerStatus == false)
            {
                PowerStatus = true;
            }
        }
        public void ChangeThePowerStatusFreezer()
        {
            if (PowerStatusFreezer == false && PowerStatus == true)
            {
                PowerStatusFreezer = true;
            }
            else if (PowerStatusFreezer == true && PowerStatus == true)
            {
                PowerStatusFreezer = false;
            }
        }
        public void NextTempFridge()
        {
            if (PowerStatus == true)
            {
                if (TemperatureFridge < 10)
                {
                    TemperatureFridge++;
                }
                else { }
            }
            else { }
        }
        public void PreviousTempFridge()
        {
            if (PowerStatus == true)
            {
                if (TemperatureFridge > -5)
                {
                    TemperatureFridge--;
                }
                else { }
            }
            else { }
        }
        public void NextTempFreezer()
        {
            if (PowerStatus == true && PowerStatusFreezer == true)
            {
                if (TemperatureFreezer < -5)
                {
                    TemperatureFreezer++;
                }
                else { }
            }
            else { }
        }
        public void PreviousTempFreezer()
        {
            if (PowerStatus == true && PowerStatusFreezer == true)
            {
                if (TemperatureFreezer > -25)
                {
                    TemperatureFreezer--;
                }
                else { }
            }
            else { }
        }
        public override string ToString()
        {
            return base.ToString() +
                "\nPower Status Freezer: " + PowerStatusFreezer.ToString() + ";"
                + "\nTemperature Fridge: " + TemperatureFridge + ";"
                + "\nTemperature Freezer: " + TemperatureFreezer + ";";

        }

    }
}
