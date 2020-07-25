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
    using System.Linq;
    using Library.Entities;
    using Library.Commands;
    using Library;

    public class Parser
    {
        protected void ParseLine(string line, List<ICommand<Scene>> commands)
        {
            var parts = line.Split(' ');

            CommandTypes commandType;
            if (!Enum.TryParse(parts[0], true, out commandType))
                return;

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

        private Status ValidateLeftTurnCommand(string[] parts)
        {
            return (parts.Length != 1 && !string.IsNullOrWhiteSpace(string.Join("", parts, 1, parts.Length - 1)))
                ? Status.Error("Left command invalid argument count")
                : Status.Ok();
        }

        private Status ValidateMoveCommand(string[] parts)
        {
            return (parts.Length != 1 && !string.IsNullOrWhiteSpace(string.Join("", parts, 1, parts.Length - 1)))
                ? Status.Error("Move command invalid argument count")
                : Status.Ok();
        }

        private Status ValidatePlaceCommand(string[] parts, out Bearing bearing)
        {
            bearing = null;

            if (parts.Length == 1)
                return Status.Error("Place command requires arguments");

            // Some hocus-pocus to remove any possible superfluous white spaces around command parameters.
            var arguments = string.Join("", parts.Skip(1).Where(i => !string.IsNullOrWhiteSpace(i))).Split(',');

            if (arguments.Length != 3)
                return Status.Error("Place command requires 3 arguments");

            int x;
            if (!int.TryParse(arguments[0], out x))
                return Status.Error("Place command invalid 'x' argument");

            int y;
            if (!int.TryParse(arguments[1], out y))
                return Status.Error("Place command invalid 'y' argument");

            Orientation orientation;
            if (!Enum.TryParse(arguments[2], true, out orientation))
                return Status.Error("Place command invalid 'orientation' argument");

            bearing = new Bearing(x, y, orientation);

            return Status.Ok();
        }

        private Status ValidateReportCommand(string[] parts)
        {
            return (parts.Length != 1 && !string.IsNullOrWhiteSpace(string.Join("", parts, 1, parts.Length - 1)))
                ? Status.Error("Report command invalid argument count")
                : Status.Ok();
        }

        private Status ValidateRightTurnCommand(string[] parts)
        {
            return (parts.Length != 1 && !string.IsNullOrWhiteSpace(string.Join("", parts, 1, parts.Length - 1)))
                ? Status.Error("Right command invalid argument count")
                : Status.Ok();
        }
    }
}