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
    public class EmprestimoBusiness :IEmprestimoBusiness
    {
        #region CONSTRUTOR E PROPRIEDADES
        private readonly IEmprestimoRepository _repository;
        private readonly IAmigoRepository _repositoryAmigo;
        private readonly IJogoRepository _repositoryJogo;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public EmprestimoBusiness(IEmprestimoRepository repository, IAmigoRepository repositoryAmigo, IJogoRepository repositoryJogo)
        {
            _repository = repository;
            _repositoryAmigo = repositoryAmigo;
            _repositoryJogo = repositoryJogo;
        }

        #endregion CONSTRUTOR E PROPRIEDADES

        #region CONSULTAS

        /// <summary>
        /// Metodo que recupera um emprestimo pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Emprestimo Recuperar(Guid id)
        {
            return _repository.Recuperar(id);
        }

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Emprestimo> RecuperarDapper()
        {
            return _repository.RecuperarDapper();
        }

        /// <summary>
        /// Metodo que retorna emprestimos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Emprestimo> RecuperarEmprestimos()
        {
            return _repository.RecuperarEmprestimos();
        }

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um emprestimo
        /// </summary>
        /// <param name="emprestimo"></param>
        public void Salvar(Emprestimo emprestimo)
        {
            _repository.Salvar(emprestimo);
        }

        /// <summary>
        /// Metodo que altera um emprestimo
        /// </summary>
        /// <param name="emprestimo"></param>
        public void Alterar(Emprestimo emprestimo)
        {
            _repository.Alterar(emprestimo);
        }

        /// <summary>
        /// Metodo que remove um emprestimo
        /// </summary>
        /// <param name="emprestimo"></param>
        public void Deletar(Emprestimo emprestimo)
        {
            _repository.Deletar(emprestimo);
        }

        #endregion AÇÕES
    }
}
