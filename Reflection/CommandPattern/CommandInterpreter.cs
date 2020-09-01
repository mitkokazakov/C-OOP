using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND = "Command";
        public string Read(string args)
        {
            string[] commandInfo = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = commandInfo[0] + COMMAND;

            string[] commandArgs = commandInfo.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(ct => ct.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            ICommand currentCommand = (ICommand)Activator.CreateInstance(commandType);
            string result = currentCommand.Execute(commandArgs);

            return result;
        }
    }
}
