using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CleverHouse
{
    public class Hoover : Device, IResetSettings, IUse, IChangeEnum, IHooverMark     //пылесос
    {
        private CleanLvl cleaning;
        private bool lamp;
        private bool beep;
        public bool StatusDustCollector { get; set; }
        public Hoover(bool status, string name, int dustCollector, int accumulator, CleanLvl cleaning)
            : base(status, name)
        {
            this.cleaning = cleaning;
            DustCollector = dustCollector;
            Accumulator = accumulator;
        }
        public int Accumulator { get; set; }
        public int DustCollector { get; set; }
        public void ResetFirstParameter() //очистка пылесборника
        {
            StatusDustCollector = false;
            lamp = false;
            DustCollector = 0;

        }
        public void ResetSecondParameter() //зарядка акамулятор
        {
            beep = false;
            Accumulator = 100;
        }
        public void Apply()
        {
            if (Status)
            {

                if (StatusDustCollector == true && cleaning == CleanLvl.DailyMode)
                {
                    for (int i = 0, j = 0; DustCollector <= 100 || Accumulator <= 0; i++, j++)
                    {
                        DustCollector += 2;
                        Accumulator -= 1;
                    }
                    if (DustCollector <= 100)
                    {
                        StatusDustCollector = false;
                        lamp = true;
                    }
                    if (Accumulator <= 0)
                    {
                        beep = true;
                    }
                }
                else if (StatusDustCollector == true && cleaning == CleanLvl.OutputMode)
                {
                    for (int i = 0, j = 0; DustCollector <= 100 || Accumulator <= 0; i++, j++)
                    {
                        DustCollector += 5;
                        Accumulator -= 2;
                    }
                    if (DustCollector <= 100)
                    {
                        StatusDustCollector = false;
                        lamp = true;
                    }
                    if (Accumulator <= 0)
                    {
                        beep = true;
                    }
                }
                else if (StatusDustCollector == true && cleaning == CleanLvl.QuickCleanMode)
                {
                    for (int i = 0, j = 0; DustCollector <= 100 || Accumulator <= 0; i++, j++)
                    {
                        DustCollector += 1;
                        Accumulator -= 3;
                    }
                    if (DustCollector <= 100)
                    {
                        StatusDustCollector = false;
                        lamp = true;
                    }
                    if (Accumulator <= 0)
                    {
                        beep = true;
                    }
                }
                else if (StatusDustCollector == true && cleaning == CleanLvl.TotalCleanMode)
                {
                    for (int i = 0, j = 0; DustCollector <= 100 || Accumulator <= 0; i++, j++)
                    {
                        DustCollector += 10;
                        Accumulator -= 5;
                    }
                    if (DustCollector <= 100)
                    {
                        StatusDustCollector = false;
                        lamp = true;
                    }
                    if (Accumulator <= 0)
                    {
                        beep = true;
                    }

                }
            }
        }
        public void NextEnum()
        {
            if (Status == true)
            {
                if ((int)cleaning < System.Enum.GetValues(typeof(CleanLvl)).Length - 1)
                {
                    cleaning++;
                }
                else { }
            }
        }
        public void PreviousEnum()
        {
            if (Status == true)
            {
                if ((int)cleaning > 0)
                {
                    cleaning--;
                }
                else { }
            }
        }
        public override string ToString()
        {
                        string statusDustCollector;
            if (StatusDustCollector)
            {
                statusDustCollector = "можно убирать";
            }
            else
            {
                statusDustCollector = "нуждается в очистке";
            }
           
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
            return base.ToString() + ";"+"\nCтатус пылесборника: " + statusDustCollector + "; Режим работы: " + cleaning.ToString() + ";"+"\nЗаполненность пылесборника: " + DustCollector + "%" + "; \nСостояние лампочки: " + lamp + "; Сигнал: " + beep + "\nСостояние акамулятора: " + Accumulator + "%" + "\n";
        }
    }
}
