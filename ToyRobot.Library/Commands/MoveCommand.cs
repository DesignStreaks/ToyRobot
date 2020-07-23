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

    /// <summary>Command to move an Actor in a scene 1 unit forward.</summary>
    /// <seealso cref="ToyRobot.Library.Commands.Command{Scene}" />
    public class MoveCommand : Command<Scene>
    {
        /// <summary>Executes the command over the scene.</summary>
        /// <param name="scene">The scene to execute the command on.</param>
        /// <returns>The status of the command execution along with the updated scene.</returns>
        public override Status<Scene> Execute(Scene scene)
        {
            // If there is no robot to move, someone is playing funny buggers.
            if (scene.Robot == null)
                return Status<Scene>.Error("Robot not present", scene);

            // If there is no table, then the robot has not been placed onto a table, there are no changes to the environment.
            if (scene.Environment == null)
                return Status<Scene>.Error("Robot not on table", scene);

            if (scene.Robot.Bearing == null)
                return Status<Scene>.Ok(scene);

            var status = this.PreValidateMove(scene);
            if (!status)
                return Status<Scene>.Ok(scene);

            var newScene = new Scene()
            {
                Environment = scene.Environment,
                Robot = scene.Robot
            };

            newScene.Robot.Move();

            return Status<Scene>.Ok(newScene);
        }

        private Status PreValidateMove(Scene scene)
        {
            switch (scene.Robot.Bearing.Orientation)
            {
                case Orientation.North:

                    if (scene.Robot.Bearing.Position.Y >= scene.Environment.Height - 1)
                        return Status.Error("Out of Bounds");

                    break;

                case Orientation.South:
                    if (scene.Robot.Bearing.Position.Y <= 0)
                        return Status.Error("Out of Bounds");

                    break;

                case Orientation.East:
                    if (scene.Robot.Bearing.Position.X >= scene.Environment.Width - 1)
                        return Status.Error("Out of Bounds");

                    break;

                case Orientation.West:
                    if (scene.Robot.Bearing.Position.X <= 0)
                        return Status.Error("Out of Bounds");

                    break;
            }

            return Status.Ok();
        }
    }
}