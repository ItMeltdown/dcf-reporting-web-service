using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class NotFoundException : Exception
   {
      public NotFoundException(string message)
         : base(message) { }
   }
}
