/*
 * DESIGNSTREAKS CONFIDENTIAL
 * __________________
 *
 *  Copyright © DesignStreaks - 2010 - 2020
 *  All Rights Reserved.
 *
 * NOTICE:  All information contained herein is, and remains
 * the property of DesignStreaks and its suppliers, if any.
 * The intellectual and technical concepts contained
 * herein are proprietary to DesignStreaks and its suppliers and may
 * be covered by Australian, U.S. and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from DesignStreaks.
 */

using System.Collections.Generic;
using System.ComponentModel.Design;
using ToyRobot.Library.Commands;

namespace ToyRobot.Console
{
    using System;
    using Library;
    using Library.Entities;
    using Library.Parsers;

    public class Program
    {
        private static void Main(string[] args)
        {
            var scene = new Scene()
            {
                Robot = new Robot(Guid.NewGuid()),
                Environment = new Table()
            };

            var commands = args.Length > 1 
                ? new FileParser().GetCommands(args[1]) 
                : new ConsoleParser().GetCommands();
            
            var processor = new Processor();
            
            var newScene = processor.ProcessCommands(scene, commands);

            Console.WriteLine(newScene.Robot.Bearing == null
                ? "Robot has not been placed onto the table."
                : $"{newScene.Robot.Bearing.Position.X}, {newScene.Robot.Bearing.Position.Y} - {newScene.Robot.Bearing.Orientation}");

            Console.ReadLine();
        }
    }
}