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

    public interface IActor
    {
        /// <summary>A unique identifier of the Actor.</summary>
        Guid Id { get; }

        Bearing Bearing { get; }

        void Place(Bearing bearing);
        void Move();
        void Turn(Direction direction);

    }

    public abstract class Actor : IActor
    {
        /// <summary>A unique identifier of the Actor.</summary>
        public Guid Id { get; protected set; }

        public Bearing Bearing { get; protected set; }

        /// <summary>Initializes a new instance of the <see cref="Actor"/> class.</summary>
        protected Actor()
        {
            this.Id = Guid.Empty;
        }

        public abstract void Place(Bearing bearing);
        public abstract void Move();
        public abstract void Turn(Direction direction);


    }

        
}