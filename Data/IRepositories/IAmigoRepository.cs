using LocadoraS2IT.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraS2IT.Data.IRepositories
{
    public interface IAmigoRepository
    {

        #region CONSULTAS
        /// <summary>
        /// Metodo que recupera um amigo pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Amigo Recuperar(Guid id);

        /// <summary>
        /// Metodo que recupera o amigo pelo seu nome
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
        /// Metodo que salva um amigo
        /// </summary>
        /// <param name="amigo"></param>
        void Salvar(Amigo amigo);

        /// <summary>
        /// Metodo que altera um amigo
        /// </summary>
        /// <param name="amigo"></param>
        void Alterar(Amigo amigo);

        /// <summary>
        /// Metodo que deleta um Amigo
        /// </summary>
        /// <param name="amigo"></param>
        void Deletar(Amigo amigo);

        #endregion AÇÕES

    }
}
