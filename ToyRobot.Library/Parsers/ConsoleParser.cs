// *
// * DESIGNSTREAKS CONFIDENTIAL
// * __________________
// *
// *  Copyright © Design Streaks - 2010 - 2020
// *  All Rights Reserved.
// *
// * NOTICE:  All information contained herein is, and remains
// * the property of DesignStreaks and its suppliers, if any.
// * The intellectual and technical concepts contained
// * herein are proprietary to DesignStreaks and its suppliers and may
// * be covered by Australian, U.S. and Foreign Patents,
// * patents in process, and are protected by trade secret or copyright law.
// * Dissemination of this information or reproduction of this material
// * is strictly forbidden unless prior written permission is obtained
// * from DesignStreaks.

namespace ToyRobot.Library.Parsers
{
    using System;
    using System.Collections.Generic;
    using Commands;
    using Entities;

    public class ConsoleParser : Parser
    {
        public ConsoleParser()
        {
            ConsoleEx.WriteLine("Toy Robot Simulator", ConsoleColor.Yellow);
            ConsoleEx.WriteLine("-------------------", ConsoleColor.Yellow);
            Console.WriteLine();
            ConsoleEx.WriteLine("Instructions: ", ConsoleColor.Gray);
            ConsoleEx.WriteLine("Enter commands to move a toy robot around a 5x5 unit table.", ConsoleColor.DarkGray);
            ConsoleEx.Write("Enter '", ConsoleColor.DarkGray);
            ConsoleEx.Write("Exit", ConsoleColor.Gray);
            ConsoleEx.WriteLine("' to exit.", ConsoleColor.DarkGray);
            Console.WriteLine();
            ConsoleEx.WriteLine("Valid Commands", ConsoleColor.Gray);
            ConsoleEx.WriteLine(" - Place", ConsoleColor.DarkYellow);
            ConsoleEx.WriteLine(" - Move", ConsoleColor.DarkYellow);
            ConsoleEx.WriteLine(" - Left", ConsoleColor.DarkYellow);
            ConsoleEx.WriteLine(" - Right", ConsoleColor.DarkYellow);
            ConsoleEx.WriteLine(" - Report", ConsoleColor.DarkYellow);
        }

        public List<ICommand<Scene>> GetCommands()
        {
            var commands = new List<ICommand<Scene>>();

            CommandTypes commandType;
            do
            {
                commandType = ConsoleEx.ReadEnum<CommandTypes>("Enter Command", 20);

                var command = commandType.ToString();

                if (commandType == CommandTypes.Place)
                {
                    var arguments = ConsoleEx.ReadInput("Enter Place Parameters (x, y, orientation):", "");
                    command += $" {arguments}";
                }

                this.ParseLine(command, commands);
            }
            while (commandType != CommandTypes.Exit);

            return commands;
        }
    }
}