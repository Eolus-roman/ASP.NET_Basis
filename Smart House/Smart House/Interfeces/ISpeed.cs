using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public interface ISpeed
    {
        void Low();
        void Unhurriedly(); //неторопливо
        void Boost(); //ускорение
        void Quick();
        void ReportInfo(); // информация о режимах
    }
}
