using IBM.Data.DB2;
using System.Data;
using System.Data.Common;

namespace Dcf.Kids.WiKids.Data.Utilities
{
   public class KidsDbParameter : DbParameter
   {
      private readonly DB2Parameter _db2Parameter;

      public KidsDbParameter()
      {
         _db2Parameter = new DB2Parameter();
      }

      public override string ParameterName
      {
         get { return _db2Parameter.ParameterName; }
         set { _db2Parameter.ParameterName = value; }
      }

      public override object Value
      {
         get { return _db2Parameter.Value; }
         set { _db2Parameter.Value = value; }
      }

      public override ParameterDirection Direction
      {
         get { return _db2Parameter.Direction; }
         set { _db2Parameter.Direction = value; }
      }

      public override DataRowVersion SourceVersion
      {
         get { return _db2Parameter.SourceVersion; }
         set { _db2Parameter.SourceVersion = value; }
      }

      public override bool SourceColumnNullMapping
      {
         get { return _db2Parameter.SourceColumnNullMapping; }
         set { _db2Parameter.SourceColumnNullMapping = value; }
      }

      public override string SourceColumn
      {
         get { return _db2Parameter.SourceColumn; }
         set { _db2Parameter.SourceColumn = value; }
      }

      public override int Size
      {
         get { return _db2Parameter.Size; }
         set { _db2Parameter.Size = value; }
      }

      public override bool IsNullable
      {
         get { return _db2Parameter.IsNullable; }
         set { _db2Parameter.IsNullable = value; }
      }

      public override DbType DbType
      {
         get { return _db2Parameter.DbType; }
         set { _db2Parameter.DbType = value; }
      }

      public override void ResetDbType()
      {
         _db2Parameter.ResetDbType();
      }
   }
}
