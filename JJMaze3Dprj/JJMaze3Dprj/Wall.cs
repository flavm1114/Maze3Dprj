using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    class Wall
    {
        private bool isExist = true;

        public bool GetIsExist()
        {
            return isExist;
        }

        public void SetIsExist(bool ex)
        {
            isExist = ex;
        }
    }
}
