using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraS2IT.Shared.Entities;

namespace LocadoraS2IT.Data.IRepositories
{
    public interface IGeneroRepository
    {
        #region CONSULTAS
        /// <summary>
        /// Metodo que recupera um genero pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Genero Recuperar(Guid id);

        /// <summary>
        /// Metodo que recupera o genero pelo seu nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        Genero RecuperarPorNome(string nome);

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        IEnumerable<Genero> RecuperarDapper();

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um genero
        /// </summary>
        /// <param name="genero"></param>
        void Salvar(Genero genero);

        /// <summary>
        /// Metodo que altera um genero
        /// </summary>
        /// <param name="genero"></param>
        void Alterar(Genero genero);

        /// <summary>
        /// Metodo que remove um genero
        /// </summary>
        /// <param name="genero"></param>
        void Deletar(Genero genero);

        #endregion AÇÕES
    }
}
