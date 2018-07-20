using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    public class Cell
    {
        private Maze _maze3d;

        private int _x_index;
        private int _y_index;
        private int _z_index;

        private bool _isVisited;

        private Cell top_nearby_cube;
        private Cell bottom_nearby_cube;
        private Cell left_nearby_cube;
        private Cell right_nearby_cube;
        private Cell front_nearby_cube;
        private Cell back_nearby_cube;

        private Wall top_wall;
        private Wall bottom_wall;
        private Wall left_wall;
        private Wall right_wall;
        private Wall front_wall;
        private Wall back_wall;

        public Cell(Maze maze3d, int xIndex, int yIndex, int zIndex)
        {
            _maze3d = maze3d;

            _x_index = xIndex;
            _y_index = yIndex;
            _z_index = zIndex;

            InitializeCube();
        }

        private void InitializeCube()
        {
            _isVisited = false;

            top_nearby_cube = null;
            bottom_nearby_cube = null;
            left_nearby_cube = null;
            right_nearby_cube = null;
            front_nearby_cube = null;
            back_nearby_cube = null;

            top_wall = new Wall();
            bottom_wall = new Wall();
            left_wall = new Wall();
            right_wall = new Wall();
            front_wall = new Wall();
            back_wall = new Wall();
        }

        public int GetXindex()
        {
            return _x_index;
        }

        public int GetYindex()
        {
            return _y_index;
        }

        public int GetZindex()
        {
            return _z_index;
        }

        public bool GetIsVisited()
        {
            return _isVisited;
        }

        public void SetIsVisited(bool isVisited)
        {
            _isVisited = isVisited;
        }

        public Cell GetNearByCell(Direction direction)
        {
            switch(direction)
            {
                case Direction.TOP:
                    return top_nearby_cube; break;
                case Direction.BOTTOM:
                    return bottom_nearby_cube; break;
                case Direction.LEFT:
                    return left_nearby_cube; break;
                case Direction.RIGHT:
                    return right_nearby_cube; break;
                case Direction.FRONT:
                    return front_nearby_cube; break;
                case Direction.BACK:
                    return back_nearby_cube; break;
            }
            return null;
        }

        public void SetNearByCell(Direction direction, Cell nearByCell)
        {
            switch (direction)
            {
                case Direction.TOP:
                    top_nearby_cube = nearByCell; break;
                case Direction.BOTTOM:
                    bottom_nearby_cube = nearByCell; break;
                case Direction.LEFT:
                    left_nearby_cube = nearByCell; break;
                case Direction.RIGHT:
                    right_nearby_cube = nearByCell; break;
                case Direction.FRONT:
                    front_nearby_cube = nearByCell; break;
                case Direction.BACK:
                    back_nearby_cube = nearByCell; break;
            }
        }

        public Wall GetWall(Direction direction)
        {
            switch (direction)
            {
                case Direction.TOP:
                    return top_wall; break;
                case Direction.BOTTOM:
                    return bottom_wall; break;
                case Direction.LEFT:
                    return left_wall; break;
                case Direction.RIGHT:
                    return right_wall; break;
                case Direction.FRONT:
                    return front_wall; break;
                case Direction.BACK:
                    return back_wall; break;
            }
            return null;
        }

        public void SetWall(Direction direction, Wall wall)
        {
            switch (direction)
            {
                case Direction.TOP:
                    top_wall = wall; break;
                case Direction.BOTTOM:
                    bottom_wall = wall; break;
                case Direction.LEFT:
                    left_wall = wall; break;
                case Direction.RIGHT:
                    right_wall = wall; break;
                case Direction.FRONT:
                    front_wall = wall; break;
                case Direction.BACK:
                    back_wall = wall; break;
            }
        }
    }
}
