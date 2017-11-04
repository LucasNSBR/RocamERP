using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class CadastroEstadualViewModel
    {
        [Key]
        [MaxLength(14, ErrorMessage = "O tamanho máximo para o campo é 14 caracteres.")]
        [MinLength(11, ErrorMessage = "O tamanho mínimo para o campo é 11 caracteres.")]
        [Remote("ValidateCadastroEstadual", "Pessoa", ErrorMessage = "O campo deve ter 10 ou 12 caracteres.")]
        public string NumeroDocumento { get; set; }

        [Required]
        [DisplayName("Tipo de documento")]
        public TipoCadastroEstadual TipoCadastroEstadual { get; set; }

        [Required]
        public int PessoaId { get; set; }
        public PessoaViewModel Pessoa { get; set; }

        public override string ToString()
        {
            return NumeroDocumento;
        }
    }

    public enum TipoCadastroEstadual
    {
        RG,
        InscricaoEstadual,
        Isento,
        Outro
    }
}