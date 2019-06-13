using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowheadRoutine.Assert;
using WowheadRoutine.Assert.Providers;
using WowheadRoutine.Commands.Contracts;
using WowheadRoutine.Snippets;

namespace WowheadRoutine.__red.LoadCreaturesCommand
{
    public class LoadCreaturesCommand : ICommand
    {
        private BaseOut Console { get; set; }
        private string Language { get; set; }

        private string[] AvailableLanguages = new string[]
        {
            "ru", "en", "ko"
        };

        public LoadCreaturesCommand()
        {
            Console = OutMgr.CreateConsole();
        }

        public string GetDescription()
        {
            return ".parse - the general parsing mechanic. Type: '.parse help' for more details";
        }

        public bool IsSuitableHandler(string raw)
        {
            return raw.Contains(".parse");
        }

        public void Run(params object[] args)
        {
            string cmd = (string)args[0];

            //Help command
            if(cmd.Contains("help"))
            {
                Console.WriteLine("-- PARSE: COMMAND FOR IMPLEMENT PARSING SYSTEM", OutLevel.Warning);
                Console.WriteLine(">> Available commands:", OutLevel.Warning);
                Console.WriteLine(".parse help - for learn more details about parse mechanic", OutLevel.Info);
                Console.WriteLine(".parse setlang - settings current language, ex: .parse setlang ru", OutLevel.Info);
                Console.WriteLine(">> Creatures commands:", OutLevel.Warning);
                Console.WriteLine(".parse creatures [locale, qstarter, qender] [MODES: zone, single, range], ex: '.parse creatures locale zone 8500'", OutLevel.Info);
                Console.WriteLine(">> GameObjects commands:", OutLevel.Warning);
                Console.WriteLine(".parse go [locale, loot] [MODES: zone, single, range], ex: '.parse go locale zone 8500'", OutLevel.Info);
                Console.WriteLine(">> Quests commands:", OutLevel.Warning);
                Console.WriteLine(".parse go [locale, loot] [MODES: zone, single, range], ex: 'parse go locale zone 8500'", OutLevel.Info);
                Console.WriteLine(">> Items commands:", OutLevel.Warning);
                Console.WriteLine(".parse item [create, loot, droppeby] [MODES: zone, single, range], ex: 'parse item loot zone 8500'", OutLevel.Info);
            }
            else //Other commands, only filtering
            {
                if(cmd.Contains("creatures"))
                {
                    if(cmd.Contains("locale"))
                    {
                        if(cmd.Contains("zone"))
                        {
                            SnippetMgr.Instance.Call("loadcreaturessnippet", "creatures", "locale", "zone", cmd.Split(' ').Last());
                        }
                        else if(cmd.Contains("single"))
                        {
                            SnippetMgr.Instance.Call("loadcreaturessnippet", "creatures", "locale", "single", cmd.Split(' ').Last());
                        }
                        else if(cmd.Contains("range"))
                        {
                            var spl = cmd.Split(' ').Last().Split('-');

                            SnippetMgr.Instance.Call("loadcreaturessnippet", "creatures", "locale", "range", spl[0], spl[1]);
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect syntax for subcommand: '.parse creatures locale'. Type '.parse help' for details", OutLevel.Error);
                        }
                    }
                    else if(cmd.Contains("qstarter"))
                    {

                    }
                    else if(cmd.Contains("qender"))
                    {

                    }
                    else
                    {
                        Console.WriteLine($"Incorrect syntax for subcommand: '.parse creatures'. Type '.parse help' for details", OutLevel.Error);
                    }
                }
                else if(cmd.Contains("quest"))
                {

                }
                else if(cmd.Contains("item"))
                {

                }
                else if(cmd.Contains("go"))
                {

                }
                else if(cmd.Contains("setlang"))
                {
                    var tempLang = cmd.Split(' ').Last();

                    bool result = false;
                    foreach(var available in AvailableLanguages)
                    {
                        if(tempLang.ToLower() == available.ToLower())
                        {
                            Language = tempLang.ToLower();
                            result = true;

                            break;
                        }
                    }

                    if(result)
                    {
                        Console.WriteLine($"Language switched to '{Language}'", OutLevel.Debug);
                    }
                    else
                    {
                        Console.WriteLine($"Unavailable language for switch!", OutLevel.Error);
                    }
                }
                else
                {
                    Console.WriteLine($"Incorrect syntax for command: '{cmd}'. Type '.parse help' for details", OutLevel.Error);
                }
            }
        }
    }
}
