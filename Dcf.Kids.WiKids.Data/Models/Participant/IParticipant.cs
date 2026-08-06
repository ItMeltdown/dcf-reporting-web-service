using System;

namespace Dcf.Kids.WiKids.Data.Models.Participant
{
   public interface IParticipant
   {
      string FirstName { get; set; }

      string LastName { get; set; }

      string Suffix { get; set; }

      DateTime DateOfBirth { get; set; }
   }
}
