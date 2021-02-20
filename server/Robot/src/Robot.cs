using System;
using RobotOM;

namespace server.Robot.src
{
    public class RobotMain
    {
        public static void Bot()
        {
            RobotApplication rob = new RobotApplication();
            RobotStructure str = rob.Project.Structure;

            str.Nodes.Create(1, 0, 0, 0);
            Console.WriteLine("Node Added.");

            str = null;
            rob = null;
            Console.ReadKey();
        }
    }
}
