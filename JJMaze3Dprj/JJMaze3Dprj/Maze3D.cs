using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    public class Maze3D
    {
        private Cube[,,] _cube;
        private int _xSize;
        private int _ySize;
        private int _zSize;

        public Maze3D(int xyzSize)
        {
            if (xyzSize != 0)
            {
                _cube = new Cube[xyzSize, xyzSize, xyzSize];

                for (int i = 0; i < xyzSize; i++)
                {
                    for (int j = 0; j < xyzSize; j++)
                    {
                        for (int k = 0; k < xyzSize; k++)
                        {
                            _cube[i, j, k] = new Cube(this, i, j, k);
                        }
                    }
                }

                _xSize = xyzSize;
                _ySize = xyzSize;
                _zSize = xyzSize;
            }
        }

        public Maze3D(int xSize, int ySize, int zSize)
        {
            if (xSize != 0 && ySize != 0 && zSize != 0)
            {
                _cube = new Cube[xSize, ySize, zSize];

                for (int i = 0; i < xSize; i++)
                {
                    for (int j = 0; j < ySize; j++)
                    {
                        for (int k = 0; k < zSize; k++)
                        {
                            _cube[i, j, k] = new Cube(this, i, j, k);
                        }
                    }
                }

                _xSize = xSize;
                _ySize = ySize;
                _zSize = zSize;
            }
        }

        
    }
}
