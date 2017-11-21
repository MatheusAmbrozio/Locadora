using LocadoraS2IT.Shared.Entities;
using System;
using System.Collections.Generic;

namespace LocadoraS2IT.Business.IBusiness
{
    public interface IAmigoBusiness
    {

        #region CONSULTAS
        /// <summary>
        /// Metodo que recupera um cliente pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Amigo Recuperar(Guid id);

        /// <summary>
        /// Metodo que recupera o cliente pelo seu nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        Amigo RecuperarPorNome(string nome);

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        IEnumerable<Amigo> RecuperarDapper();

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um cliente
        /// </summary>
        /// <param name="amigo"></param>
        void Salvar(Amigo amigo);

        /// <summary>
        /// Metodo que altera um cliente
        /// </summary>
        /// <param name="amigo"></param>
        void Alterar(Amigo amigo);

        /// <summary>
        /// Metodo que Deletar um cliente
        /// </summary>
        /// <param name="amigo"></param>
        void Deletar(Amigo amigo);

        #endregion AÇÕES

    }
}
