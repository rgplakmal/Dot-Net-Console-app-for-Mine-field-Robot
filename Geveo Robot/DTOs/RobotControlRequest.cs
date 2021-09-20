using Geveo.Module.Robot.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geveo.Module.Robot.DTOs
{
    public class RobotControlRequest
    {
        public string UpperRightCordinate { get; set; }
        public string LowerLeftCordinate { get; set; }
        public RobotInstructionVM RobotInstruction { get; set; }
    }
}
