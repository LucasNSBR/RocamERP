﻿namespace RocamERP.Domain.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        
        public string CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
        
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual TipoEndereco TipoEndereco { get; set; }

        public override string ToString()
        {
            return $"{Rua}, {Numero}, {Bairro} em {Cidade}";
        }
    }

    public enum TipoEndereco
    {
        Comercial,
        Residencial,
        Rural,
        Outro, 
    }

}