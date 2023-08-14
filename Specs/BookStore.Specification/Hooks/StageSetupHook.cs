using BoDi;
using Screenplay.Core.Models;
using Screenplay.Rest.Screenplay.Abilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.Test.Specs.Hooks
{
    [Binding]
    public class StageApiSetupHook
    {
        private readonly IObjectContainer _container;
        public StageApiSetupHook(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void SetupStage()
        {
            var cast = Cast.WhereEveryoneCan(new List<IAbility>
            {
                CallAnApi.At(Configuration.AppSetting.APIUrl)
            });

            var stage = new Stage(cast);

            _container.RegisterInstanceAs(stage);
        }

        [BeforeScenario(tags: "databaseSandbox")]
        public void DatabaseSandboxBeforeScenario()
        {
            var connectionString = SetConnectionString();

            var stage = _container.Resolve<Stage>();
            foreach (var ability in stage.Cast.Abilities)
            {
                if (ability is CallAnApi callAnApi)
                {
                    callAnApi
                        .WhichRequestsInterceptedBy(new DatabaseSandBoxInterceptor(connectionString));
                }
            }
        }

        [AfterScenario(tags: "databaseSandbox")]
        public void DatabaseSandboxAfterScenario()
        {
            if (_container.IsRegistered<DbConnection>())
            {
                var dbConnection = _container.Resolve<DbConnection>();

                DropDatabase(dbConnection);
            }

            _container.Dispose();
        }

        private void DropDatabase(DbConnection connection)
        {
            using (var con = new SqlConnection(connection.ConnectionString))
            {
                var commandText = @$"
ALTER DATABASE [{connection.DbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [{connection.DbName}]";

                using var cmd = new SqlCommand(commandText, con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                con.ChangeDatabase("master");

                var r = cmd.ExecuteNonQuery();

                con.Close();
            }
        }


        private string SetConnectionString()
        {
            var dbConnection = new DbConnection(Configuration.ConnectionString, Guid.NewGuid().ToString("N"));
            _container.RegisterInstanceAs(dbConnection);

            return dbConnection.ConnectionString;
        }
    }
}