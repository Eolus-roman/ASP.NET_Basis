using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse
{
    public class CreateSmartDevices : ICreate
    {
        public Television CreateTelevision ()
        {
            return new Television("TVbyGallean", false, TVChannels.AnimalPlanet,
                AspectRatio.FourToThree, 50, 10, 60, 5);                
        }
        public Radioreceiver CreateRadioreceiver()
        {
            return new Radioreceiver("Radio", false, RadioChannels.SoloPianoRadio,
                50, 5);
        }
        public Fridge CreateFridge()
        {
            return new Fridge("IceByWotan", false, false, 5, -5);
        }
    }
} 
