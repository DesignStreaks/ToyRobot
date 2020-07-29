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

namespace ToyRobot.Aspects
{
    using System;
    using System.Diagnostics;

    /// <summary>Aspect used to reset the Console Window &amp; Buffer.</summary>
    /// <remarks>
    ///   Method Boundary aspect to ensure the following Console properties are reset when the method completes.
    ///   <list type="bullet">
    ///     <item><description>Buffer Height</description></item>
    ///     <item><description>Buffer Width</description></item>
    ///     <item><description>Window Height</description></item>
    ///     <item><description>Window Width</description></item>
    ///   </list>
    ///   <note type="Information">This class was originally written as a PostSharp aspect. Due to licensing restrictions, PostSharp has been
    ///   removed so methods in this class are to be called manually (as opposed to being defined as a method attribute and weaved in by PostSharp)</note>
    /// </remarks>
    [Serializable]
    public class ResetConsoleWindowAspect
    {
        private int bufferHeight;
        private int bufferWidth;
        private int windowHeight;
        private int windowWidth;

        /// <summary>Method executed <b>before</b> the body of methods to which this aspect is applied.</summary>
        [DebuggerHidden]
        public void OnEntry()
        {
            this.bufferHeight = Console.BufferHeight;
            this.bufferWidth = Console.BufferWidth;

            this.windowHeight = Console.WindowHeight;
            this.windowWidth = Console.WindowWidth;
        }

        /// <summary>
        ///   Method executed <b>after</b> the body of methods to which this aspect is applied, even when the method exists with an exception
        ///   (this method is invoked from the <c>finally</c> block).
        /// </summary>
        /// <param name="args">Event arguments specifying which method is being executed and which are its arguments.</param>
        [DebuggerHidden]
        public void OnExit()
        {
            Console.BufferHeight = this.bufferHeight;
            Console.BufferWidth = this.bufferWidth;

            Console.WindowHeight = this.windowHeight;
            Console.WindowWidth = this.windowWidth;
        }
    }
}