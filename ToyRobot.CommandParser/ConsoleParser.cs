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

namespace ToyRobot.CommandParsers
{
    using System;
    using System.Collections.Generic;
    using Library.Entities;
    using Library.Commands;

    public class ConsoleParser : Parser
    {

        public List<ICommand<Scene>> GetCommands()
        {
            var commands = new List<ICommand<Scene>>();

            CommandTypes commandType;
            do
            {
                Console.CursorTop = 15;
                Console.CursorLeft = 3;
                commandType = ConsoleEx.ReadEnum<CommandTypes>("Enter Command", padding: 20);

                var command = commandType.ToString();

                if (commandType == CommandTypes.Place)
                {
                    Console.CursorLeft = 3;
                    var arguments = ConsoleEx.ReadInput("Enter Place Parameters (x, y, orientation):");
                    command += $" {arguments}";
                }

                this.ParseLine(command, commands);

                ConsoleEx.ClearLine(15, 3, Console.WindowWidth - 2);
                ConsoleEx.ClearLine(16, 3, Console.WindowWidth - 2);

                Console.CursorTop = Console.WindowHeight - 3;
                ConsoleEx.Write(3, "Command Count: ", ConsoleColor.Gray);
                ConsoleEx.Write(20, commands.Count.ToString(), ConsoleColor.DarkGray);
            }
            while (commandType != CommandTypes.Exit);

            return commands;
        }
    }
}