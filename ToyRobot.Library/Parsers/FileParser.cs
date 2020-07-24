﻿// *
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
    using System.IO;
    using Commands;
    using Entities;



    public class FileParser : Parser
    {
        /// <summary>Parses the specified file name into executable <see cref="ICommand{T}" />'s.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Returns a list of commands to be executed.</returns>
        public List<ICommand<Scene>> GetCommands(string fileName)
        {
            var commands = new List<ICommand<Scene>>();

            if (string.IsNullOrWhiteSpace(fileName) || (!File.Exists(fileName)))
                return commands;

            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    base.ParseLine(line, commands);
                }

                return commands;
            }
        }
    }
}