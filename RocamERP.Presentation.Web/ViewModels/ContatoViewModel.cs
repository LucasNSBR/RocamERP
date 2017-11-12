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

        [DisplayName("Observação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo do campo é 100 caracteres.")]
        public string Observacao { get; set; }

        [DisplayName("Pessoa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public int PessoaId { get; set; }
        [DisplayName("Pessoa")]
        public PessoaViewModel Pessoa { get; set; }

        [DisplayName("Tipo de Contato")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        public TipoContato TipoContato { get; set; }
        
        public IEnumerable<SelectListItem> TipoContatoList
        {
            get
            {
                List<SelectListItem> ListItems = new List<SelectListItem>();
                Enum.GetNames(typeof(TipoContato))
                    .ToList()
                    .ForEach(i => ListItems.Add(new SelectListItem { Text = i, Value = i }));
               
                return ListItems;
            }
        }

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