namespace Dcf.Kids.WiKids.Data.Models.ThirdParties
{
   /// <summary>
   /// This is a model to hold the Third Party Phone data.
   /// </summary>
   /// <seealso cref="Dcf.Kids.WiKids.Data.Models.ThirdParties.IThirdPartyPhone" />
   public class ThirdPartyPhone : IThirdPartyPhone
   {
      public string id_part { get; set; }

      public string cd_tel_type { get; set; }

      public string nb_tel_acd { get; set; }

      public string nb_tel_exc { get; set; }

      public string nb_tel_ln { get; set; }
   }
}