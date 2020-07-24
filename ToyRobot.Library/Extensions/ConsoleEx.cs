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

namespace System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public static class ConsoleEx
    {
        public static string ReadInput(string message, int padding, string placeHolder = "")
        {
            return ReadInput($"{message.PadRight(padding)} : ", placeHolder);
        }

        public static string ReadInput(string message, string placeHolder = "")
        {
            ConsoleColor origForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);

            if (placeHolder != string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(placeHolder);
                Console.CursorLeft -= placeHolder.Length;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            string input = Console.ReadLine();

            if (input == string.Empty)
                input = placeHolder;

            Console.ForegroundColor = origForeColor;
            return input;
        }

        public static void Write(string message, ConsoleColor foreColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            var origForeColour = Console.ForegroundColor;
            var origBackColour = Console.BackgroundColor;

            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(message);
            Console.ForegroundColor = origForeColour;
            Console.BackgroundColor = origBackColour;
        }

        public static void WriteLine(string message, ConsoleColor foreColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            var origForeColour = Console.ForegroundColor;
            var origBackColour = Console.BackgroundColor;

            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            Console.ForegroundColor = origForeColour;
            Console.BackgroundColor = origBackColour;
        }

        public static void WriteUnderLine(string message, ConsoleColor foreColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            var origForeColour = Console.ForegroundColor;
            var origBackColour = Console.BackgroundColor;

            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);
            Console.WriteLine(new string('-', message.Length));
            Console.ForegroundColor = origForeColour;
            Console.BackgroundColor = origBackColour;
        }

        public static int ReadInt(string message, int padding, string placeHolder = "")
        {
            string origPlaceHolder = placeHolder;

            bool validValue = false;
            int value;

            do
            {
                var origLeft = Console.CursorLeft;
                var origTop = Console.CursorTop;

                var input = ReadInput(message, padding, placeHolder);
                if (input == placeHolder)
                    input = origPlaceHolder;

                validValue = int.TryParse(input, out value);
                if (!validValue)
                {
                    placeHolder = $"{origPlaceHolder} - {input} is invalid";
                    Console.CursorLeft = origLeft;
                    Console.CursorTop = origTop;
                }

            } while (!validValue);

            return value;
        }

        public static T ReadEnum<T>(string message, int padding, string placeHolder = "") where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an Enumerable Type");

            string origPlaceHolder = placeHolder;

            bool validValue = false;
            T value;

            do
            {
                var origLeft = Console.CursorLeft;
                var origTop = Console.CursorTop;

                var input = ReadInput(message, padding, placeHolder);
                if (input == placeHolder)
                    input = origPlaceHolder;

                validValue = Enum.TryParse(input, true, out value);
                if (!validValue)
                {
                    placeHolder = $"{origPlaceHolder} - {input} is invalid";
                    Console.CursorLeft = origLeft;
                    Console.CursorTop = origTop;
                }

            } while (!validValue);

            return value;

        }
    }
}
