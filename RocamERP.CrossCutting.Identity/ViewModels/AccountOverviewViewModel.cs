using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.CrossCutting.Identity.ViewModels
{
    public class OverviewViewModel
    {
        [DisplayName("Endereço de Email Confirmado")]
        public bool EmailConfirmed { get; set; }

        [DisplayName("Autenticação em dois passos ativada")]
        public bool TwoFactorEnabled { get; set; }

        [DisplayName("Número de Telefone Confirmado")]
        public bool PhoneNumberConfirmed { get; set; }

        [DisplayName("Número de Telefone")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Nenhum número cadastrado")]
        public string PhoneNumber { get; set; }

        [DisplayName("Logins Externos")]
        public ICollection<UserLoginInfo> Logins { get; set; }


        public OverviewViewModel()
        {
            Logins = new List<UserLoginInfo>();
        }
    }
}
