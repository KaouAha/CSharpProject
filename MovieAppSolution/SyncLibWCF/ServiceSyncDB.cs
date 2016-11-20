using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;

namespace SyncLibWCF
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
        public class ServiceSyncDB : IServiceSyncDB
        {

            public bool Sync(SqlConnection clientConnection)
            {

                // ServerSideSync
                String scope = "VideoScope";
                SqlSyncProvider serverProvider = new SqlSyncProvider();
                serverProvider.ScopeName = scope;
                serverProvider.Connection = new SqlConnection();
                serverProvider.Connection.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = MoviesDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";


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
                // create the sync orhcestrator
                SyncOrchestrator syncOrchestrator = new SyncOrchestrator();

                syncOrchestrator.LocalProvider = serverProvider;

                // set the remote provider of orchestrator to a server sync provider associated with
                // the ProductsScope in the SyncDB server database
                syncOrchestrator.RemoteProvider = new SqlSyncProvider(scope, clientConnection);

                // set the direction of sync session to Upload and Download
                syncOrchestrator.Direction = SyncDirectionOrder.Upload;


                // execute the synchronization process
                SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();

                // print statistics
                Console.WriteLine("Start Time: " + syncStats.SyncStartTime);
                Console.WriteLine("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
                Console.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
                Console.WriteLine("Complete Time: " + syncStats.SyncEndTime);
                Console.WriteLine(String.Empty);

                return false;
            }
        }
    
}
