using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraS2IT.Business.IBusiness;
using LocadoraS2IT.Data.IRepositories;
using LocadoraS2IT.Shared.Entities;

namespace LocadoraS2IT.Business.Business
{
    public class JogoBusiness : IJogoBusiness
    {
        #region CONSTRUTOR E PROPRIEDADES
        private readonly IJogoRepository _repository;
        private readonly IGeneroRepository _repositoryGenero;
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public JogoBusiness(IJogoRepository repository, IGeneroRepository repositoryGenero)
        {
            _repository = repository;
            _repositoryGenero = repositoryGenero;
        }

        #endregion CONSTRUTOR E PROPRIEDADES

        #region CONSULTAS

        /// <summary>
        /// Metodo que recupera um jogo pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Jogo Recuperar(Guid id)
        {
            return _repository.Recuperar(id);
        }

        /// <summary>
        /// Metodo que recupera o jogo pelo seu nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Jogo RecuperarPorNome(string nome)
        {
            return _repository.RecuperarPorNome(nome);
        }

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Jogo> RecuperarDapper()
        {
            return _repository.RecuperarDapper();
        }

        /// <summary>
        /// Metodo que retorna jogos disponiveis para emprestimo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Jogo> RecuperarDisponiveis()
        {
            return _repository.RecuperarDisponiveis();
        }

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Salvar(Jogo jogo)
        {
            
            _repository.Salvar(jogo);
        }

        /// <summary>
        /// Metodo que altera um jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Alterar(Jogo jogo)
        {
            _repository.Alterar(jogo);
        }

        /// <summary>
        /// Metodo que altera um jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Deletar(Jogo jogo)
        {
            _repository.Deletar(jogo);
        }

        #endregion AÇÕES
    }
}
