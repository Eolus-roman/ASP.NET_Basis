using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart_House;

namespace SmartHouse_WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        private IDictionary<int, Device> devicesDictionary;
        public ICreate Create { get; set; }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            }
            else
            {
                devicesDictionary = new SortedDictionary<int, Device>();
                Create = new CreateNew();

                devicesDictionary.Add(1, Create.NewFridge());
                devicesDictionary.Add(2, Create.NewHoover());
                devicesDictionary.Add(3, Create.NewBicycle());
                devicesDictionary.Add(4, Create.NewTV());
                devicesDictionary.Add(5, Create.NewGame());

                Session["Devices"] = devicesDictionary;
                Session["NextId"] = 6;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                addDevicesButton.Click += AddDevicesButtonClick;
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
        protected void AddDevicesButtonClick(object sender, EventArgs e)
        {
            Device newDevice;
            Create = new CreateNew();
            switch (dropDownDevicesList.SelectedIndex)
            {
                default:
                    newDevice = Create.NewFridge();
                    break;
                case 1:
                    newDevice = Create.NewHoover();
                    break;
                case 2:
                    newDevice = Create.NewBicycle();
                    break;
                case 3:
                    newDevice = Create.NewTV();
                    break;
                case 4:
                    newDevice = Create.NewGame();
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