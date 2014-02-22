using System;
using System.Collections.Generic;

namespace Commander
{
    /// <summary>
    /// Utility class for building a logical structure from command line arguments.
    /// </summary>
    public class CommanderBuilder
    {
        /// <summary>
        /// Build a command structure from command line arguments.
        /// </summary>
        /// <param name="commandLineArguments"></param>
        public CommanderBuilder(IEnumerable<string> commandLineArguments)
        {
            ParseArguments(commandLineArguments);
        }

        private void ParseArguments(IEnumerable<string> commandLineArguments)
        {
            var arguments = new Dictionary<string, string>();

            foreach (var argument in commandLineArguments)
            {
                if (argument.Contains(":"))
                {
                    var args = argument.Split(':');
                    if (args.Length < 2)
                        throw new Exception("Error reading arguments.");

                    arguments.Add(args[0], args[1]);
                }
                else
                    arguments["Default"] = argument;
            }
        }
    }
}
