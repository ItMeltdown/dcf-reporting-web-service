using Dcf.Kids.Reporting.ServiceLibrary;
using Elmah;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Dcf.Kids.Reporting.Service
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CrystalService" in code, svc and config file together.
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class CrystalService : ICrystalService
   {
      /// <summary>
      /// This method will create a document for the given document data contract, synchronously.
      /// </summary>
      /// <param name="docRequest">The document data contract.</param>
      /// <param name="repParamCollection">Report parameter collection</param>
      /// <returns>The report as bytes.</returns>

      [FaultContract(typeof(string))]
      public byte[] CreateDocumentSync(DocumentRequest docRequest, List<ReportParameterEntity> repParamCollection)
      {
         try
         {
            DocumentRequestManager docReqManager = new DocumentRequestManager();
            string destinationPath = docReqManager.ProcessRequestSync(docRequest, repParamCollection);
            var crystalFile = System.IO.File.ReadAllBytes(destinationPath);
            System.IO.File.Delete(destinationPath);
            return crystalFile;
         }
         catch (FaultException exc)
         {
            ErrorSignal.FromCurrentContext().Raise(exc);
            throw exc;
         }
      }

      public string TestConnection(string testString)
      {
         return $"Connection Made to service, {testString}";
      }

      public string TestDBConnection()
      {
         var docDataMgr = new DocumentDataManager();
         var returnString = docDataMgr.GetTestData();

         return $"DBConnection Made, return string -- {returnString}.";
      }
   }
}
