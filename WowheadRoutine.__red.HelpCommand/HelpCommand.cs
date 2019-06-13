using WowheadRoutine.Assert;
using WowheadRoutine.Commands;
using WowheadRoutine.Commands.Contracts;

namespace WowheadRoutine.__red.HelpCommand
{
    public class HelpCommand : ICommand
    {
        public string GetDescription()
        {
            return ".help - command for get description about all commands";
        }

        public bool IsSuitableHandler(string raw)
        {
            return raw.Contains(".help");
        }

        public void Run(params object[] args)
        {
            foreach(var cmd in CommandMgr.Instance.GetAllCommands())
            {
                if (cmd.GetDescription().Contains(".help")) continue;

                OutMgr.Instance.WriteLine("-- Available commands: ", OutLevel.Warning);
                OutMgr.Instance.WriteLine(cmd.GetDescription(), OutLevel.Info);
            }
        }
    }
}
