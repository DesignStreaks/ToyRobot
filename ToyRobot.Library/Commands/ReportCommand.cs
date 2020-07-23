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

    public class ReportCommand : Command<Scene>
    {
        /// <summary>Executes the command over the scene.</summary>
        /// <param name="scene">The scene to execute the command on.</param>
        /// <returns>The status of the command execution along with the updated scene.</returns>
        public override Status<Scene> Execute(Scene scene)
        {
            var newScene = scene.Copy();

            return Status<Scene>.Ok(newScene);
        }
    }
}