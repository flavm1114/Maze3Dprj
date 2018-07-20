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

        private Cell top_nearby_cell;
        private Cell bottom_nearby_cell;
        private Cell left_nearby_cell;
        private Cell right_nearby_cell;
        private Cell front_nearby_cell;
        private Cell back_nearby_cell;

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

            top_nearby_cell = null;
            bottom_nearby_cell = null;
            left_nearby_cell = null;
            right_nearby_cell = null;
            front_nearby_cell = null;
            back_nearby_cell = null;

            top_wall = null;
            bottom_wall = null;
            left_wall = null;
            right_wall = null;
            front_wall = null;
            back_wall = null;
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
                    return top_nearby_cell;
                case Direction.BOTTOM:
                    return bottom_nearby_cell;
                case Direction.LEFT:
                    return left_nearby_cell;
                case Direction.RIGHT:
                    return right_nearby_cell;
                case Direction.FRONT:
                    return front_nearby_cell;
                case Direction.BACK:
                    return back_nearby_cell;
            }
            return null;
        }

        public void SetNearByCell(Direction direction, Cell nearByCell)
        {
            switch (direction)
            {
                case Direction.TOP:
                    top_nearby_cell = nearByCell; break;
                case Direction.BOTTOM:
                    bottom_nearby_cell = nearByCell; break;
                case Direction.LEFT:
                    left_nearby_cell = nearByCell; break;
                case Direction.RIGHT:
                    right_nearby_cell = nearByCell; break;
                case Direction.FRONT:
                    front_nearby_cell = nearByCell; break;
                case Direction.BACK:
                    back_nearby_cell = nearByCell; break;
            }
        }

        public Wall GetWall(Direction direction)
        {
            switch (direction)
            {
                case Direction.TOP:
                    return top_wall;
                case Direction.BOTTOM:
                    return bottom_wall;
                case Direction.LEFT:
                    return left_wall;
                case Direction.RIGHT:
                    return right_wall;
                case Direction.FRONT:
                    return front_wall;
                case Direction.BACK:
                    return back_wall;
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
