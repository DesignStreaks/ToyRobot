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

    public interface IActor
    {
        /// <summary>The position and orientation of the Actor.</summary>
        Bearing Bearing { get; }

        /// <summary>A unique identifier of the Actor.</summary>
        Guid Id { get; }

        /// <summary>Moves the Actor.</summary>
        void Move();

        /// <summary>Updates the bearing of the Actor.</summary>
        /// <param name="bearing">The bearing.</param>
        void Place(Bearing bearing);

        /// <summary>Turns the Actor in the specified direction.</summary>
        /// <param name="direction">The direction.</param>
        void Turn(Direction direction);
    }
}