using System;
using System.Collections;
using System.Linq;
using WowheadRoutine.Assert;
using WowheadRoutine.Snippets;
using WowheadRoutine.Sql;
using WowheadRoutine.Sql.Builders;
using WowheadRoutine.Sql.Contracts;

namespace WowheadRoutine.__red.LoadCreaturesSnippet
{
    public class LoadCreaturesSnippet : ISnippet
    {
        private ISqlBuilder Builder { get; set; }

        public T GetResult<T>()
        {
            throw new NotImplementedException();
        }

        public void OnLoaded()
        {
            OutMgr.Instance.WriteLine("[SNIPPETS] >> Load Creatures Snippet - loaded", OutLevel.Info);
        }

        public void OnUnloaded()
        {
            OutMgr.Instance.WriteLine("[SNIPPETS] >> Load Creatures Snippet - unloaded", OutLevel.Info);
        }

        public void Run(params object[] args)
        {
            string[] arr = ((IEnumerable)args).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();

            OutMgr.Instance.WriteLine($"[LOAD_CREATURE] >> Received data length: {arr.Length}", OutLevel.Info);

            Builder = SqlMgr.Create(SqlBuildTypes.Creatures);

            OutMgr.Instance.WriteLine($"[LOAD_CREATURE] >> Make the sql file", OutLevel.Info);

            Builder.Make(SqlAction.Creatures_QuestStarter);
            Builder
                .Append(PreparedStatements.CREATURE_DEL_QUESTSTARTER, "134889")
                .Append(PreparedStatements.CREATURE_INS_QUESTSTARTER, "134889", "48996")
                .Build();

            OutMgr.Instance.WriteLine($"[LOAD_CREATURE] >> Sql file successfully maked in dir: Sql\\", OutLevel.Info);
        }

        public void RunAsync(params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
