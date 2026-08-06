using Dcf.Kids.Reporting.ServiceLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceLibraryTest
{
   [TestClass]
   public class UnitTest1
   {
      DocumentRequestManager _docReqManager;

      [TestInitialize]
      public void Initialize()
      {
         _docReqManager = new DocumentRequestManager();
         System.IO.Directory.CreateDirectory(@"c:\data");
         System.IO.Directory.CreateDirectory(@"c:\data\ServiceWorkingFolder");
         System.IO.Directory.CreateDirectory(@"c:\data\Templates");
      }
      // [Ignore] attribute added to skip this test, as they rely on local directory creation behavior and fail during CI workflow builds.
      [Ignore]
      [TestMethod]
      public void Test_LicenseCertJF0103_Success()
      {
         var docRequest = new DocumentRequest()
         {
            GenerationDate = new DateTime(),
            GUID = Guid.NewGuid().ToString(),
            Source = CreationSource.Unknown,
            ParameterType = ParameterType.Request,
            OutputFormat = OutputFormat.PDF,
            DocumentKey = 1,
            DocumentId = "Test",
            PrintSettings = PrintSettings.Portrait_Simplex,
            ClientCreated = new DateTime(),
            ServiceProcessingStart = new DateTime(),
            ServiceProcessingEnd = new DateTime(),
            SubPath = "KIDSReporting",
            ReportFileName = "LicenseCertJF0103.rpt",
            DatabaseUser = "dwdktfd"

         };
         List<ReportParameterEntity> repParamCollection = SetParamsForLicenseCertJF0103Report();

         string destinationPath = _docReqManager.ProcessRequestSync(docRequest, repParamCollection);

         // assert
         Assert.IsTrue(File.Exists(destinationPath));

         //var crystalFile = System.IO.File.ReadAllBytes(destinationPath);
         System.IO.File.Delete(destinationPath);
         SerializeDocumentRequest(docRequest);
         SerializeParameters(repParamCollection);

      }
      // [Ignore] attribute added to skip this test, as they rely on local directory creation behavior and fail during CI workflow builds.
      [Ignore]
      [TestMethod]
      public void Test_PaymentToMe_Success()
      {
         var docRequest = new DocumentRequest()
         {
            GenerationDate = new DateTime(),
            GUID = Guid.NewGuid().ToString(),
            Source = CreationSource.Web,
            ParameterType = ParameterType.Request,
            OutputFormat = OutputFormat.PDF,
            DocumentKey = 1234,
            DocumentId = "Mine",
            PrintSettings = PrintSettings.Portrait_Simplex,
            ClientCreated = new DateTime(),
            ServiceProcessingStart = new DateTime(),
            ServiceProcessingEnd = new DateTime(),
            SubPath = "PaymentCoupon",
            ReportFileName = "PaymentCoupon.rpt",
            DatabaseUser = "dwdktfd"

         };
         List<ReportParameterEntity> repParamCollection = SetParamsForPaymentCouponReport();

         string destinationPath = _docReqManager.ProcessRequestSync(docRequest, repParamCollection);

         // assert
         Assert.IsTrue(File.Exists(destinationPath));

         //var crystalFile = System.IO.File.ReadAllBytes(destinationPath);
         System.IO.File.Delete(destinationPath);
         SerializeDocumentRequest(docRequest);
         SerializeParameters(repParamCollection);

      }

      // [Ignore] attribute added to skip these tests, as they rely on integration behavior and fail during CI workflow builds.
      [Ignore]
      [TestMethod]
      public void Test_PaymentToMe_Localhost_Success()
      {
         var docRequest = new DocumentRequest()
         {
            GenerationDate = new DateTime(),
            GUID = Guid.NewGuid().ToString(),
            Source = CreationSource.Web,
            ParameterType = ParameterType.Request,
            OutputFormat = OutputFormat.PDF,
            DocumentKey = 1234,
            DocumentId = "Mine",
            PrintSettings = PrintSettings.Portrait_Simplex,
            ClientCreated = new DateTime(),
            ServiceProcessingStart = new DateTime(),
            ServiceProcessingEnd = new DateTime(),
            SubPath = "PaymentCoupon",
            ReportFileName = "PaymentCoupon.rpt",
            DatabaseUser = "dwdktfd"

         };

         //CrystalServiceLocal.ReportParameterCollection 
           List<ReportParameterEntity> repParamCollection = SetLocalParamsForPaymentCouponReport();

         var service = new CrystalServiceLocal.CrystalServiceClient();

         var report = service.CreateDocumentSync(docRequest, repParamCollection.ToArray());

         Assert.IsNotNull(report);

      }

      #region test methods
      private static List<ReportParameterEntity> SetParamsForPaymentCouponReport()
      {
         var repParamCollection = new List<ReportParameterEntity>();
         repParamCollection.Add(SetParameterEntity("KidsPin", "1234"));
         repParamCollection.Add(SetParameterEntity("ParticipantFullName", "IT Meltdown"));
         repParamCollection.Add(SetParameterEntity("Street1", "123 Main Street"));
         repParamCollection.Add(SetParameterEntity("Street2", "P>O> Box None"));
         repParamCollection.Add(SetParameterEntity("CityState", "Here At WI"));
         repParamCollection.Add(SetParameterEntity("Country", "USA"));
         return repParamCollection; 
      }

      private static List<ReportParameterEntity> SetLocalParamsForPaymentCouponReport()
      {
         var repParamCollection = new List<ReportParameterEntity>();
         repParamCollection.Add(SetParameterEntity("KidsPin", "1234"));
         repParamCollection.Add(SetParameterEntity("ParticipantFullName", "IT Meltdown"));
         repParamCollection.Add(SetParameterEntity("Street1", "123 Main Street"));
         repParamCollection.Add(SetParameterEntity("Street2", "P>O> Box None"));
         repParamCollection.Add(SetParameterEntity("CityState", "Here At WI"));
         repParamCollection.Add(SetParameterEntity("Country", "USA"));
         return repParamCollection;
      }

      private static List<ReportParameterEntity> SetParamsForLicenseCertJF0103Report()
      {
         var repParamCollection = new List<ReportParameterEntity>();
         repParamCollection.Add(SetParameterEntity("Delq1", ""));
         repParamCollection.Add(SetParameterEntity("NonCompl1", ""));
         repParamCollection.Add(SetParameterEntity("FullName1", "Full Name 1"));
         repParamCollection.Add(SetParameterEntity("SSN", "1234567890"));
         repParamCollection.Add(SetParameterEntity("KidsPin", "1234"));
         repParamCollection.Add(SetParameterEntity("FullName2", "Full Name 2"));
         repParamCollection.Add(SetParameterEntity("Delq2", ""));
         repParamCollection.Add(SetParameterEntity("NonCompl2", ""));
         repParamCollection.Add(SetParameterEntity("FullName3", "Full Name 3"));
         repParamCollection.Add(SetParameterEntity("LicCd", ""));
         repParamCollection.Add(SetParameterEntity("AgcyLicNo", ""));
         repParamCollection.Add(SetParameterEntity("FiveYrs", ""));
         repParamCollection.Add(SetParameterEntity("SixMo", ""));

         return repParamCollection;
      }

      private static ReportParameterEntity SetParameterEntity(string name, string value)
      {
         return new ReportParameterEntity()
         {
            ParameterName = name,
            ParameterValue = value
         };
      }

      public void SerializeDocumentRequest(DocumentRequest docRequest = null)
      {
         XmlSerializer xsSubmit = new XmlSerializer(typeof(DocumentRequest));

         if (docRequest == null)
         {
            docRequest = new DocumentRequest();
         }

         var xml = "";

         using (var sww = new StringWriter())
         {
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
               xsSubmit.Serialize(writer, docRequest);
               xml = sww.ToString(); // Your XML

               File.WriteAllText(@"c:\data\DocumentRequest.xml", xml);
            }
         }

      }

      public void SerializeParameters(List<ReportParameterEntity> parameters = null)
      {
         XmlSerializer xsSubmit = new XmlSerializer(typeof(ReportParameterEntity));
         StringBuilder stb = new StringBuilder();

         foreach (var item in parameters)
         {
            using (var sww = new StringWriter())
            {
               using (XmlWriter writer = XmlWriter.Create(sww))
               {
                  xsSubmit.Serialize(writer, item);
                  stb.Append(sww.ToString()); // Your XML

               }
            }
         }

         File.WriteAllText(@"c:\data\Parameters.xml", stb.ToString());

      }

      #endregion

   }
}
