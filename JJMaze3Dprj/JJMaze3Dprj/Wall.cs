using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    public class Wall
    {
        private bool _isExist;

        private List<Cell> _dividedCells;

        public Wall()
        {
            _isExist = true;

            _dividedCells = new List<Cell>();
            _dividedCells.Capacity = 2;
        }

        public bool GetIsExist()
        {
            return _isExist;
        }

        public void SetIsExist(bool isExist)
        {
            _isExist = isExist;
        }
    }
}
