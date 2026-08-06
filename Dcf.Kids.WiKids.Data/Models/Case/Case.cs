namespace Dcf.Kids.WiKids.Data.Models.Case
{
   public class Case : ICase
   {
      public string CourtCaseNumber { get; set; }
      public string County { get; set; }
      public string CaseTypeDescription { get; set; }
      public string PayeeParticipantId { get; set; }
      public string PayerParticipantId { get; set; }
   }
}
