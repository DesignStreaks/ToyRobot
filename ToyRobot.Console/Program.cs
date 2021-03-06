﻿/*
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

namespace ToyRobot.Console
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Aspects;
    using CommandParsers;
    using Library;
    using Library.Entities;

    public class Program
    {
        private static void DrawHeader()
        {
            var attributes = typeof(Program).GetTypeInfo().Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute));
            var assemblyTitleAttribute = attributes.SingleOrDefault() as AssemblyDescriptionAttribute;

            var title = assemblyTitleAttribute?.Description ?? string.Empty;

            Console.CursorTop = 0;
            Console.CursorLeft = (Console.WindowWidth / 2) - (title.Length / 2);
            ConsoleEx.Write(title, ConsoleColor.Yellow);
        }

        private static void DrawInstructions()
        {
            var resetConsoleWindowAspect = new ResetConsoleWindowAspect();
            resetConsoleWindowAspect.OnEntry();

            try
            {
                Console.CursorTop = 3;
                ConsoleEx.WriteLine(3, "Instructions: ", ConsoleColor.White);
                ConsoleEx.WriteLine(4, "Enter commands to move a toy robot around a 5x5 unit table.", ConsoleColor.DarkGray);
                ConsoleEx.Write(4, "Enter '", ConsoleColor.DarkGray);
                ConsoleEx.Write("Exit", ConsoleColor.Gray);
                ConsoleEx.WriteLine("' to exit.", ConsoleColor.DarkGray);
                Console.WriteLine();
                ConsoleEx.WriteLine(3, "Valid Commands", ConsoleColor.White);
                ConsoleEx.WriteLine(3, " - Place", ConsoleColor.DarkYellow);
                ConsoleEx.WriteLine(3, " - Move", ConsoleColor.DarkYellow);
                ConsoleEx.WriteLine(3, " - Left", ConsoleColor.DarkYellow);
                ConsoleEx.WriteLine(3, " - Right", ConsoleColor.DarkYellow);
                ConsoleEx.WriteLine(3, " - Report", ConsoleColor.DarkYellow);
            }
            finally
            {
                resetConsoleWindowAspect.OnExit();
            }
        }

        private static void InitialiseConsole()
        {
            Console.Clear();
            Console.WindowWidth = 120;
            Console.WindowHeight = 40;
            Console.BufferWidth = 120;
            Console.BufferHeight = 40;
            ConsoleEx.DrawBox(120, 39, true, ConsoleColor.DarkRed);
            DrawHeader();
            DrawInstructions();
        }

        private static void Main(string[] args)
        {
            InitialiseConsole();

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

            Console.CursorLeft = 5;
            Console.CursorTop = 25;

            Console.WriteLine(newScene.Robot.Bearing == null
                ? "Robot has not been placed onto the table."
                : $"{newScene.Robot.Bearing.Position.X}, {newScene.Robot.Bearing.Position.Y} - {newScene.Robot.Bearing.Orientation}");

            Console.ReadLine();
        }
    }
}