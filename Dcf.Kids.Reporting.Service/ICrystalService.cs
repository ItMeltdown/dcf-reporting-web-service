using Dcf.Kids.Reporting.ServiceLibrary;
using System.Collections.Generic;
using System.ServiceModel;

namespace Dcf.Kids.Reporting.Service
{
   [ServiceContract]
   [ServiceKnownType(typeof(DocumentRequest))]
   [ServiceKnownType(typeof(ReportParameterCollection))]
   public interface ICrystalService
   {
      /// <summary>
      /// This method with create a document for the given document data contract, synchronously.
      /// </summary>
      /// <param name="request">The document data contract.</param>
      /// <param name="repParamCollection">Report parameter collection</param>
      /// <returns>The report as bytes.</returns>
      [OperationContract(Name = "CreateDocumentSync")]
      byte[] CreateDocumentSync(DocumentRequest request, List<ReportParameterEntity> collect);

      [OperationContract(Name = "TestConnection")]
      string TestConnection(string testString);

      [OperationContract(Name = "TestDBConnection")]
      string TestDBConnection();
   }
}
