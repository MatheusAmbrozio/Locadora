using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraS2IT.Shared.Entities;

namespace LocadoraS2IT.Business.IBusiness
{
    public interface IEmprestimoBusiness
    {
        #region CONSULTAS
        /// <summary>
        /// Metodo que recupera um emprestimo pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Emprestimo Recuperar(Guid id);

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        IEnumerable<Emprestimo> RecuperarDapper();

        /// <summary>
        /// Metodo que retorna emprestimos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Emprestimo> RecuperarEmprestimos();

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um emprestimo
        /// </summary>
        /// <param name="emprestimo"></param>
        void Salvar(Emprestimo emprestimo);

        /// <summary>
        /// Metodo que altera um emprestimo
        /// </summary>
        /// <param name="emprestimo"></param>
        void Alterar(Emprestimo emprestimo);

        /// <summary>
        /// Metodo que remove um emprestimo
        /// </summary>
        /// <param name="emprestimo"></param>
        void Deletar(Emprestimo emprestimo);

        #endregion AÇÕES
    }
}
