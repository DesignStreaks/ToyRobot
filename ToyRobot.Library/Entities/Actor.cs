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

namespace ToyRobot.Library.Entities
{
    using System;

    public abstract class Actor : IActor
    {
        /// <summary>Gets or sets the bearing.</summary>
        public Bearing Bearing { get; protected set; }

        /// <summary>A unique identifier of the Actor.</summary>
        public Guid Id { get; protected set; }

        /// <summary>Initializes a new instance of the <see cref="Actor"/> class.</summary>
        protected Actor()
        {
            this.Id = Guid.Empty;
        }

        /// <summary>Moves the Actor.</summary>
        public abstract void Move();

        /// <summary>Updates the bearing of the Actor.</summary>
        /// <param name="bearing">The bearing.</param>
        public abstract void Place(Bearing bearing);

        /// <summary>Turns the Actor in the specified direction.</summary>
        /// <param name="direction">The direction.</param>
        public abstract void Turn(Direction direction);
    }
}