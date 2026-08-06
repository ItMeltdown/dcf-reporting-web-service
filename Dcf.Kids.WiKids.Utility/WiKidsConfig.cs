using System.Configuration;

namespace Dcf.Kids.WiKids.Utility
{
   /// <summary>
   /// The WiKidsConfig static class stores the application-level constants that are 
   /// assigned in the Web.Config configuration file and makes them available throughout
   /// the application.
   /// </summary>
   public static class WiKidsConfig
   {
      private const string ConnectionStringName = "KidsDb2Context";

      private static string _applicationCode;
      private static string _dbOwnerPrefix;
      private static string _encryptedConnectionString;
      private static string _storedProcDebug;
      private static string _kidsAvailableXmlFile;
      private static string _authorizedDirectoryGroup;
      private static string _xPathInput;
      private static string _contactMessageText;
      private static string _viewHelpUrl;
      private static string _documentSampleUrl;
      private static string _accountManagementUrl;
      private static string _documentTransformationTemplateFile;
      private static string _flattenedDocumentSchemaFile;
      private static string _documentCreateRequestSchemaFile;
      private static string _schemaNamespaceName;
      private static string _schemaNamespaceNameForValidation;
      private static string _commonValidationSchemaFile;
      private static string _documentMetadataSchemaFile;
      private static string _documentContentSchemaFile;
      private static string _documentPostProcessSchemaFile;
      private static string _documentIdSchemaFile;
      private static string _kidsCaseNumberSchemaFile;
      private static string _participantIdSchemaFile;
      private static string _documentRepositoryIdentifiersSchemaFile;
      private static string _documentGenerationMessageSchemaFile;
      private static string _commonDocumentRequestSchemaFile;
      private static string _printSettingsSchemaFile;
      private static string _documentSearchSchemaFile;
      private static string _documentGetSchemaFile;
      private static string _documentSaveSchemaFile;
      private static string _documentPublishSchemaFile;
      private static string _documentDeleteSchemaFile;
      private static string _wiKidsSchemaNamespaceName;
      private static string _wiKidsAccessMessageXmlFile;
      private static string _wiKidsAccessMessageSchemaFile;
      private static string _documentRedraftSchemaFile;
      private static string _draftEditorAuthenticationTimeout;
      private static string _documentManagerDns;
      private static string _documentManagerSsoId;
      private static string _defaultLanguageCode;
      public static string XPathInput
      {
         get
         {
            if (_xPathInput == null)
               _xPathInput = ConfigurationManager.AppSettings["XPathInput"];

            return _xPathInput;
         }
      }


      public static string ApplicationCode
      {
         get
         {
            if (_applicationCode == null)
               _applicationCode = ConfigurationManager.AppSettings["ApplicationCode"];

            return _applicationCode;
         }
      }

      public static string DbOwnerPrefix
      {
         get
         {
            if (_dbOwnerPrefix == null)
               _dbOwnerPrefix = ConfigurationManager.AppSettings["DbOwnerPrefix"];

            return _dbOwnerPrefix;
         }
      }

      public static string EncryptedConnectionString
      {
         get
         {
            if (_encryptedConnectionString == null)
               _encryptedConnectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;

            return _encryptedConnectionString;
         }
      }

      public static string StoredProcDebug
      {
         get
         {
            if (_storedProcDebug == null)
               _storedProcDebug = ConfigurationManager.AppSettings["StoredProcDebug"];

            return _storedProcDebug;
         }
      }

      public static string KidsAvailableXmlFile
      {
         get
         {
            if (_kidsAvailableXmlFile == null)
               _kidsAvailableXmlFile = ConfigurationManager.AppSettings["KidsAvailableXmlFile"];

            return _kidsAvailableXmlFile;
         }
      }

      public static string DirectoryAuthorizationGroup
      {
         get
         {
            if (_authorizedDirectoryGroup == null)
               _authorizedDirectoryGroup = ConfigurationManager.AppSettings["DirectoryAuthorizationGroup"];

            return _authorizedDirectoryGroup;
         }
      }

      public static string ContactMessageText
      {
         get
         {
            if (_contactMessageText == null)
               _contactMessageText = ConfigurationManager.AppSettings["ContactMessageText"];

            return _contactMessageText;
         }
      }

      public static string ViewHelpUrl
      {
         get
         {
            if (_viewHelpUrl == null)
               _viewHelpUrl = ConfigurationManager.AppSettings["ViewHelpUrl"];

            return _viewHelpUrl;
         }
      }

