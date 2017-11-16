using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        [DisplayName("Chave")]
        public int ContatoId { get; set; }

        [DisplayName("Contato")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do campo é 100 caracteres.")]
        public string Informacao { get; set; }

        [DisplayName("Observação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(1000, ErrorMessage = "O tamanho máximo do campo é 1000 caracteres.")]
        public string Observacao { get; set; }

        [DisplayName("Pessoa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int PessoaId { get; set; }
        [DisplayName("Pessoa")]
        public PessoaViewModel Pessoa { get; set; }

        [DisplayName("Tipo de Contato")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public TipoContato TipoContato { get; set; }

        public override string ToString()
        {
            return Observacao;
        }
    }

    public enum TipoContato
    {
        Residencial,
        Comercial,
        Celular,
        WhatsApp,
        Email,
        Outro
    }
}