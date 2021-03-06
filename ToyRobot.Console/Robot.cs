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

using System;
using ToyRobot.Library;
using ToyRobot.Library.Entities;

namespace ToyRobot.Console
{
    public class Robot : Actor
    {
        public Robot(Guid id)
        {
            this.Id = id;
        }

        public override void Place(Bearing bearing)
        {
            base.Bearing = bearing;
        }

        public override void Move()
        {
            base.Bearing = base.Bearing?.Move();
        }

        public override void Turn(Direction direction)
        {
            base.Bearing = base.Bearing?.Turn(direction);
        }


    }
}