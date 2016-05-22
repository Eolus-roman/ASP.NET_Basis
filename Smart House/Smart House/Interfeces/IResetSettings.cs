using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public interface IResetSettings
    {
        void ResetFirstParameter(); //    DustColl, Slow
        void ResetSecondParameter(); //    Accum, Relaxation
    }
}
