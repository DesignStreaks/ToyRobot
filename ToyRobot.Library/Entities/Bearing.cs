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

namespace ToyRobot.Library.Entities
{
    using System;

    /// <summary>Representation of a Position and Orientation</summary>
    public class Bearing
    {
        public Orientation Orientation { get; set; }
        public Position Position { get; set; }

        /// <summary>Initializes a new instance of the <see cref="Bearing"/> class.</summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="orientation">The orientation.</param>
        public Bearing(int x, int y, Orientation orientation)
        {
            this.Position = new Position(x, y);
            this.Orientation = orientation;
        }

        /// <summary>Updates the position by 1 unit in the diretion of the orientation.</summary>
        /// <returns>Bearing.</returns>
        public Bearing Move()
        {
            var newBearing = new Bearing(
                this.Position.X,
                this.Position.Y,
                this.Orientation);

            switch (this.Orientation)
            {
                case Orientation.North:
                    newBearing.Position = new Position(this.Position.X, this.Position.Y + 1);
                    break;

                case Orientation.South:
                    newBearing.Position = new Position(this.Position.X, this.Position.Y - 1);
                    break;

                case Orientation.East:
                    newBearing.Position = new Position(this.Position.X + 1, this.Position.Y);
                    break;

                case Orientation.West:
                    newBearing.Position = new Position(this.Position.X - 1, this.Position.Y);
                    break;
            }

            return newBearing;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{Position.X}, {Position.Y} @ {Orientation}";
        }

        /// <summary>Updates the orientation by 90° left or right.</summary>
        /// <param name="direction">The direction to update the orientation.</param>
        /// <returns>Bearing.</returns>
        public Bearing Turn(Direction direction)
        {
            var newBearing = new Bearing(
                this.Position.X,
                this.Position.Y,
                this.Orientation);

            switch (this.Orientation)
            {
                case Orientation.North:
                    newBearing.Orientation = direction == Direction.Left
                        ? Orientation.West
                        : Orientation.East;
                    break;

                case Orientation.South:
                    newBearing.Orientation = direction == Direction.Left
                        ? Orientation.East
                        : Orientation.West;
                    break;

                case Orientation.East:
                    newBearing.Orientation = direction == Direction.Left
                        ? Orientation.North
                        : Orientation.South;
                    break;

                case Orientation.West:
                    newBearing.Orientation = direction == Direction.Left
                        ? Orientation.South
                        : Orientation.North;
                    break;
            }

            return newBearing;
        }
    }
}