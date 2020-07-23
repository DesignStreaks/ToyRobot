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

    public class TurnCommand : Command<Scene>
    {
        private readonly Direction direction;

        /// <summary>Initializes a new instance of the <see cref="TurnCommand"/> class.</summary>
        /// <param name="direction">The direction of the turn.</param>
        public TurnCommand(Direction direction)
        {
            this.direction = direction;
        }

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

            var newScene = scene.Copy();

            newScene.Robot.Turn(this.direction);

            return Status<Scene>.Ok(newScene);
        }
    }
}