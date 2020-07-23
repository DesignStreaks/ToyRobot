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

namespace ToyRobot.CommandParser
{
    using System;
    using System.IO;

    public class FileCommandParser : IDisposable
    {
        private readonly StreamReader commandStreamReader;

        /// <summary>The disposed value</summary>
        private bool disposedValue = false;

        public FileCommandParser(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName), "No file name specified.");

            ValidateFile(fileName);

            this.commandStreamReader = new StreamReader(fileName);
        }

        private void ValidateFile(string fileName)
        {
            if (!Directory.Exists(fileName))
                throw new FileNotFoundException("Command File not found.", fileName);
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            if (disposing)
            {
                this.commandStreamReader?.Dispose();
            }

            this.disposedValue = true;
        }
    }
}