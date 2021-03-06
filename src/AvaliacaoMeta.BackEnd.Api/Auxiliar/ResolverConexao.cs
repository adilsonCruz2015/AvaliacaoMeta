﻿using AvaliacaoMeta.BackEnd.Data.Persistencia.Interfaces;
using AvaliacaoMeta.BackEnd.Dominio.ObjetoDeValor;
using System.Collections.Generic;
using System.Configuration;

namespace AvaliacaoMeta.BackEnd.Api.Auxiliar
{
    public class ResolverConexao : IResolverConexao
    {
        private IDictionary<Banco, string> _resultado = new Dictionary<Banco, string>()
        {
            {Banco.AvaliacaoTailorit, "AvaliacaoTailorit" }
        };

        public string ObterConexao(Banco banco)
        {
            return ObterReferencia(ObterNomeDaConnectionString(banco));
        }

        public string ObterReferencia(string nome)
        {
            return ConfigurationManager.ConnectionStrings[nome].ToString();
        }

        private string ObterNomeDaConnectionString(Banco banco)
        {
            return _resultado[banco];
        }
    }
}