      public static string DocumentSampleUrl
      {
         get
         {
            if (_documentSampleUrl == null)
               _documentSampleUrl = ConfigurationManager.AppSettings["DocumentSampleUrl"];

            return _documentSampleUrl;
         }
      }

      public static string AccountManagementUrl
      {
         get
         {
            if (_accountManagementUrl == null)
               _accountManagementUrl = ConfigurationManager.AppSettings["AccountManagementUrl"];

            return _accountManagementUrl;
         }
      }

      public static string DocumentTransformationTemplateFile
      {
         get
         {
            if (_documentTransformationTemplateFile == null)
               _documentTransformationTemplateFile = ConfigurationManager.AppSettings["DocumentTransformationTemplateFile"];

            return _documentTransformationTemplateFile;
         }
      }

      public static string FlattenedDocumentSchemaFile
      {
         get
         {
            if (_flattenedDocumentSchemaFile == null)
               _flattenedDocumentSchemaFile = ConfigurationManager.AppSettings["FlattenedDocumentSchemaFile"];

            return _flattenedDocumentSchemaFile;
         }
      }

      public static string DocumentCreateRequestSchemaFile
      {
         get
         {
            if (_documentCreateRequestSchemaFile == null)
               _documentCreateRequestSchemaFile = ConfigurationManager.AppSettings["DocumentCreateRequestSchemaFile"];

            return _documentCreateRequestSchemaFile;
         }
      }

      public static string SchemaNamespaceName
      {
         get
         {
            if (_schemaNamespaceName == null)
               _schemaNamespaceName = ConfigurationManager.AppSettings["SchemaNamespaceName"];

            return _schemaNamespaceName;
         }
      }

      public static string SchemaNamespaceNameForValidation
      {
         get
         {
            if (_schemaNamespaceNameForValidation == null)
               _schemaNamespaceNameForValidation = ConfigurationManager.AppSettings["SchemaNamespaceNameForValidation"];

            return _schemaNamespaceNameForValidation;
         }
      }

      public static string CommonValidationSchemaFile
      {
         get
         {
            if (_commonValidationSchemaFile == null)
               _commonValidationSchemaFile = ConfigurationManager.AppSettings["CommonValidationSchemaFile"];

            return _commonValidationSchemaFile;
         }
      }

      public static string DocumentMetadataSchemaFile
      {
         get
         {
            if (_documentMetadataSchemaFile == null)
               _documentMetadataSchemaFile = ConfigurationManager.AppSettings["DocumentMetadataSchemaFile"];

            return _documentMetadataSchemaFile;
         }
      }

      public static string DocumentContentSchemaFile
      {
         get
         {
            if (_documentContentSchemaFile == null)
               _documentContentSchemaFile = ConfigurationManager.AppSettings["DocumentContentSchemaFile"];

            return _documentContentSchemaFile;
         }
      }

      public static string DocumentPostProcessSchemaFile
      {
         get
         {
            if (_documentPostProcessSchemaFile == null)
               _documentPostProcessSchemaFile = ConfigurationManager.AppSettings["DocumentPostProcessSchemaFile"];

            return _documentPostProcessSchemaFile;
         }
      }

      public static string DocumentIdSchemaFile
      {
         get
         {
            if (_documentIdSchemaFile == null)
               _documentIdSchemaFile = ConfigurationManager.AppSettings["DocumentIdSchemaFile"];

            return _documentIdSchemaFile;
         }
      }

      public static string KidsCaseNumberSchemaFile
      {
         get
         {
            if (_kidsCaseNumberSchemaFile == null)
               _kidsCaseNumberSchemaFile = ConfigurationManager.AppSettings["KidsCaseNumberSchemaFile"];

            return _kidsCaseNumberSchemaFile;
         }
      }

      public static string ParticipantIdSchemaFile
      {
         get
         {
            if (_participantIdSchemaFile == null)
               _participantIdSchemaFile = ConfigurationManager.AppSettings["ParticipantIdSchemaFile"];

            return _participantIdSchemaFile;
         }
      }

      public static string DocumentRepositoryIdentifiersSchemaFile
      {
         get
         {
            if (_documentRepositoryIdentifiersSchemaFile == null)
               _documentRepositoryIdentifiersSchemaFile = ConfigurationManager.AppSettings["DocumentRepositoryIdentifiersSchemaFile"];

            return _documentRepositoryIdentifiersSchemaFile;
         }
      }

      public static string DocumentGenerationMessageSchemaFile
      {
         get
         {
            if (_documentGenerationMessageSchemaFile == null)
               _documentGenerationMessageSchemaFile = ConfigurationManager.AppSettings["DocumentGenerationMessageSchemaFile"];

            return _documentGenerationMessageSchemaFile;
         }
      }

