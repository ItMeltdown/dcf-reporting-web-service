using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Dcf.Kids.Framework.Data;

namespace Dcf.Kids.WiKids.Data.Utilities
{
   public interface IDbContext
   {
      IEnumerable<dynamic> ExecuteDynamic(string commandText, CommandType commandType, params DbParameter[] parameters);
      IList<IEnumerable<dynamic>> ExecuteMultipleDynamic(string commandText, CommandType commandType, params DbParameter[] parameters);
      IEnumerable<TResult> Execute<TResult>(string commandText, DbParameter[] parameters, CommandType commandType);
      IEnumerable<TResult> Execute<TResult>(string commandText, CommandType commandType);
      MultipleResult ExecuteMultiple<TResult1, TResult2>(string commandText, DbParameter[] parameters, CommandType commandType);
      MultipleResult ExecuteMultiple<TResult1, TResult2>(string commandText, CommandType commandType);
      MultipleResult ExecuteMultiple<TResult1, TResult2, TResult3>(string commandText, DbParameter[] parameters, CommandType commandType);
      MultipleResult ExecuteMultiple<TResult1, TResult2, TResult3>(string commandText, CommandType commandType);
      MultipleResult ExecuteMultiple<TResult1, TResult2, TResult3, TResult4, TResult5>(string commandText, DbParameter[] parameters, CommandType commandType);
      MultipleResult ExecuteMultiple<TResult1, TResult2, TResult3, TResult4, TResult5>(string commandText, CommandType commandType);
      string Execute(string commandText, DbParameter[] parameters, CommandType commandType);
      void ExecuteModifier(string commandText, DbParameter[] parameters, CommandType commandType);
   }
}
