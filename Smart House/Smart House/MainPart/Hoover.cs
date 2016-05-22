using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public class Hoover : Device, IResetSettings, IUse, IChangeEnum, IHooverMark     //пылесос
    {
        private CleanLvl cleaning;

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

            DustCollector = 0;

        }
        public void ResetSecondParameter() //зарядка акамулятор
        {
            Accumulator = 100;
        }
        public void Apply()
        {
            if (Status)
            {

                if (cleaning == CleanLvl.DailyMode)
                {
                    for (int i = 0, j = 0; DustCollector < 100 || Accumulator <= 0; i++, j++)
                    {
                        DustCollector += 2;
                        Accumulator -= 1;
                    }

                }
                else if (cleaning == CleanLvl.OutputMode)
                {
                    for (int i = 0, j = 0; DustCollector < 100 || Accumulator <= 0; i++, j++)
                    {
                        DustCollector += 5;
                        Accumulator -= 2;
                    }

                }
                else if (cleaning == CleanLvl.QuickCleanMode)
                {
                    for (int i = 0, j = 0; DustCollector < 100 || Accumulator <= 0; i++, j++)
                    {
                        DustCollector += 1;
                        Accumulator -= 3;
                    }

                }
                else if (cleaning == CleanLvl.TotalCleanMode)
                {
                    for (int i = 0, j = 0; DustCollector < 100 || Accumulator <= 0; i++, j++)
                    {
                        DustCollector += 10;
                        Accumulator -= 5;
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

            return base.ToString() + "; \nРежим работы: "
                + cleaning.ToString() + ";" + "\nЗаполненность пылесборника: " + DustCollector + "%;" + " Состояние акамулятора: " + Accumulator + "%" + "\n";
        }
    }
}
