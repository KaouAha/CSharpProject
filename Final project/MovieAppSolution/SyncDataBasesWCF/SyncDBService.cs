using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Windows;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace SyncDataBasesWCF
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
  
    public class SyncDBService : ISyncDBService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


    public bool Sync(string clientConnectionstring)
        {
           
                SqlConnection clientConnection = new SqlConnection();
            clientConnection.ConnectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=VideothequeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            // ServerSideSync
            String scope = "VideoScope";
            SqlSyncProvider serverProvider = new SqlSyncProvider();
            serverProvider.ScopeName = scope;
            serverProvider.Connection = new SqlConnection();
            serverProvider.Connection.ConnectionString = @"Data Source =(localdb)\v11.0; Initial Catalog = MoviesDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";


            //Config of the Scope 
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(scope);
            SqlSyncScopeProvisioning serverConfig = new SqlSyncScopeProvisioning((System.Data.SqlClient.SqlConnection)serverProvider.Connection);

            if (!serverConfig.ScopeExists(scope))
            {
                serverProvider.ObjectSchema = "dbo.";

                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("Actor", (System.Data.SqlClient.SqlConnection)serverProvider.Connection));
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("Director", (System.Data.SqlClient.SqlConnection)serverProvider.Connection));
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("Genre", (System.Data.SqlClient.SqlConnection)serverProvider.Connection));
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("Movie", (System.Data.SqlClient.SqlConnection)serverProvider.Connection));
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("MovieActor", (System.Data.SqlClient.SqlConnection)serverProvider.Connection));
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("MovieDirector", (System.Data.SqlClient.SqlConnection)serverProvider.Connection));
                scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("MovieGenre", (System.Data.SqlClient.SqlConnection)serverProvider.Connection));

                serverConfig.PopulateFromScopeDescription(scopeDesc);

                //indicate that the base table already exists and does not need to be created
                serverConfig.SetCreateTableDefault(DbSyncCreationOption.Skip);
                //provision the server
                serverConfig.Apply();
            }
            
            //ClientSideSyncserverConfig
            SqlSyncProvider clientProvider = new SqlSyncProvider();
            clientProvider.ScopeName = scope;
            clientProvider.Connection = new SqlConnection();
            clientProvider.Connection.ConnectionString = @"Data Source=(localdb)\v11.0;Initial Catalog=VideothequeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //Config of the Scope 
            DbSyncScopeDescription scopeDescClient = new DbSyncScopeDescription(scope);
            SqlSyncScopeProvisioning clientConfig = new SqlSyncScopeProvisioning((System.Data.SqlClient.SqlConnection)clientProvider.Connection);

            if (!clientConfig.ScopeExists(scope))
            {
                serverProvider.ObjectSchema = "dbo.";

                scopeDescClient.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("Actor", (System.Data.SqlClient.SqlConnection)clientProvider.Connection));
                scopeDescClient.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("Director", (System.Data.SqlClient.SqlConnection)clientProvider.Connection));
                scopeDescClient.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("Genre", (System.Data.SqlClient.SqlConnection)clientProvider.Connection));
                scopeDescClient.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("Movie", (System.Data.SqlClient.SqlConnection)clientProvider.Connection));
                scopeDescClient.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("MovieActor", (System.Data.SqlClient.SqlConnection)clientProvider.Connection));
                scopeDescClient.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("MovieDirector", (System.Data.SqlClient.SqlConnection)clientProvider.Connection));
                scopeDescClient.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("MovieGenre", (System.Data.SqlClient.SqlConnection)clientProvider.Connection));

                clientConfig.PopulateFromScopeDescription(scopeDescClient);

                //indicate that the base table already exists and does not need to be created
                clientConfig.SetCreateTableDefault(DbSyncCreationOption.Skip);
                //provision the server
                clientConfig.Apply();
            }

            

            // create the sync orhcestrator
            SyncOrchestrator syncOrchestrator = new SyncOrchestrator();

            syncOrchestrator.LocalProvider = serverProvider;

            // set the remote provider of orchestrator to a server sync provider associated with
            // the ProductsScope in the SyncDB server database
            syncOrchestrator.RemoteProvider = clientProvider;
            // set the direction of sync session to Upload and Download
            syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;

            // subscribe for errors that occur when applying changes to the client
            ((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);

       

            SyncConflictResolver ConflictResolver = new SyncConflictResolver();
            ConflictResolver.ClientDeleteServerUpdateAction = ResolveAction.ServerWins;
            ConflictResolver.ClientUpdateServerDeleteAction = ResolveAction.ServerWins;
            ConflictResolver.ClientInsertServerInsertAction = ResolveAction.ServerWins;

            // execute the synchronization process
           
                SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();
            
            // print statistics

            return true;
            
        }
        static void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
        {
            // display conflict type
            Console.WriteLine("coco"+e.Conflict.Type);

            // display error message 
            Console.WriteLine(e.Error);
        }
    }
}
