﻿namespace RocamERP.Domain.Models
{
    public class CadastroEstadual
    {
        public string NumeroDocumento { get; set; }
        public TipoCadastroEstadual TipoCadastroEstadual { get; set; }
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
