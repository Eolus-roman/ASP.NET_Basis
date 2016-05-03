//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Drawing;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using SmartHouse;

//namespace WebFormSmartHouse
//{
//    public class DeviceControl1 : Panel
//    {
//        private int id;
//        private readonly IDictionary<int, DeviceBasis> DevicesDictionary;
//        public DeviceControl(int id, IDictionary<int, DeviceBasis> devicesDictionary)
//        {
//            this.id = id;
//            DevicesDictionary = devicesDictionary;
//            Initializer();
//        }
//        protected void Initializer()
//        {
//            //IHavePowerSt();
//            ////распределить
//            //IHaveChannels();
//            //IHaveIBrightness();
//            //IHaveLoudness();
//            //IHaveAspectRatio();

//        }
//        protected void IHavePowerSt()
//        {
//            if (DevicesDictionary[id] is IPower)
//            {
//                IPower pw = DevicesDictionary[id] as IPower;
//                CssClass = "device-div";
//                Label nm;
//                Label st;
//                Button tr;
//                Panel tl = new Panel();

//                nm = new Label();

//            }



//        }
//    }
//}