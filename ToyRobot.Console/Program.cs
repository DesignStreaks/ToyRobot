/*
 * DESIGNSTREAKS CONFIDENTIAL
 * __________________
 *
 *  Copyright © DesignStreaks - 2010 - 2020
 *  All Rights Reserved.
 *
 * NOTICE:  All information contained herein is, and remains
 * the property of DesignStreaks and its suppliers, if any.
 * The intellectual and technical concepts contained
 * herein are proprietary to DesignStreaks and its suppliers and may
 * be covered by Australian, U.S. and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from DesignStreaks.
 */

namespace ToyRobot
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            var scene = new Scene()
            {
                Robot = new Robot(Guid.NewGuid()),
                Environment = new Table()
            };

            IProcessor processor = new Processor();

            Bearing bearing = new Bearing(0, 0, Orientation.North);

            Status<Scene> status;

            status = processor.Place(scene, bearing);
            if (status)
                scene = status.Data;

            status = processor.Move(scene);
            if (status)
                scene = status.Data;

            status = processor.Turn(scene, "Right");
            if (status)
                scene = status.Data;

            status = processor.Move(scene);
            if (status)
                scene = status.Data;

            status = processor.Turn(scene, "Right");
            if (status)
                scene = status.Data;

            status = processor.Report(scene);
            if (status)
                Console.WriteLine($"{status.Data.Bearing.Position.X}, {status.Data.Bearing.Position.Y} - {status.Data.Bearing.Orientation}");

            Console.ReadLine();
        }
    }
}