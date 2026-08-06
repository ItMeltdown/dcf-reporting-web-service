using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class ConflictException : Exception
   {
      public string ConflictId { get; private set; }

      public ConflictException(string message, string conflictId)
         : base(message)
      {
         ConflictId = conflictId;
      }
   }
}
