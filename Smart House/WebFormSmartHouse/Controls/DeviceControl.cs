using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SmartHouse;
using Image = System.Web.UI.WebControls.Image;

namespace WebFormSmartHouse
{
    // [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DeviceControl : Panel
    {
        private int id;
        private readonly IDictionary<int, DeviceBasis> DevicesDictionary;

        //  private Image im;
        private Label nameDev;
        private Label att;
        private Label num;
        //      private Label numb;
        private Button stPower;
        private Button rghtBut;
        private Button lftBut;
        private Button rem;
        // объявляем интерфейсы
        private IAspectRatio ar;
        private IBrightness bht;
        private IChannels ch;
        private IFridge frid;
        private IFreezer freez;

        private ILoudness loud;
        //  private IPower pw;


        public DeviceControl(int id, IDictionary<int, DeviceBasis> devicesDictionary)
        {
            this.id = id;
            DevicesDictionary = devicesDictionary;
            Initializer();
        }
        protected void Initializer()
        {
            IHavePowerSt();
            IHaveIBrightness();
            IHaveLoudness();
            IHaveAspectRatio();
            IHaveChannels();
            IHaveFridge();
            IHaveFreezer();
            AllHaveRemove();

        }
        protected void IHavePowerSt()
        {
            if (DevicesDictionary[id] is IPower)
            {

                CssClass = "device-div";
                nameDev = new Label();
                nameDev.ID = nameDev + id.ToString();
                nameDev.Text = DevicesDictionary[id].NameDevice;
                nameDev.CssClass = "device-label";
                Controls.Add(nameDev);
                //===============================
                stPower = new Button();
                stPower.ID = "btnPw" + id.ToString();
                stPower.Attributes["on"] = "on";
                stPower.CssClass = "power-button";
                stPower.Click += ChPower;
                Controls.Add(stPower);
                //===============================
                att = new Label();
                att.ID = "St" + id.ToString();
                att.Text = "<br />" + DevicesDictionary[id];
                att.CssClass = "device-label";
                Controls.Add(att);
                Controls.Add(Span("<br />"));
                //===============================
                if (DevicesDictionary[id] is IFreezer)
                {
                    Label frSt = new Label();
                    frSt.ID = "freezerSt" + id.ToString();
                    frSt.Text = "Status Freezer";
                    frSt.CssClass = "device-label";
                    Controls.Add(frSt);
                    //===============================
                    Button stPowerFr = new Button();
                    stPowerFr.ID = "btnPwFr" + id.ToString();
                    stPowerFr.Attributes["on"] = "on";
                    stPowerFr.CssClass = "power-button";
                    stPowerFr.Click += ChPowerFreezer;
                    Controls.Add(stPowerFr);
                    Controls.Add(Span("<br />"));
                }
            }
            else { }
        }
        protected void IHaveChannels()
        {
            if (DevicesDictionary[id] is IChannels)
            {
                CssClass = "device-div";
                lftBut = new Button();
                lftBut.ID = "lftButCH" + id.ToString();
                lftBut.Attributes["onlf"] = "onlf";
                lftBut.CssClass = "lftBut";
                lftBut.Click += ChannelLft;
                Controls.Add(lftBut);
                //===============================
                att = new Label();
                att.ID = "ch" + id.ToString();
                att.Text = "Channel";
                att.CssClass = "device-label";
                Controls.Add(att);
                //===============================
                rghtBut = new Button();
                rghtBut.ID = "rghtBtnCH" + id.ToString();
                rghtBut.Attributes["onrg"] = "onrg";
                rghtBut.CssClass = "rghtBut";
                rghtBut.Click += ChannelRght;
                Controls.Add(rghtBut);
                Controls.Add(Span("<br />"));
            }
            else { }
        }
        protected void IHaveIBrightness()
        {
            if (DevicesDictionary[id] is IBrightness)
            {

                //===============================
                lftBut = new Button();
                lftBut.ID = "lftButBRT" + id.ToString();
                lftBut.Attributes["onlf"] = "onlf";
                lftBut.CssClass = "lftBut";
                lftBut.Click += BrightlLft;
                Controls.Add(lftBut);
                //===============================
                CssClass = "device-div";
                att = new Label();
                att.ID = "bht" + id.ToString();
                att.Text = "Brightness";
                att.CssClass = "device-label";
                Controls.Add(att);
                //===============================
                rghtBut = new Button();
                rghtBut.ID = "rghtBtnBRT" + id.ToString();
                rghtBut.Attributes["onrg"] = "onrg";
                rghtBut.CssClass = "rghtBut";
                rghtBut.Click += BrightRght;
                Controls.Add(rghtBut);
                Controls.Add(Span("<br />"));
            }
            else { }
        }
        protected void IHaveLoudness()
        {
            if (DevicesDictionary[id] is ILoudness)
            {
                CssClass = "device-div";
                lftBut = new Button();
                lftBut.ID = "lftButLD" + id.ToString();
                lftBut.Attributes["onlf"] = "onlf";
                lftBut.CssClass = "lftBut";
                lftBut.Click += LoudLft;
                Controls.Add(lftBut);
                //===============================
                att = new Label();
                att.ID = "LD" + id.ToString();
                att.Text = "Loudness";
                att.CssClass = "device-label";
                Controls.Add(att);
                //===============================
                rghtBut = new Button();
                rghtBut.ID = "rghtBtnLB" + id.ToString();
                rghtBut.Attributes["onrg"] = "onrg";
                rghtBut.CssClass = "rghtBut";
                rghtBut.Click += LoudRght;
                Controls.Add(rghtBut);
                Controls.Add(Span("<br />"));
            }
        }
        protected void IHaveAspectRatio()
        {
            if (DevicesDictionary[id] is IAspectRatio)
            {
                CssClass = "device-div";
                lftBut = new Button();
                lftBut.ID = "lftButAR" + id.ToString();
                lftBut.Attributes["onlf"] = "onlf";
                lftBut.CssClass = "lftBut";
                lftBut.Click += ARLft;
                Controls.Add(lftBut);
                //===============================
                att = new Label();
                att.ID = "AR" + id.ToString();
                att.Text = "Aspect Ratio";
                att.CssClass = "device-label";
                Controls.Add(att);
                //===============================
                rghtBut = new Button();
                rghtBut.ID = "rghtBtnAR" + id.ToString();
                rghtBut.Attributes["onrg"] = "onrg";
                rghtBut.CssClass = "rghtBut";
                rghtBut.Click += ARRght;
                Controls.Add(rghtBut);
                Controls.Add(Span("<br />"));
            }
        }
        protected void IHaveFridge()
        {
            if (DevicesDictionary[id] is IFridge)
            {
                CssClass = "device-div";
                lftBut = new Button();
                lftBut.ID = "lftButTempFr" + id.ToString();
                lftBut.Attributes["onlf"] = "onlf";
                lftBut.CssClass = "lftBut";
                lftBut.Click += TempFrLft;
                Controls.Add(lftBut);
                //===============================
                att = new Label();
                att.ID = "FRTemp" + id.ToString();
                att.Text = "Temperature Fridge";
                att.CssClass = "device-label";
                Controls.Add(att);
                //===============================
                CssClass = "device-div";
                rghtBut = new Button();
                rghtBut.ID = "rghtButTempFr" + id.ToString();
                rghtBut.Attributes["onlf"] = "onlf";
                rghtBut.CssClass = "lftBut";
                rghtBut.Click += TempFrRght;
                Controls.Add(rghtBut);
                Controls.Add(Span("<br />"));
            }
        }
        protected void IHaveFreezer()
        {

            if (DevicesDictionary[id] is IFreezer)
            {
                CssClass = "device-div";
                lftBut = new Button();
                lftBut.ID = "lftButTempFrz" + id.ToString();
                lftBut.Attributes["onlf"] = "onlf";
                lftBut.CssClass = "lftBut";
                lftBut.Click += TempFrzLft;
                Controls.Add(lftBut);
                //===============================
                att = new Label();
                att.ID = "FRZTemp" + id.ToString();
                att.Text = "Temperature Freezer";
                att.CssClass = "device-label";
                Controls.Add(att);
                //===============================
                CssClass = "device-div";
                rghtBut = new Button();
                rghtBut.ID = "rghtButTempFrz" + id.ToString();
                rghtBut.Attributes["onlf"] = "onlf";
                rghtBut.CssClass = "lftBut";
                rghtBut.Click += TempFrzRght;
                Controls.Add(rghtBut);
                Controls.Add(Span("<br />"));
            }
        }

        protected void AllHaveRemove()
        {
            CssClass = "device-div";
            rem = new Button();
            rem.ID = "RemoveBut" + id.ToString();
            rem.Attributes["removeOn"] = "removeOn";
            rem.CssClass = "RemoveBut";
            rem.Click += DeleteButtonClick;
            Controls.Add(rem);
        }
        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            DevicesDictionary.Remove(id); // Удаление девайса из коллекции
            Parent.Controls.Remove(this); // Удаление графики для девайса
        }
        protected void TempFrzRght(object sender, EventArgs e)
        {
            freez = (IFreezer)DevicesDictionary[id];
            freez.NextTempFreezer();
        }
        protected void TempFrzLft(object sender, EventArgs e)
        {
            freez = (IFreezer)DevicesDictionary[id];
            freez.PreviousTempFreezer();
        }
        protected void TempFrRght(object sender, EventArgs e)
        {
            frid = (IFridge)DevicesDictionary[id];
            frid.NextTempFridge();
        }
        protected void TempFrLft(object sender, EventArgs e)
        {
            frid = (IFridge)DevicesDictionary[id];
            frid.PreviousTempFridge();
        }
        protected void ARRght(object sender, EventArgs e)
        {
            ar = (IAspectRatio)DevicesDictionary[id];
            ar.NextAspectRatio();
        }
        protected void ARLft(object sender, EventArgs e)
        {
            ar = (IAspectRatio)DevicesDictionary[id];
            ar.PreviousAspectRatio();
        }
        protected void LoudRght(object sender, EventArgs e)
        {
            loud = (ILoudness)DevicesDictionary[id];
            loud.UpLoudness();
        }
        protected void LoudLft(object sender, EventArgs e)
        {
            loud = (ILoudness)DevicesDictionary[id];
            loud.DownLoudness();
        }
        protected void BrightRght(object sender, EventArgs e)
        {
            bht = (IBrightness)DevicesDictionary[id];
            bht.UpBrightness();
        }
        protected void BrightlLft(object sender, EventArgs e)
        {
            bht = (IBrightness)DevicesDictionary[id];
            bht.DownBrightness();
        }
        protected void ChPower(object sender, EventArgs e)
        {
            DevicesDictionary[id].СhangeTheStatusPower();
        }
        protected void ChannelRght(object sender, EventArgs e)
        {
            ch = (IChannels)DevicesDictionary[id];
            ch.NextChannel();
        }
        protected void ChannelLft(object sender, EventArgs e)
        {
            ch = (IChannels)DevicesDictionary[id];
            ch.NextChannel();
        }
        protected void ChPowerFreezer(object sender, EventArgs e)
        {
            IFreezer frz = DevicesDictionary[id] as IFreezer;
            frz.ChangeThePowerStatusFreezer();
        }
        protected HtmlGenericControl Span(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = innerHTML;
            return span;
        }

    }
}
