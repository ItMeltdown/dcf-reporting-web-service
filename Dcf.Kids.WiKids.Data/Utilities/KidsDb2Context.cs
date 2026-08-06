using Dapper;
using Dcf.Kids.Framework.Cache;
using Dcf.Kids.Framework.Data;
using Dcf.Kids.Framework.Security;
using Dcf.Kids.WiKids.Utility;
using Dcf.Kids.WiKids.Utility.Enumerations;
using Dcf.Kids.WiKids.Utility.Exceptions;
using IBM.Data.DB2;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Dcf.Kids.WiKids.Data.Utilities
{
   public class KidsDb2Context : IDbContext
   {
      private const string AuthorizationSqlState = "21001";
      private readonly string[] TimeoutSqlStates = new string[] { "08001", "57014" };
      private const string OutputParameterName = "out_string";
      private const string StatusCodeOutputParameterName = "statcd";
      private const string ErrorMessageOutputParameterName = "errmsg";
      private string _instanceConnectionString;
      private static string _connectionString;

      public KidsDb2Context()
      {
      }

      public KidsDb2Context(string instanceConnectionString)
      {
         _instanceConnectionString = instanceConnectionString;
      }

      /// <summary>
      /// Runs command text with parameters that returns an enumerable object of type dynamic.
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <param name="parameters">Optional array of type DbParameter.</param>
      /// <returns>Enumerable of type dynamic.</returns>
      public IEnumerable<dynamic> ExecuteDynamic(string commandText, CommandType commandType, params DbParameter[] parameters)
      {
         using (var connection = new DB2Connection(GetConnectionString()))
         {
            try
            {
               connection.Open();

               using (var transaction = connection.BeginTransaction())
               {
                  DynamicParameters spParams = null;
                  if (parameters != null)
                  {
                     spParams = new DynamicParameters();
                     foreach (var param in parameters)
                     {
                        spParams.Add(param.ParameterName, param.Value, param.DbType, param.Direction);
                     }
                  }

                  var commandDefinition = new CommandDefinition(commandText, spParams, transaction: transaction, commandType: commandType, flags: CommandFlags.NoCache | CommandFlags.Buffered);
                  dynamic result = connection.Query<dynamic>(commandDefinition);
                  transaction.Commit();
                  return result;
               }
            }
            catch (DB2Exception dbException)
            {
               throw BuildException(dbException, commandText, parameters);
            }
         }
      }

      /// <summary>
      /// Runs command text with parameters that returns a list of enumerable objects of type dynamic.
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <param name="parameters">Optional array of type DbParameter.</param>
      /// <returns>IList of IEnumerable dynamic types.</returns>
      public IList<IEnumerable<dynamic>> ExecuteMultipleDynamic(string commandText, CommandType commandType,
         params DbParameter[] parameters)
      {
         using (var connection = new DB2Connection(GetConnectionString()))
         {
            try
            {
               connection.Open();

               using (var transaction = connection.BeginTransaction())
               {
                  DynamicParameters spParams = null;
                  if (parameters != null)
                  {
                     spParams = new DynamicParameters();
                     foreach (var param in parameters)
                     {
                        spParams.Add(param.ParameterName, param.Value, param.DbType, param.Direction);
                     }
                  }

                  var commandDefinition = new CommandDefinition(commandText, spParams, transaction: transaction, commandType: commandType, flags: CommandFlags.NoCache | CommandFlags.Buffered);
                  using (var grid = connection.QueryMultiple(commandDefinition))
                  {
                     var multipleResult = new List<IEnumerable<dynamic>>();

                     do
                     {
                        multipleResult.Add(grid.Read<dynamic>());
                     } while (!grid.IsConsumed);

                     transaction.Commit();
                     return multipleResult;
                  }
               }
            }
            catch (DB2Exception dbException)
            {
               throw BuildException(dbException, commandText, parameters);
            }
         }
      }

      /// <summary>
      /// Runs a query with parameters that returns an enumerable object of type IDataTransferObject.
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// <param name="parameters">Array of type DbParameter.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <typeparam name="TResult">Expected type is IDataTransferObject.</typeparam>
      /// <returns>Enumerable of type TResult.</returns>
      public IEnumerable<TResult> Execute<TResult>(string commandText, DbParameter[] parameters, CommandType commandType)
      {
         var resultType = typeof(TResult);
         var isCacheableType = CacheProvider.IsCacheableType(resultType);

         CacheAttribute cacheAttribute = null;
         if (isCacheableType)
         {
            cacheAttribute = CacheProvider.CacheAttribute(resultType);
         }

         // if request is for a cacheable data transfer object and type exists in cache
         if (isCacheableType && CacheProvider.ExistsInCache<TResult>(cacheAttribute))
         {
            return CacheProvider.Get<TResult>();
         }

         using (var connection = new DB2Connection(GetConnectionString()))
         {
            try
            {
               connection.Open();

               using (var transaction = connection.BeginTransaction())
               {
                  DynamicParameters spParams = null;
                  if (parameters != null)
                  {
                     spParams = new DynamicParameters();
                     foreach (var param in parameters)
                     {
                        spParams.Add(param.ParameterName, param.Value, param.DbType, param.Direction);
                     }
                  }

                  var commandDefinition = new CommandDefinition(commandText, spParams, transaction: transaction, commandType: commandType, flags: CommandFlags.NoCache | CommandFlags.Buffered);
                  var result = connection.Query<TResult>(commandDefinition);

                  transaction.Commit();

                  if (isCacheableType && (cacheAttribute.AllowEmpty || result.Count() > 0))
                  {
                     CacheProvider.Add<TResult>(result, cacheAttribute);
                  }

                  return result;
               }
            }
            catch (DB2Exception dbException)
            {
               throw BuildException(dbException, commandText, parameters);
            }
         }
      }

      /// <summary>
      /// Runs a query that returns an enumerable object of type IDataTransferObject.
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <typeparam name="TResult">Expected type is IDataTransferObject.</typeparam>
      /// <returns>Enumerable of type TResult.</returns>
      public IEnumerable<TResult> Execute<TResult>(string commandText, CommandType commandType)
      {
         return Execute<TResult>(commandText, null, commandType);
      }

      /// <summary>
      /// Runs a query with parameters that returns an object of type MultipleResult (containing two collections).
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// /// <param name="parameters">Array of type DbParameter.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <typeparam name="TResult1">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult2">Expected type is IDataTransferObject.</typeparam>
      /// <returns>MultipleResult holds a dictionary of collections of type IDataTransferObject.</returns>
      public MultipleResult ExecuteMultiple<TResult1, TResult2>(string commandText, DbParameter[] parameters,
         CommandType commandType)
      {
         using (var connection = new DB2Connection(GetConnectionString()))
         {
            try
            {
               connection.Open();

               using (var transaction = connection.BeginTransaction())
               {
                  DynamicParameters spParams = null;
                  if (parameters != null)
                  {
                     spParams = new DynamicParameters();
                     foreach (var param in parameters)
                     {
                        spParams.Add(param.ParameterName, param.Value, param.DbType, param.Direction);
                     }
                  }

                  var commandDefinition = new CommandDefinition(commandText, spParams, transaction: transaction, commandType: commandType, flags: CommandFlags.NoCache | CommandFlags.Buffered);
                  using (var grid = connection.QueryMultiple(commandDefinition))
                  {

                     var multipleResult = new MultipleResult();
                     multipleResult.Add<TResult1>(grid.Read<TResult1>().ToList());
                     multipleResult.Add<TResult2>(grid.Read<TResult2>().ToList());
                     transaction.Commit();
                     return multipleResult;
                  }
               }
            }
            catch (DB2Exception dbException)
            {
               throw BuildException(dbException, commandText, parameters);
            }
         }
      }

      /// <summary>
      /// Runs a query that returns an object of type MultipleResult (containing two collections).
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <typeparam name="TResult1">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult2">Expected type is IDataTransferObject.</typeparam>
      /// <returns>MultipleResult holds a dictionary of collections of type IDataTransferObject.</returns>
      public MultipleResult ExecuteMultiple<TResult1, TResult2>(string commandText, CommandType commandType)
      {
         return ExecuteMultiple<TResult1, TResult2>(commandText, null, commandType);
      }

      /// <summary>
      /// Runs a query with parameters that returns an object of type MultipleResult (containing three collections).
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// /// <param name="parameters">Array of type DbParameter.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <typeparam name="TResult1">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult2">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult3">Expected type is IDataTransferObject.</typeparam>
      /// <returns>MultipleResult holds a dictionary of collections of type IDataTransferObject.</returns>
      public MultipleResult ExecuteMultiple<TResult1, TResult2, TResult3>(string commandText, DbParameter[] parameters,
         CommandType commandType)
      {
         using (var connection = new DB2Connection(GetConnectionString()))
         {
            try
            {
               connection.Open();

               using (var transaction = connection.BeginTransaction())
               {
                  DynamicParameters spParams = null;
                  if (parameters != null)
                  {
                     spParams = new DynamicParameters();
                     foreach (var param in parameters)
                     {
                        spParams.Add(param.ParameterName, param.Value, param.DbType, param.Direction);
                     }
                  }

                  var commandDefinition = new CommandDefinition(commandText, spParams, transaction: transaction, commandType: commandType, flags: CommandFlags.NoCache | CommandFlags.Buffered);
                  using (var grid = connection.QueryMultiple(commandDefinition))
                  {
                     var multipleResult = new MultipleResult();
                     multipleResult.Add<TResult1>(grid.Read<TResult1>().ToList());
                     multipleResult.Add<TResult2>(grid.Read<TResult2>().ToList());
                     multipleResult.Add<TResult3>(grid.Read<TResult3>().ToList());
                     transaction.Commit();
                     return multipleResult;
                  }
               }
            }
            catch (DB2Exception dbException)
            {
               throw BuildException(dbException, commandText, parameters);
            }
         }
      }

      /// <summary>
      /// Runs a query that returns an object of type MultipleResult (containing three collections).
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <typeparam name="TResult1">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult2">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult3">Expected type is IDataTransferObject.</typeparam>
      /// <returns>MultipleResult holds a dictionary of collections of type IDataTransferObject.</returns>
      public MultipleResult ExecuteMultiple<TResult1, TResult2, TResult3>(string commandText, CommandType commandType)
      {
         return ExecuteMultiple<TResult1, TResult2, TResult3>(commandText, null, commandType);
      }

      /// <summary>
      /// Runs a query with parameters that returns an object of type MultipleResult (containing five collections).
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// /// <param name="parameters">Array of type DbParameter.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <typeparam name="TResult1">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult2">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult3">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult4">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult5">Expected type is IDataTransferObject.</typeparam>
      /// <returns>MultipleResult holds a dictionary of collections of type IDataTransferObject.</returns>
      public MultipleResult ExecuteMultiple<TResult1, TResult2, TResult3, TResult4, TResult5>(string commandText,
         DbParameter[] parameters, CommandType commandType)
      {
         using (var connection = new DB2Connection(GetConnectionString()))
         {
            try
            {
               connection.Open();

               using (var transaction = connection.BeginTransaction())
               {
                  DynamicParameters spParams = null;
                  if (parameters != null)
                  {
                     spParams = new DynamicParameters();
                     foreach (var param in parameters)
                     {
                        spParams.Add(param.ParameterName, param.Value, param.DbType, param.Direction);
                     }
                  }

                  var commandDefinition = new CommandDefinition(commandText, spParams, transaction: transaction, commandType: commandType, flags: CommandFlags.NoCache | CommandFlags.Buffered);
                  using (var grid = connection.QueryMultiple(commandDefinition))
                  {
                     var multipleResult = new MultipleResult();
                     multipleResult.Add<TResult1>(grid.Read<TResult1>().ToList());
                     multipleResult.Add<TResult2>(grid.Read<TResult2>().ToList());
                     multipleResult.Add<TResult3>(grid.Read<TResult3>().ToList());
                     multipleResult.Add<TResult4>(grid.Read<TResult4>().ToList());
                     multipleResult.Add<TResult5>(grid.Read<TResult5>().ToList());
                     transaction.Commit();
                     return multipleResult;
                  }

               }
            }
            catch (DB2Exception dbException)
            {
               throw BuildException(dbException, commandText, parameters);
            }
         }
      }

      /// <summary>
      /// Runs a query that returns an object of type MultipleResult (containing five collections).
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <typeparam name="TResult1">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult2">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult3">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult4">Expected type is IDataTransferObject.</typeparam>
      /// <typeparam name="TResult5">Expected type is IDataTransferObject.</typeparam>
      /// <returns>MultipleResult holds a dictionary of collections of type IDataTransferObject.</returns>
      public MultipleResult ExecuteMultiple<TResult1, TResult2, TResult3, TResult4, TResult5>(string commandText,
         CommandType commandType)
      {
         return ExecuteMultiple<TResult1, TResult2, TResult3, TResult4, TResult5>(commandText, null, commandType);
      }

      /// <summary>
      /// Runs a query with parameters that returns a string.
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// <param name="parameters">Array of type DbParameter.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      /// <returns>String.</returns>
      public string Execute(string commandText, DbParameter[] parameters, CommandType commandType)
      {

         if (!parameters.Any(p =>
            p.ParameterName.Equals(OutputParameterName, StringComparison.OrdinalIgnoreCase)
            && p.Direction == ParameterDirection.Output))
         {
            throw new ArgumentException("Output parameter for '" + OutputParameterName + "' is missing", "parameters");
         }

         using (var connection = new DB2Connection(GetConnectionString()))
         {
            try
            {
               connection.Open();

               using (var transaction = connection.BeginTransaction())
               {
                  var spParams = new DynamicParameters();
                  foreach (var param in parameters)
                  {
                     spParams.Add(param.ParameterName.ToLower(), param.Value, param.DbType, param.Direction);
                  }

                  var commandDefinition = new CommandDefinition(commandText, spParams, transaction: transaction, commandType: commandType, flags: CommandFlags.NoCache | CommandFlags.Buffered);
                  connection.Execute(commandDefinition);

                  var outParm = spParams.Get<string>(OutputParameterName);
                  transaction.Commit();
                  return outParm;
               }
            }
            catch (DB2Exception dbException)
            {
               throw BuildException(dbException, commandText, parameters);
            }
         }
      }

      /// <summary>
      /// Runs a stored procedure or DML statement with parameters.
      /// </summary>
      /// <param name="commandText">Can be a SQL statement or Stored Procedure name.</param>
      /// <param name="parameters">Array of type DbParameter.</param>
      /// <param name="commandType">Can be StoredProcedure, TableDirect or Text.</param>
      public void ExecuteModifier(string commandText, DbParameter[] parameters, CommandType commandType)
      {
         using (var connection = new DB2Connection(GetConnectionString()))
         {
            try
            {
               connection.Open();

               using (var transaction = connection.BeginTransaction())
               {
                  var spParams = new DynamicParameters();
                  foreach (var param in parameters)
                  {
                     spParams.Add(param.ParameterName, param.Value, param.DbType, param.Direction);
                  }

                  var commandDefinition = new CommandDefinition(commandText, spParams, transaction: transaction, commandType: commandType, flags: CommandFlags.NoCache | CommandFlags.Buffered);
                  connection.Execute(commandDefinition);
                  // read output parameters for errors if DB2Exception is not thrown
                  if (parameters.Any(p => p.ParameterName.Equals(StatusCodeOutputParameterName, StringComparison.OrdinalIgnoreCase)
                                       && p.Direction == ParameterDirection.Output))
                  {
                     StoredProcedureStatusCode storedProcedureStatusCode;
                     var outParm = spParams.Get<string>(StatusCodeOutputParameterName);

                     if (Enum.TryParse(outParm, true, out storedProcedureStatusCode)
                         && Enum.IsDefined(typeof(StoredProcedureStatusCode), storedProcedureStatusCode))
                     {
                        switch (storedProcedureStatusCode)
                        {
                           case StoredProcedureStatusCode.Success: break;
                           default:
                              throw new DatabaseUpdateException($" ErrorMessage: {spParams.Get<string>(ErrorMessageOutputParameterName)} {BuildDatabaseStatement(commandText, parameters)}",
                                                       storedProcedureStatusCode);
                        }
                     };
                  }

                  transaction.Commit();
               }
            }
            catch (DB2Exception dbException)
            {
               throw BuildException(dbException, commandText, parameters);
            }
         }
      }

      private string GetConnectionString()
      {
         if (_instanceConnectionString != null)
         {
            return _instanceConnectionString;
         }

         if (_connectionString == null)
         {
            var section = (ConnectionStringSettingsCollection)ConfigurationManager.GetSection("db2Connection");
            if (section != null && section.Count > 0)
            {
               var connectionStringElement = section["db2Connection"];
               if (connectionStringElement != null)
               {
                  _connectionString = connectionStringElement.ConnectionString;
               }
            }
            // fallback to CryptographyProvider if EntSec cannot be supported in other applications
            else
            {
               var cryptography = new CryptographyProvider();
               _connectionString = cryptography.DecryptData(WiKidsConfig.EncryptedConnectionString);
            }
         }

         return _connectionString;
      }

      private Exception BuildException(DB2Exception db2Exception, string commandText, DbParameter[] parameters = null)
      {
         var sqlState = db2Exception.Errors[0].SQLState;
         var databaseStatement = BuildDatabaseStatement(commandText, parameters);

         string messageText = string.Empty;

         // not authorized exception
         if (sqlState.Equals(AuthorizationSqlState, StringComparison.OrdinalIgnoreCase))
         {
            messageText = string.Format("Not authorized database exception message: {0}\r\n {1}", db2Exception.Message, databaseStatement);
            return new NotAuthorizedException(messageText, NotAuthorizedReason.Database, db2Exception);
         }

         // timeout exception
         if (TimeoutSqlStates.Contains(sqlState))
         {
            messageText = string.Format("Resource limit exceeded database exception message: {0}\r\n {1}", db2Exception.Message, databaseStatement);
            return new TimeoutException(messageText, db2Exception);
         }

         // fatal exception
         messageText = string.Format("Fatal database exception message: {0}\r\n {1}", db2Exception.Message, databaseStatement);
         return new DatabaseException(messageText, db2Exception);
      }

      private string BuildDatabaseStatement(string commandText, DbParameter[] parameters = null)
      {
         var databaseStatement = $"Database statement: {commandText}";
         if (parameters != null)
         {
            databaseStatement += " with parameters ";
            foreach (var param in parameters)
            {
               databaseStatement += $"{param.ParameterName}={param.Value}, ";
            }
         }
         return databaseStatement;
      }
   }
}
