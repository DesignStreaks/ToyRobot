// *
// * DESIGNSTREAKS CONFIDENTIAL
// * __________________ *
// *  Copyright © Design Streaks - 2010 - 2020
// *  All Rights Reserved. *
// * NOTICE: All information contained herein is, and remains
// * the property of DesignStreaks and its suppliers, if any.
// * The intellectual and technical concepts contained
// * herein are proprietary to DesignStreaks and its suppliers and may
// * be covered by Australian, U.S. and Foreign Patents,
// * patents in process, and are protected by trade secret or copyright law.
// * Dissemination of this information or reproduction of this material
// * is strictly forbidden unless prior written permission is obtained
// * from DesignStreaks.

using System.Xml.Schema;

namespace System
{
    using ToyRobot.Aspects;

    /// <summary>Extends the standard Console object.</summary>
    public static class ConsoleEx
    {
        private static object _MessageLock = new object();

        /// <summary>Draws a box to the console.</summary>
        /// <param name="x">The x-coordinate of the top left corner.</param>
        /// <param name="y">The y-coordinate of the top left corner.</param>
        /// <param name="width">The <paramref name="width" /> of the box to draw..</param>
        /// <param name="height">The <paramref name="height" /> of the box to draw..</param>
        /// <param name="clearContents">if set to <c>true</c> the inside of the box is cleared.; otherwise only the box is rendered.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        [ResetConsoleWindowAspect]
        public static void DrawBox(int x, int y, int width, int height, bool clearContents = false, ConsoleColor foreColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            width = Math.Min(width, Console.WindowWidth);
            height = Math.Min(height, Console.WindowHeight);

            Console.CursorLeft = x;
            Console.CursorTop = y;

            ConsoleEx.Write("┌", foreColor, backgroundColor);
            ConsoleEx.Write(new string('─', width - 2), foreColor, backgroundColor);
            ConsoleEx.Write("┐", foreColor, backgroundColor);
            Console.CursorTop++;

            if (clearContents)
                for (int rowIndex = 1; rowIndex < height; rowIndex++)
                {
                    Console.CursorLeft = x;
                    ConsoleEx.Write($"│{new string(' ', width - 2)}│", foreColor, backgroundColor);
                    Console.CursorTop = y + rowIndex;
                }

            Console.CursorLeft = x;
            ConsoleEx.Write("└", foreColor, backgroundColor);
            ConsoleEx.Write(new string('─', width - 2), foreColor, backgroundColor);
            ConsoleEx.Write("┘", foreColor, backgroundColor);
        }

        /// <summary>Draws a box to the console at the top left corner.</summary>
        /// <param name="width">The <paramref name="width"/> of the box to draw..</param>
        /// <param name="height">The <paramref name="height"/> of the box to draw..</param>
        /// <param name="clearContents">if set to <c>true</c> the inside of the box is cleared.; otherwise only the box is rendered.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        public static void DrawBox(int width, int height, bool clearContents = false, ConsoleColor foreColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            DrawBox(0, 0, width, height, clearContents, foreColor, backgroundColor);
        }

        /// <summary>Writes the specified string value to the console then reads a string representation of an Enum value.</summary>
        /// <typeparam name="T">The enum type to validate the input against.</typeparam>
        /// <param name="message">The message to write.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        /// <param name="padding">Used to set the input position.</param>
        /// <param name="placeHolder">The default value for the input.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="T"/> must be an Enumerable Type</exception>
        [ResetCursorColourAspect]
        public static T ReadEnum<T>(string message, ConsoleColor foreColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, int padding = 0, string placeHolder = "") where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an Enumerable Type");

            string origPlaceHolder = placeHolder;

            bool validValue = false;
            T value;

            do
            {
                var input = ReadInput(
                            message,
                            foreColor,
                            backgroundColor,
                            padding,
                            placeHolder);

                if (input == placeHolder)
                    input = origPlaceHolder;

                validValue = Enum.TryParse(input, true, out value);
                if (!validValue)
                {
                    placeHolder = $"{origPlaceHolder} - {input} is invalid";
                }
            } while (!validValue);

