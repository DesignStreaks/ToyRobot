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


using System;

namespace ToyRobot.Console
{
    /// <summary>A 5 x 5 unit square table.</summary>
    /// <seealso cref="Library.Entities.Environment" />
    public class Table : Library.Entities.Environment
    {
        /// <summary>Initializes a new instance of the 5 x 5 unit square <see cref="Table"/> class.</summary>
        public Table() : base(5, 5) { }
    }
}