using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Tank_File
{
    public class TankMap
    {
        public int[,] TMap; //含坦克，砖的地图

        public TankMap()
        {
            TMap = new int[10, 10];
        }
    }
}
