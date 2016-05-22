using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public interface IOpenOrClose
    {
        bool StatusOpen { get; set; }
        void Open();
        void Close();
    }
}
