using SmartHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace WebFormSmartHouse
{
    public partial class Default : System.Web.UI.Page
    {
        private IDictionary<int, DeviceBasis> devicesDictionary;
        public ICreate CSH { get; set; }
        Assembly modelAssembly = Assembly.Load("SmartHouse");
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                devicesDictionary = new SortedDictionary<int, DeviceBasis>();
                CSH = new CreateSmartDevices();
                devicesDictionary.Add(1, CSH.CreateTelevision());
                devicesDictionary.Add(2, CSH.CreateRadioreceiver());
                devicesDictionary.Add(3, CSH.CreateFridge());

                Session["Devices"] = devicesDictionary;
                Session["NextId"] = 4;
            }
            else
            {
                devicesDictionary = (SortedDictionary<int, DeviceBasis>)Session["Devices"];
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                addDevicesButton.Click += AddClick;
            }
            InitialiseDevicesPanel();
        }


        protected void InitialiseDevicesPanel()
        {
            foreach (int key in devicesDictionary.Keys)
            {
                devicesPanel.Controls.Add(new DeviceControl(key, devicesDictionary));
            }
        }

        protected void AddClick(object sender, EventArgs e)
        {
            DeviceBasis newDevice;
            CSH = new CreateSmartDevices();
            switch (DropDownListDevices.SelectedIndex)
            {
                default:
                    newDevice = CSH.CreateTelevision();
                    break;
                case 1:
                    newDevice = CSH.CreateRadioreceiver();
                    break;
                case 2:
                    newDevice = CSH.CreateFridge();
                    break;
            }
            int id = (int)Session["NextId"];
            devicesDictionary.Add(id, newDevice); // Добавление девайса в коллекцию
            devicesPanel.Controls.Add(new DeviceControl(id, devicesDictionary)); // Добавление графики для девайса
            id++;
            Session["NextId"] = id;
        }
    }
}