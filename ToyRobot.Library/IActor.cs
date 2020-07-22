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

    public interface IActor
    {
        /// <summary>A unique identifier of the Actor.</summary>
        Guid Id { get; }
    }

    public class Actor : IActor
    {
        /// <summary>A unique identifier of the Actor.</summary>
        public Guid Id { get; protected set; }

        /// <summary>Initializes a new instance of the <see cref="Actor"/> class.</summary>
        public Actor()
        {
            this.Id = Guid.Empty;
        }
    }
}