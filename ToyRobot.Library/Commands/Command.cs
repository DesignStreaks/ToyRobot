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

    public abstract class Command<T> : ICommand<T>
    {
        /// <summary>Executes the command over the scene.</summary>
        /// <param name="scene">The entity to execute the command on.</param>
        /// <returns>The status of the command execution along with the updated entity.</returns>
        public abstract Status<T> Execute(T scene);
    }
}