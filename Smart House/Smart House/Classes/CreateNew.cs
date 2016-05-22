using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart_House
{
    public class CreateNew : ICreate
    {
        public Television NewTV()
        {
            Television tv = new Television(false, "Television", TVChannels.AnimalPlanet, 50);
            return tv;
        }
        public Fridge NewFridge()
        {
            Fridge fr = new Fridge(false, "Fridge", false, 3, TemperatureLvl.Default);
            return fr;
        }
        public Hoover NewHoover()
        {
            Hoover h = new Hoover(false, "Hoover", 0, 100, CleanLvl.DailyMode);
            return h;
        }

        public StationaryBicycle NewBicycle()
        {
            StationaryBicycle sb = new StationaryBicycle(false, "Bicycle", 60, ReliefLvl.HighwayMode);
            return sb;
        }

        public Warhammer NewGame()
        {
            Warhammer wh = new Warhammer(false, "Warhammer", "Игрок, ты еще не сыграл ни одной битвы!", BattlePlace.BattleForPlanet);
            return wh;
        }
    }
}
