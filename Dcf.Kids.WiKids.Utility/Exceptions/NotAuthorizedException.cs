using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class NotAuthorizedException : Exception
   {
      private NotAuthorizedReason _reason;

      public NotAuthorizedException(NotAuthorizedReason reason)
         : base(reason.ToString())
      {
         _reason = reason;
      }

      public NotAuthorizedException(NotAuthorizedReason reason, Exception innerException)
         : base(reason.ToString(), innerException)
      {
         _reason = reason;
      }

      public NotAuthorizedException(string message)
         : base(message)
      {
      }

      public NotAuthorizedException(string message, NotAuthorizedReason reason, Exception innerException)
         : base(message, innerException)
      {
         _reason = reason;
      }

      public NotAuthorizedReason Reason
      {
         get { return _reason; }
      }
   }
}

public enum NotAuthorizedReason
{
   AccountLocked = 1,
   Directory = 2,
   Database = 3
}