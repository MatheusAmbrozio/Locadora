using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraS2IT.Shared.Entities;

namespace LocadoraS2IT.Business.IBusiness
{
    public interface IJogoBusiness
    {
        #region CONSULTAS
        /// <summary>
        /// Metodo que recupera um jogo pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Jogo Recuperar(Guid id);

        /// <summary>
        /// Metodo que recupera o jogo pelo seu nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        Jogo RecuperarPorNome(string nome);

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        IEnumerable<Jogo> RecuperarDapper();

        /// <summary>
        /// Metodo que retorna jogos disponiveis para emprestimos
        /// </summary>
        /// <returns></returns>
        IEnumerable<Jogo> RecuperarDisponiveis();

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um jogo
        /// </summary>
        /// <param name="jogo"></param>
        void Salvar(Jogo jogo);

        /// <summary>
        /// Metodo que altera um jogo
        /// </summary>
        /// <param name="jogo"></param>
        void Alterar(Jogo jogo);

        /// <summary>
        /// Metodo que Deletar um jogo
        /// </summary>
        /// <param name="jogo"></param>
        void Deletar(Jogo jogo);
        

        #endregion AÇÕES
    }
}
