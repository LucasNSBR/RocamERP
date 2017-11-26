﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RocamERP.Presentation.Web.ViewModels.PessoaViewModels
{
    public class PessoaViewModel
    {
        [Key]
        [DisplayName("Chave")]
        public int PessoaId { get; set; }

        [DisplayName("Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo é requerido.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo para o campo é de 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Não registrado.")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo para o campo é de 1000 caracteres.")]
        public string Descricao { get; set; }

        [DisplayName("Contatos")]
        public ICollection<ContatoViewModel> Contatos { get; set; }
        [DisplayName("Cheques")]
        public ICollection<ChequeViewModel> Cheques { get; set; }
        [DisplayName("Endereços")]
        public ICollection<EnderecoViewModel> Enderecos { get; set; }

        [DisplayName("Cadastro Estadual")]
        public CadastroEstadualViewModel CadastroEstadual { get; set; }
        [DisplayName("Cadastro Nacional")]
        public CadastroNacionalViewModel CadastroNacional { get; set; }

        public override string ToString()
        {
            return Nome;
        }

        public PessoaViewModel()
        {
            Enderecos = new List<EnderecoViewModel>();
            Contatos = new List<ContatoViewModel>();
            Cheques = new List<ChequeViewModel>();
        }
    }
}