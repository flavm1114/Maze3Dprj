using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    public class Maze
    {
        private Cell[,,] _cell;
        private int _xSize;
        private int _ySize;
        private int _zSize;

        public Maze(int xyzSize)
        {
            _cell = new Cell[xyzSize, xyzSize, xyzSize];

            for (int i = 0; i < xyzSize; i++)
            {
                for (int j = 0; j < xyzSize; j++)
                {
                    for (int k = 0; k < xyzSize; k++)
                    {
                        _cell[i, j, k] = new Cell(this, i, j, k);
                    }
                }
            }

            _xSize = xyzSize;
            _ySize = xyzSize;
            _zSize = xyzSize;
        }

        public Maze(int xSize, int ySize, int zSize)
        {
            _cell = new Cell[xSize, ySize, zSize];

            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    for (int k = 0; k < zSize; k++)
                    {
                        _cell[i, j, k] = new Cell(this, i, j, k);
                    }
                }
            }

            _xSize = xSize;
            _ySize = ySize;
            _zSize = zSize;   
        }

        public int Get_xSize()
        {
            return _xSize;
        }

        public int Get_ySize()
        { 
            return _ySize;
        }

        public int Get_zSize()
        {
            return _zSize;
        }

        public Cell Get_cell(int x, int y, int z)
        {
            return _cell[x,y,z];
        }
    }
}
