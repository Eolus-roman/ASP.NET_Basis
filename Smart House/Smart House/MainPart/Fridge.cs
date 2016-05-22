using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public class Fridge : Device, IOpenOrClose, IChangeEnum, IFridgeMark
    {
        private bool lamp; // состояние лампочки
        private bool beep; // // сигнал
        private TemperatureLvl freeze; // режимы заморозки
        private double temperature; // значение температуры

        public Fridge(bool status, string name, bool statusDoor, double temperature, TemperatureLvl freeze)
            : base(status, name)
        {
            this.freeze = freeze;
            StatusOpen = statusDoor;
            Temperature = temperature;
        }
        public bool StatusOpen { get; set; }
        public double Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                temperature = value;
            }
        }
        public void Open()
        {
            if (StatusOpen == false)
            {
                StatusOpen = true;
                lamp = true;
                if (Temperature <= 6)
                {
                    beep = true;
                }
            }
        }
        public void Close()
        {
            if (StatusOpen)
            {
                StatusOpen = false;
                lamp = false;
                beep = false;
            }
        }

        public void NextEnum()
        {
            if (Status)
            {
                if ((int)freeze < System.Enum.GetValues(typeof(TemperatureLvl)).Length - 1)
                {
                    freeze++;
                    if ((int)freeze == 0)
                    {
                        Temperature = 3;
                    }
                    else if ((int)freeze == 1)
                    {
                        Temperature = -5;
                    }
                    else if ((int)freeze == 2)
                    {
                        Temperature = -15;
                    }
                    else if ((int)freeze == 3)
                    {
                        Temperature = 10;
                    }
                }
            }
        }
        public void PreviousEnum()
        {
            if ((int)freeze > 0)
            {
                freeze--;
                if ((int)freeze == 0)
                {
                    Temperature = 3;
                }
                else if ((int)freeze == 1)
                {
                    Temperature = -5;
                }
                else if ((int)freeze == 2)
                {
                    Temperature = -15;
                }
                else if ((int)freeze == 3)
                {
                    Temperature = 10;
                }
            }
        }

        public override string ToString()
        {
            
            string lamp;
            if (this.lamp)
            {
                lamp = "светится";
            }
            else
            {
                lamp = "не светится";
            }
                        string beep;
            if (this.beep)
            {
                beep = "пиликает";
            }
            else
            {
                beep = "молчит";
            }
                        return base.ToString() + ";" + "\nCтатус двери: " + StatusOpen.ToString() + "; Режим работы: " + freeze.ToString() + ";" + "\nЗначение температуры: " + Temperature + "; \nСостояние лампочки: " + lamp + "; Сигнал: " + beep + ";\n";
        }
    }
}
