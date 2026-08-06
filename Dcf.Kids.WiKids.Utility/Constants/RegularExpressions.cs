namespace Dcf.Kids.WiKids.Utility.Constants
{
   public static class RegularExpressions
   {
      public const string ParticipantId = @"^\d{10}$";
      public const string KidsCaseNumber = @"^\d{10}$";
      public const string CourtCaseNumber = @"^[0-9]{4}[A-Za-z]{2}[0-9]{5}(([0-9]{1})|([A-Za-z]{1}))([A-Za-z]{1})?";
      public const string ValidParticipantKidsCaseCourtCase = @"(^0+$)|(^[0-9]{4}([0-9]{6})?([A-Za-z]{2}[0-9]{5}(([0-9]{1})|([A-Za-z]{1}))([A-Za-z]{1})?)?$)";
      public const string MiddleInitial = @"^[A-Za-z]$";
      public const string Name = @"^([A-Za-z]|[-]|[']|[ ])+$";
      public const string Suffix = @"^(\s)|([A-Za-z0-9 ]){1,3}$";
      public const string Alphabet = @"^([A-Za-z])+$";
      public const string Numeric = @"^\d+$";
      public const string Year = @"^(\d{4})$";
      public const string SsnFull = @"^(\d{9})|(\d{3}-\d{2}-\d{4})$";
      public const string SsnLastFour = @"^(\d{4})$";
      public const string EmployerFEIN = @"^(\d{9})$";
      public const string Age = @"^(([1][01][0-9])|(120)|[1-9]|00[1-9]|0[1-9][0-9]|[0-9][1-9]|[1-9]0)$";
      public const string AlphaNumeric = @"^([A-Za-z]|[0-9])+$";
      public const string AlphaNumericAndSpecial = @"^([A-Za-z]|[0-9]|[~]|[`]|[!]|[@]|[#]|[$]|[%]|[\^]|[&]|[*]|[(]|[)]|[-]|[_]|[+]|[=]|[{]|[}]|[\[]|[\]]|[\\]|[:]|[;]|[""]|[']|[<]|[>]|[,]|[.]|[?]|[/]|[ ])+$";
      public const string AlphaNumericAndSpecial2 = @"^([A-Za-z]|[0-9]|[~]|[`]|[!]|[@]|[#]|[$]|[%]|[\^]|[&]|[*]|[(]|[)]|[-]|[_]|[+]|[=]|[{]|[}]|[\[]|[\]]|[\\]|[:]|[;]|[""]|[']|[<]|[>]|[,]|[.]|[?]|[/]|[ ]|[|])+$";
      public const string AlphaNumericSpecialNotPercentUnderscoreFirst = @"^(([A-Za-z0-9`~!@#$\^&*()+={}\[\]\\:;""'<>,.?/]|[-]){1}([\w`~!@#$%\^&*()+={}\[\]\\:;""'<>,.?/|[-]|[ ])*$)+$";
      public const string DateOrYear = @"^((\d{1,2}\/\d{1,2}\/(\d{2}|\d{4}))|(\d{4}))+$";
      public const string Email = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
      public const string ConsecutiveSpaces = @"[ ]{2}";
      public const string RawPhone = @"^\d{10}$";
      public const string WorkerId = @"^[a-zA-Z]{1}[a-zA-Z0-9]{2,7}$";
      public const string AlphaNumericSpecialNewline = @"^([A-Za-z]|[0-9]|[~]|[`]|[!]|[@]|[#]|[$]|[%]|[\^]|[&]|[*]|[(]|[)]|[-]|[_]|[+]|[=]|[{]|[}]|[\[]|[\]]|[\\]|[:]|[;]|[""]|[']|[<]|[>]|[,]|[.]|[?]|[/]|[ ]|[\s]|[|])+$";
      public const string Asterisk = @"^[^*]+$";
      public const string AreaCode = @"^(\s)|(\d{3})$";
      public const string PhoneExchange = @"^(\s)|(\d{3})$";
      public const string PhoneLine = @"^(\s)|(\d{4})$";
      public const string PhoneExt = @"^(\s)|(\d{1,4})$";
   }
}
