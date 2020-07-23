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
    using System.IO;
    using Commands;
    using Entities;

    public class FileParser : IFileParser
    {
        /// <summary>Parses the specified file name into executable <see cref="ICommand{T}" />'s.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Returns a list of commands to be executed.</returns>
        public List<ICommand<Scene>> Parse(string fileName)
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

                    var parts = line.Split(' ');

                    CommandTypes commandType;
                    if (!Enum.TryParse(parts[0], true, out commandType))
                        continue;

                    // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
                    switch (commandType)
                    {
                        case CommandTypes.Place:
                            Bearing bearing;
                            if (this.ValidatePlaceCommand(parts, out bearing))
                                commands.Add(new PlaceCommand(bearing));

                            break;

                        case CommandTypes.Move:
                            if (this.ValidateMoveCommand(parts))
                                commands.Add(new MoveCommand());

                            break;

                        case CommandTypes.Left:
                            if (this.ValidateLeftTurnCommand(parts))
                                commands.Add(new TurnCommand(Direction.Left));

                            break;

                        case CommandTypes.Right:
                            if (this.ValidateRightTurnCommand(parts))
                                commands.Add(new TurnCommand(Direction.Right));

                            break;

                        case CommandTypes.Report:
                            if (this.ValidateReportCommand(parts))
                                commands.Add(new ReportCommand());

                            break;
                    }
                }

                return commands;
            }
        }

        private Status ValidateReportCommand(string[] parts)
        {
            return parts.Length != 1
                ? Status.Error("Report command invalid argument count")
                : Status.Ok();
        }

        private Status ValidateRightTurnCommand(string[] parts)
        {
            return (parts.Length != 1)
                ? Status.Error("Right command invalid argument count")
                : Status.Ok();
        }

        private Status ValidateLeftTurnCommand(string[] parts)
        {
            return (parts.Length != 1)
                ? Status.Error("Left command invalid argument count")
                : Status.Ok();
        }

        private Status ValidateMoveCommand(string[] parts)
        {
            return (parts.Length != 1)
                ? Status.Error("Move command invalid argument count")
                : Status.Ok();
        }

        private Status ValidatePlaceCommand(string[] parts, out Bearing bearing)
        {
            if (parts.Length != 4)
                Status.Error("Place command invalid argument count");

            int x;
            if (!int.TryParse(parts[1], out x))
                Status.Error("Place command invalid 'x' argument");

            int y;
            if (!int.TryParse(parts[2], out y))
                Status.Error("Place command invalid 'y' argument");

            Orientation orientation;
            if (!Enum.TryParse(parts[3], out orientation))
                Status.Error("Place command invalid 'orientation' argument");

            bearing = new Bearing(x, y, orientation);

            return Status.Ok();
        }
    }
}