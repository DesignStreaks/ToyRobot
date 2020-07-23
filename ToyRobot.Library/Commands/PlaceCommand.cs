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

namespace ToyRobot.Library.Commands
{
    using System;
    using Entities;

    public class PlaceCommand : Command<Scene>
    {
        private readonly Bearing bearing;

        /// <summary>Initializes a new instance of the <see cref="PlaceCommand"/> class.</summary>
        /// <param name="bearing">The bearing.</param>
        public PlaceCommand(Bearing bearing)
        {
            this.bearing = bearing;
        }

        /// <summary>Executes the command over the scene.</summary>
        /// <param name="scene">The scene to execute the command on.</param>
        /// <returns>The status of the command execution along with the updated scene.</returns>
        public override Status<Scene> Execute(Scene scene)
        {
            // If there is no robot to move, someone is playing funny buggers.
            if (scene.Robot == null)
                return Status<Scene>.Error("Robot not present", scene);

            var status = this.PreValidatePlacement(scene, this.bearing);

            if (!status)
                return Status<Scene>.Ok(scene);

            var newScene = scene.Copy();

            newScene.Robot.Place(this.bearing);

            return Status<Scene>.Ok(newScene);
        }

        // ReSharper disable once ParameterHidesMember
        private Status PreValidatePlacement(Scene scene, Bearing bearing)
        {
            switch (bearing.Orientation)
            {
                case Orientation.North:

                    if (bearing.Position.Y > scene.Environment.Height)
                        return Status.Error("Out of Bounds");

                    break;

                case Orientation.South:
                    if (bearing.Position.Y < 0)
                        return Status.Error("Out of Bounds");

                    break;

                case Orientation.East:
                    if (bearing.Position.X > scene.Environment.Width)
                        return Status.Error("Out of Bounds");

                    break;

                case Orientation.West:
                    if (bearing.Position.X < 0)
                        return Status.Error("Out of Bounds");

                    break;
            }

            return Status.Ok();
        }
    }
}