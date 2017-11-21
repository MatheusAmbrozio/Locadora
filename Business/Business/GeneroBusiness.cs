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
    public class GeneroBusiness : IGeneroBusiness
    {
        #region CONSTRUTOR E PROPRIEDADES
        private readonly IGeneroRepository _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public GeneroBusiness(IGeneroRepository repository)
        {
            _repository = repository;
        }

        #endregion CONSTRUTOR E PROPRIEDADES

        #region CONSULTAS



        /// <summary>
        /// Metodo que recupera um genero pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Genero Recuperar(Guid id)
        {
            return _repository.Recuperar(id);
        }

        /// <summary>
        /// Metodo que recupera o genero pelo seu nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Genero RecuperarPorNome(string nome)
        {
            return _repository.RecuperarPorNome(nome);
        }

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Genero>  RecuperarDapper()
        {
            return _repository.RecuperarDapper();
        }

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um genero
        /// </summary>
        /// <param name="genero"></param>
        public void Salvar(Genero genero)
        {
            _repository.Salvar(genero);
        }

        /// <summary>
        /// Metodo que altera um genero
        /// </summary>
        /// <param name="genero"></param>
        public void Alterar(Genero genero)
        {
            _repository.Alterar(genero);
        }

        /// <summary>
        /// Metodo que remove um genero
        /// </summary>
        /// <param name="genero"></param>
        public void Deletar(Genero genero)
        {
            _repository.Deletar(genero);
        }

        #endregion AÇÕES
    }
}
