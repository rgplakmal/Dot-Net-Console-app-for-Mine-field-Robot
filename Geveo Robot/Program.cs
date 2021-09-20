using Geveo.Module.Robot.DTOs;
using Geveo.Module.Robot.ViewModels;
using System;
using System.Collections.Generic;

namespace Geveo.Module.Robot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Declarations
            int robotCount = 0;
            string upperRightCordinations;
            List<RobotInstructionVM> robotList = new List<RobotInstructionVM>();
            RobotControlRequest robotControlRequest = new RobotControlRequest();
            #endregion

            #region Process
            try
            {
                Console.WriteLine("How many Robots required?");
                robotCount = Convert.ToInt32(Console.ReadLine());

                if (robotCount > 0)
                {
                    // Get Upper-right Coordinates
                    Console.WriteLine("Enter Upper-right Coordinates:");

                    // Create a string variable and get user input from the keyboard and store it in the variable
                    upperRightCordinations = Console.ReadLine();
                    robotControlRequest.UpperRightCordinate = upperRightCordinations;
                    robotControlRequest.LowerLeftCordinate = "0 0";

                    // Wrapped robot list data
                    for (int i = 1; i <= robotCount; i++)
                    {
                        RobotInstructionVM robotInstruction = new RobotInstructionVM();
                        robotInstruction.RobotName = "Robot " + i;
                        Console.WriteLine("Enter Robo " + i + " Position");
                        robotInstruction.Position = Console.ReadLine().ToUpper();

                        Console.WriteLine("Enter Robo " + i + " Instructions ");
                        robotInstruction.Instruction = Console.ReadLine().ToUpper();

                        robotList.Add(robotInstruction);
                    }

                    // Get robot positions
                    foreach (var element in robotList)
                    {
                        robotControlRequest.RobotInstruction = element;

                        Robot robot = new Robot(robotControlRequest);
                        robot.GetPosistion((element.Instruction.ToCharArray()).Length);
                        Console.WriteLine(robot.GetPosition());
                    }
                }
                else
                {
                    Console.Write("Robot count is Invalid.");
                }
            }
            catch (Exception e)
            {
                Console.Write("Input is Invalid. Re-try with a correct inputs.");
            }
            #endregion
        }
    }
}
