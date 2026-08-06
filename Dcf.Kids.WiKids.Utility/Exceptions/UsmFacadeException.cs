using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class UsmFacadeException : Exception
   {
      public string ErrorCode { get; private set; }
      public string ErrorDescription { get; private set; }
      public int StatusCode { get; private set; }
      public string StatusDescription { get; private set; }
      public string Content { get; private set; }

      public UsmFacadeException(string errorCode, string errorDescription, int statusCode, string statusDescription, string content)
         : base()
      {
         ErrorCode = errorCode;
         ErrorDescription = errorDescription;
         StatusCode = statusCode;
         StatusDescription = statusDescription;
         Content = content;
      }

      public override string ToString()
      {
         var errorString = string.Format("{0}{1}ErrorCode: {2}, ErrorDescription: {3}, StatusCode: {4}, StatusDescription: {5}, Content: {6}. {7}{8}",
                                          base.Message,  System.Environment.NewLine, ErrorCode, ErrorDescription, StatusCode, StatusDescription, Content, System.Environment.NewLine, base.StackTrace);
         return errorString;
      }
   }
}
