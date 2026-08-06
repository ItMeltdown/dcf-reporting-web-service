using System;

namespace Dcf.Kids.WiKids.Utility.Exceptions
{
   public class DocumentGenerationException : Exception
   {
      public string ErrorCode { get; private set; }
      public string ErrorDescription { get; private set; }
      public string ServiceRequestId { get; private set; }
      public int StatusCode { get; private set; }
      public string StatusDescription { get; private set; }
      public string Content { get; private set; }

      public DocumentGenerationException(string errorCode, string errorDescription, string serviceRequestId, int statusCode, string statusDescription, string content)
         : base()
      {
         ErrorCode = errorCode;
         ErrorDescription = errorDescription;
         ServiceRequestId = serviceRequestId;
         StatusCode = statusCode;
         StatusDescription = statusDescription;
         Content = content;
      }

      public override string ToString()
      {
         var errorString = string.Format("{0}{1}ErrorCode: {2}, ErrorDescription: {3}, ServiceRequestId: {4}, StatusCode: {5}, StatusDescription: {6}, Content: {7}. {8}{9}",
                                          base.Message,  System.Environment.NewLine, ErrorCode, ErrorDescription, ServiceRequestId, StatusCode, StatusDescription, Content, System.Environment.NewLine, base.StackTrace);
         return errorString;
      }
   }
}
