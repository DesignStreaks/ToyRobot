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

    public class Processor : IProcessor
    {
        public Status<Scene> Move(Scene scene)
        {
            // If there is no robot to move, someone is playing funny buggers.
            if (scene.Robot == null)
                return Status<Scene>.Error("Robot not present", scene);

            // If there is no table, then the robot has not been placed onto a table, there are no changes to the environment.
            if (scene.Environment == null)
                return Status<Scene>.Error("Robot not on table", scene);

            // If the robot has not been placed onto the table, there are no changes to the environment.
            if (scene.Bearing == null)
                return Status<Scene>.Ok(scene);

            // Calculate the new position for the robot.
            var newBearing = scene.Bearing.Move();

            var status = ValidateBearingPosition(scene, newBearing);
            if (!status)
                return Status<Scene>.Error(status.Message, scene);

            // If the new position of the robot is valid, replace the existing environment with a new one.

            var newEnvironment = new Scene()
            {
                Robot = scene.Robot,
                Environment = scene.Environment,
                Bearing = newBearing
            };

            return Status<Scene>.Ok(newEnvironment);
        }

        public Status<Scene> Place(Scene scene, Bearing bearing)
        {
            var status = ValidateBearingPosition(scene, bearing);

            if (!status)
                return Status<Scene>.Error(status.Message, scene);

            var newEnvironment = new Scene()
            {
                Robot = scene.Robot,
                Environment = scene.Environment,
                Bearing = bearing
            };

            return Status<Scene>.Ok(newEnvironment);
        }

        public Status<Scene> Report(Scene scene)
        {
            return Status<Scene>.Ok(scene);
        }

        public Status<Scene> Turn(Scene scene, string direction)
        {
            // If there is no robot to move, someone is playing funny buggers.
            if (scene.Robot == null)
                return Status<Scene>.Error("Robot not present", scene);

            // If there is no table, then the robot has not been placed onto a table, there are no changes to the environment.
            if (scene.Environment == null)
                return Status<Scene>.Error("Robot not on table", scene);

            // If the robot has not been placed onto the table, there are no changes to the environment.
            if (scene.Bearing == null)
                return Status<Scene>.Ok(scene);

            var newBearing = scene.Bearing.Turn(direction.ToEnum<Direction>());

            var newEnvironment = new Scene()
            {
                Robot = scene.Robot,
                Environment = scene.Environment,
                Bearing = newBearing
            };

            return Status<Scene>.Ok(newEnvironment);
        }

        private static Status ValidateBearingPosition(Scene scene, Bearing bearing)
        {
            if (bearing.Position.X < 0)
                return Status.Error("Out of Bounds");
            if (bearing.Position.Y < 0)
                return Status.Error("Out of Bounds");

            if (bearing.Position.X >= scene.Environment.Width)
                return Status.Error("Out of Bounds");
            if (bearing.Position.Y >= scene.Environment.Height)
                return Status.Error("Out of Bounds");

            return Status.Ok();
        }
    }
}