            return value;
        }

        /// <summary>Writes the specified string value to the console then reads a line of characters from the console.</summary>
        /// <param name="message">The message to write.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        /// <param name="padding">Used to set the input position.</param>
        /// <param name="placeHolder">The default value for the input.</param>
        /// <returns>System.String.</returns>
        [ResetCursorColourAspect]
        public static string ReadInput(string message, ConsoleColor foreColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, int padding = 0, string placeHolder = "")
        {
            lock (_MessageLock)
            {
                Console.ForegroundColor = foreColor;
                Console.BackgroundColor = backgroundColor;

                Console.Write($"{message.PadRight(padding)}");

                if (placeHolder != string.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(placeHolder);
                    Console.CursorLeft = Console.CursorLeft - placeHolder.Length;
                }

                Console.ForegroundColor = ConsoleColor.Gray;
            }
            string input = Console.ReadLine();

            if (input == string.Empty)
                input = placeHolder;

            return input;
        }

        /// <summary>Reads the int.</summary>
        /// <param name="message">The message to write.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        /// <param name="padding">Used to set the input position.</param>
        /// <param name="placeHolder">The default value for the input.</param>
        /// <returns>System.Int32.</returns>
        [ResetCursorColourAspect]
        public static int ReadInt(string message, ConsoleColor foreColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, int padding = 0, string placeHolder = "")
        {
            string origPlaceHolder = placeHolder;

            bool validValue = false;
            int value;

            do
            {
                var input = ReadInput(
                            message,
                            foreColor,
                            backgroundColor,
                            padding,
                            placeHolder);

                if (input == placeHolder)
                    input = origPlaceHolder;

                validValue = int.TryParse(input, out value);
                if (!validValue)
                {
                    placeHolder = $"{origPlaceHolder} - {input} is invalid";
                }
            } while (!validValue);

            return value;
        }

        /// <summary>Writes the specified string value to the console.</summary>
        /// <param name="message">The message to write.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        [ResetCursorColourAspect]
        public static void Write(string message, ConsoleColor foreColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            lock (_MessageLock)
            {
                Console.ForegroundColor = foreColor;
                Console.BackgroundColor = backgroundColor;
                Console.Write(message);
            }
        }

        /// <summary>Writes the specified string value to the console.</summary>
        /// <param name="left">The column to write the message.</param>
        /// <param name="message">The message to write.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        [ResetCursorColourAspect]
        public static void Write(int left, string message, ConsoleColor foreColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            lock (_MessageLock)
            {
                Console.CursorLeft = left;
                Console.ForegroundColor = foreColor;
                Console.BackgroundColor = backgroundColor;
                Console.Write(message);
            }
        }

        /// <summary>Writes the specified string value, followed by the current line terminator, to the console.</summary>
        /// <param name="message">The message to write.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        [ResetCursorColourAspect]
        public static void WriteLine(string message, ConsoleColor foreColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Write(message + "\n", foreColor, backgroundColor);
        }

        /// <summary>Writes the specified string value, followed by the current line terminator, to the console.</summary>
        /// <param name="left">The column to write the message.</param>
        /// <param name="message">The message to write.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        [ResetCursorColourAspect]
        public static void WriteLine(int left, string message, ConsoleColor foreColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.CursorLeft = left;
            Write(message + "\n", foreColor, backgroundColor);
        }


        /// <summary>
        ///   Writes the specified string value to the console with the <paramref name="underlineCharacter" /> written
        ///   below each character of the message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="foreColor">The foreground colour to write.</param>
        /// <param name="backgroundColor">The background colour to write.</param>
        /// <param name="underlineCharacter">The character used to write under the message.</param>
        [ResetCursorColourAspect]
        public static void WriteUnderLine(string message, ConsoleColor foreColor, ConsoleColor backgroundColor = ConsoleColor.Black, char underlineCharacter = '-')
        {
            WriteLine(message, foreColor, backgroundColor);
            WriteLine(new string(underlineCharacter, message.Length), foreColor, backgroundColor);
        }

        [ResetConsoleWindowAspect]
        public static void ClearLine()
        {
            Console.Write(new string(' ', Console.WindowWidth));
        }

        [ResetConsoleWindowAspect]
        public static void ClearLine(int start, int length)
        {
            Console.CursorLeft = start;
            if ((start + length) > Console.WindowWidth)
                length = Console.WindowWidth - start - 1;
            Console.Write(new string(' ', length));
        }


        [ResetConsoleWindowAspect]
        public static void ClearLine(int lineNumber)
        {
            Console.SetCursorPosition(0, lineNumber);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        [ResetConsoleWindowAspect]
        public static void ClearLine(int lineNumber, int start, int length)
        {
            Console.SetCursorPosition(start, lineNumber);
            if ((start + length) > Console.WindowWidth)
                length = Console.WindowWidth - start - 1;
            Console.Write(new string(' ', length));
        }
    }
}