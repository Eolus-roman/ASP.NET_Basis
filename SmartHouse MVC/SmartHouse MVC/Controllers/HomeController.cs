using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart_House;

namespace SmartHouse_MVC.Controllers
{
    public class HomeController : Controller
    {
        IChangeEnum ice;
        IVolume iv;
        IOpenOrClose iooc;
        IResetSettings irs;
        ISpeed isp;
        IUse iu;
        //
        // GET: /CleverHouse/
        public ActionResult Index()
        {
            IDictionary<int, Device> devicesDictionary;
            ICreate Create;

            if (Session["Devices"] == null)
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
            else
            {
                devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            }

            SelectListItem[] devicesList = new SelectListItem[5];
            devicesList[0] = new SelectListItem { Text = "Fridge", Value = "FR", Selected = true };
            devicesList[1] = new SelectListItem { Text = "Hoover", Value = "HO" };
            devicesList[2] = new SelectListItem { Text = "Bicycle", Value = "BI" };
            devicesList[3] = new SelectListItem { Text = "Television", Value = "TV" };
            devicesList[4] = new SelectListItem { Text = "Warhammer", Value = "WH" };
            ViewBag.DevicesList = devicesList;
            ViewBag.Title = "Smart House MVC";

            return View(devicesDictionary);
        }
        public ActionResult Add(string deviceType)
        {
            Device newDevice;
            ICreate Create = new CreateNew();
            switch (deviceType)
            {
                default:
                    newDevice = Create.NewFridge();
                    break;
                case "HO":
                    newDevice = Create.NewHoover();
                    break;
                case "BI":
                    newDevice = Create.NewBicycle();
                    break;
                case "TV":
                    newDevice = Create.NewTV();
                    break;
                case "WH":
                    newDevice = Create.NewGame();
                    break;
            }
            int id = (int)Session["NextID"];
            IDictionary<int, Device> devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            devicesDictionary.Add(id, newDevice);
            Session["Devices"] = devicesDictionary;
            id++;
            Session["NextId"] = id;
            return RedirectToAction("Index");
        }
        public ActionResult Operation(int id, string command)
        {
            IDictionary<int, Device> devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            if (devicesDictionary[id] is IChangeEnum)
            {
                ice = (IChangeEnum)devicesDictionary[id];
            }
            if (devicesDictionary[id] is IVolume)
            {
                iv = (IVolume)devicesDictionary[id];
            }
            if (devicesDictionary[id] is IOpenOrClose)
            {
                iooc = (IOpenOrClose)devicesDictionary[id];
            }
            if (devicesDictionary[id] is IResetSettings)
            {
                irs = (IResetSettings)devicesDictionary[id];
            }
            if (devicesDictionary[id] is ISpeed)
            {
                isp = (ISpeed)devicesDictionary[id];
            }
            if (devicesDictionary[id] is IUse)
            {
                iu = (IUse)devicesDictionary[id];
            }

            switch (command)
            {
                case "on":
                    devicesDictionary[id].On();
                    break;
                case "off":
                    devicesDictionary[id].Off();
                    break;
                case "previous":
                    ice.PreviousEnum();
                    break;
                case "next":
                    ice.NextEnum();
                    break;
                case "minus":
                    iv.MinusVolume();
                    break;
                case "plus":
                    iv.PlusVolume();
                    break;
                case "open":
                    iooc.Open();
                    break;
                case "close":
                    iooc.Close();
                    break;
                case "rfp":
                    irs.ResetFirstParameter();
                    break;
                case "rsp":
                    irs.ResetSecondParameter();
                    break;
                case "low":
                    isp.Low();
                    break;
                case "unh":
                    isp.Unhurriedly();
                    break;
                case "boost":
                    isp.Boost();
                    break;
                case "quick":
                    isp.Quick();
                    break;
                case "app":
                    iu.Apply();
                    break;
            }
            Session["Devices"] = devicesDictionary;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            IDictionary<int, Device> devicesDictionary = (SortedDictionary<int, Device>)Session["Devices"];
            devicesDictionary.Remove(id);
            Session["Devices"] = devicesDictionary;

            return RedirectToAction("Index");
        }
    }
}