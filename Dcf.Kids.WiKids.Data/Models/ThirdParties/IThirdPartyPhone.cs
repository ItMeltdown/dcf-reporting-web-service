namespace Dcf.Kids.WiKids.Data.Models.ThirdParties
{
   public interface IThirdPartyPhone
   {
      string id_part { get; set; }

      string cd_tel_type { get; set; }

      string nb_tel_acd { get; set; }

      string nb_tel_exc { get; set; }

      string nb_tel_ln { get; set; }
   }
}