using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    enum Direction
    {
        TOP, BOTTOM,
        LEFT, RIGHT,
        FRONT, BACK
    };

    public class MazeCreator
    {
        private Maze3D _maze;

        void CreateMaze(int sizeX, int sizeY, int sizeZ)
        {
            _maze = new Maze3D(sizeX, sizeY, sizeZ);

            RunMazeCreateAlgorithm_vPrim();
        }

        void CreateMaze(int sizeXYZ)
        {
            _maze = new Maze3D(sizeXYZ, sizeXYZ, sizeXYZ);

            RunMazeCreateAlgorithm_vPrim();
        }

        void RunMazeCreateAlgorithm_vPrim()
        {
            
        }
    }
}
