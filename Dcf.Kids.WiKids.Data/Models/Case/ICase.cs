namespace Dcf.Kids.WiKids.Data.Models.Case
{
   public interface ICase
   {
      string CourtCaseNumber { get; set; }

      string County { get; set; }

      string CaseTypeDescription { get; set; }

      string PayeeParticipantId { get; set; }

      string PayerParticipantId { get; set; }
   }
}
