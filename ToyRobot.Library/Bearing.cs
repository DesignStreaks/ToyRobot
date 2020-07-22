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

namespace ToyRobot
{
    using System;

    public class Bearing
    {
        public Orientation Orientation { get; set; }
        public Position Position { get; set; }

        public Bearing(int x, int y, Orientation orientation)
        {
            this.Position = new Position(x, y);
            this.Orientation = orientation;
        }

        internal Bearing Move()
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

        internal Bearing Turn(Direction direction)
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