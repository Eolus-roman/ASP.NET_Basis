using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class Menu
    {
        private IDictionary<int, DeviceBasis> DevicesDictionary = new Dictionary<int, DeviceBasis>();
        public ICreate CSH { get; set; }

        public void Show()
        {
            CSH = new CreateSmartDevices();
            DevicesDictionary.Add(1, CSH.CreateTelevision());
            DevicesDictionary.Add(2, CSH.CreateRadioreceiver());
            DevicesDictionary.Add(3, CSH.CreateFridge());

            foreach (var dev in DevicesDictionary)
            {
                Console.WriteLine(dev.Key + ", " + dev.Value.ToString() + "\n");
            }
            Console.WriteLine();
            Console.Write("Введите команду: ");

        }
    }
}
