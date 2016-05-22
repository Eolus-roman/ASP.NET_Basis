﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_House
{
    public abstract class Device : IStatus
    {
        public Device(bool status, string name)
        {
            Status = status;
            Name = name;
        }
        public bool Status { get; set; }
        public string Name { get; set; }
        public virtual void On() // включили 
        {
            if (Status == false)
            {
                Status = true;
            }
        }
        public virtual void Off() // выключили
        {
            if (Status)
            {
                Status = false;
            }
        }
        public override string ToString()
        {
            string status;
            if (Status)
            {
                status = "включен";
            }
            else
            {
                status = "выключен";
            }
            return "\nСостояние: " + status;

        }
    }
}