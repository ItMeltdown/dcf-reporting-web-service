using System;

namespace Dcf.Kids.WiKids.Data.Models.Participant
{
   public class Participant : IParticipant
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Suffix { get; set; }
      public DateTime DateOfBirth { get; set; }
   }
}
