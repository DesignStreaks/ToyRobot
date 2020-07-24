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

namespace ToyRobot.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Commands;
    using Entities;

    public class Processor : IProcessor
    {
        /// <summary>Process each command sequentially on the scene.</summary>
        /// <param name="scene">The scene to execute the commands on.</param>
        /// <param name="commands">The list of commands to execute over the scene.</param>
        /// <returns>The outcome of the scene after all commands have been executed.</returns>
        public Scene ProcessCommands(Scene scene, List<ICommand<Scene>> commands)
        {
            var newScene = scene.Copy();

            if(commands != null)
            {
                foreach (var status in commands.Select(command => command.Execute(newScene)))
                {
                    if (status)
                        newScene = status.Data;
                }
            }

            return newScene;
        }
    }
}