      public static string CommonDocumentRequestSchemaFile
      {
         get
         {
            if (_commonDocumentRequestSchemaFile == null)
               _commonDocumentRequestSchemaFile = ConfigurationManager.AppSettings["CommonDocumentRequestSchemaFile"];

            return _commonDocumentRequestSchemaFile;
         }
      }

      public static string PrintSettingsSchemaFile
      {
         get
         {
            if (_printSettingsSchemaFile == null)
               _printSettingsSchemaFile = ConfigurationManager.AppSettings["PrintSettingsSchemaFile"];

            return _printSettingsSchemaFile;
         }
      }

      public static string DocumentSearchSchemaFile
      {
         get
         {
            if (_documentSearchSchemaFile == null)
               _documentSearchSchemaFile = ConfigurationManager.AppSettings["DocumentSearchSchemaFile"];

            return _documentSearchSchemaFile;
         }
      }

      public static string DocumentGetSchemaFile
      {
         get
         {
            if (_documentGetSchemaFile == null)
               _documentGetSchemaFile = ConfigurationManager.AppSettings["DocumentGetSchemaFile"];

            return _documentGetSchemaFile;
         }
      }

      public static string DocumentSaveSchemaFile
      {
         get
         {
            if (_documentSaveSchemaFile == null)
               _documentSaveSchemaFile = ConfigurationManager.AppSettings["DocumentSaveSchemaFile"];

            return _documentSaveSchemaFile;
         }
      }

      public static string DocumentPublishSchemaFile
      {
         get
         {
            if (_documentPublishSchemaFile == null)
               _documentPublishSchemaFile = ConfigurationManager.AppSettings["DocumentPublishSchemaFile"];

            return _documentPublishSchemaFile;
         }
      }

      public static string DocumentDeleteSchemaFile
      {
         get
         {
            if (_documentDeleteSchemaFile == null)
               _documentDeleteSchemaFile = ConfigurationManager.AppSettings["DocumentDeleteSchemaFile"];

            return _documentDeleteSchemaFile;
         }
      }
      public static string WiKidsSchemaNamespaceName
      {
         get
         {
            if (_wiKidsSchemaNamespaceName == null)
               _wiKidsSchemaNamespaceName = ConfigurationManager.AppSettings["WiKidsSchemaNamespaceName"];

            return _wiKidsSchemaNamespaceName;
         }
      }
      public static string WiKidsAccessMessageXmlFile
      {
         get
         {
            if (_wiKidsAccessMessageXmlFile == null)
               _wiKidsAccessMessageXmlFile = ConfigurationManager.AppSettings["WiKidsAccessMessageXmlFile"];

            return _wiKidsAccessMessageXmlFile;
         }
      }
      public static string WiKidsAccessMessageSchemaFile
      {
         get
         {
            if (_wiKidsAccessMessageSchemaFile == null)
               _wiKidsAccessMessageSchemaFile = ConfigurationManager.AppSettings["WiKidsAccessMessageSchemaFile"];

            return _wiKidsAccessMessageSchemaFile;
         }
      }


      public static string DocumentRedraftSchemaFile
      {
         get
         {
            if (_documentRedraftSchemaFile == null)
               _documentRedraftSchemaFile = ConfigurationManager.AppSettings["DocumentRedraftSchemaFile"];

            return _documentRedraftSchemaFile;
         }
      }

      public static string DraftEditorAuthenticationTimeout
      {
         get
         {
            if (_draftEditorAuthenticationTimeout == null)
               _draftEditorAuthenticationTimeout = ConfigurationManager.AppSettings["DraftEditorAuthenticationTimeout"];

            return _draftEditorAuthenticationTimeout;
         }
      }

      public static string DocumentManagerDns
      {
         get
         {
            if (_documentManagerDns == null)
               _documentManagerDns = ConfigurationManager.AppSettings["DocumentManagerDns"];

            return _documentManagerDns;
         }
      }

      public static string DocumentManagerSsoId
      {
         get
         {
            if (_documentManagerSsoId == null)
               _documentManagerSsoId = ConfigurationManager.AppSettings["DocumentManagerSsoId"];

            return _documentManagerSsoId;
         }
      }

      public static string DefaultLanguageCode
      {
         get
         {
            if (_defaultLanguageCode == null)
               _defaultLanguageCode = ConfigurationManager.AppSettings["DefaultLanguageCode"];

            return _defaultLanguageCode;
         }
      }
   }
}