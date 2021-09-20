using Geveo.Module.Robot.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geveo.Module.Robot
{
    public class Robot
    {
        #region Private Declarations
        private const string North = "N";
        private const string East = "E";
        private const string South = "S";
        private const string West = "W";
        private const char Left = 'L';
        private const char Right = 'R';
        private const char Move = 'M';
        private string robotName;
        private int x;
        private int y;
        private int xMax;
        private int yMax;
        private int xMin;
        private int yMin;
        private char[] path;
        private String direction;
        private int pathIndex = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Robot - Constructor
        /// </summary>
        /// <param name="robotControlRequest">robotControlRequest</param>
        public Robot(RobotControlRequest robotControlRequest)
        {
            String[] upperRightCordinate = robotControlRequest.UpperRightCordinate.Split(" ");
            String[] lowerLeftCordinate = robotControlRequest.LowerLeftCordinate.Split(" ");
            xMax = Int32.Parse(upperRightCordinate[0]);
            yMax = Int32.Parse(upperRightCordinate[1]);
            xMin = Int32.Parse(lowerLeftCordinate[0]);
            yMin = Int32.Parse(lowerLeftCordinate[1]);
            String[] positions = robotControlRequest.RobotInstruction.Position.Split(" ");
            robotName = robotControlRequest.RobotInstruction.RobotName;
            x = Int32.Parse(positions[0]);
            y = Int32.Parse(positions[1]);
            direction = positions[2];
            path = robotControlRequest.RobotInstruction.Instruction.ToCharArray();
        }
        #endregion

        #region Task
        /// <summary>
        /// GetPosistion
        /// </summary>
        /// <param></param>
        public int GetPosistion(int n)
        {

            if (n == 1)
            {
                MoveRobot();
                pathIndex++;

                return n;
            }
            else
            {
                MoveRobot();
                pathIndex++;

                return GetPosistion(n - 1);
            }
        }

        /// <summary>
        /// MoveRobot
        /// </summary>
        /// <param></param>
        public void MoveRobot()
        {
            var x = path[pathIndex];
            switch (x)
            {
                case Left:
                    TurnLeft();
                    break;
                case Right:
                    TurnRight();
                    break;
                case Move:
                    MoveForward();
                    break;
            }
        }

        /// <summary>
        /// TurnLeft
        /// </summary>
        /// <param></param>
        private void TurnLeft()
        {
            switch (direction)
            {
                case North:
                    direction = West;
                    break;
                case East:
                    direction = North;
                    break;
                case South:
                    direction = East;
                    break;
                case West:
                    direction = South;
                    break;
            }
        }

        /// <summary>
        /// TurnRight
        /// </summary>
        /// <param></param>
        private void TurnRight()
        {
            switch (direction)
            {
                case North:
                    direction = East;
                    break;
                case East:
                    direction = South;
                    break;
                case South:
                    direction = West;
                    break;
                case West:
                    direction = North;
                    break;
            }
        }

        /// <summary>
        /// MoveForward
        /// </summary>
        /// <param></param>
        private void MoveForward()
        {
            if (East.Equals(direction) && x < xMax)
            {
                x++;
            }
            else if (West.Equals(direction) && x > xMin)
            {
                x--;
            }
            else if (North.Equals(direction) && y < yMax)
            {
                y++;
            }
            else if (South.Equals(direction) && y > yMin)
            {
                y--;
            }
        }

        /// <summary>
        /// GetPosition
        /// </summary>
        /// <param></param>
        public String GetPosition()
        {
            return robotName + " Position is " + x + " " + y + " " + direction;
        }

        #endregion
    }
}
