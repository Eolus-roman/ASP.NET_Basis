using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_House
{
    public interface ICreate
    {
        Fridge NewFridge();
        Television NewTV();
        Hoover NewHoover();
        StationaryBicycle NewBicycle();
        Warhammer NewGame();
    }
}
