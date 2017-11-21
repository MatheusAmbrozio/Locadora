using LocadoraS2IT.Business.IBusiness;
using LocadoraS2IT.Data.IRepositories;
using LocadoraS2IT.Shared.Entities;
using System;
using System.Collections.Generic;

namespace LocadoraS2IT.Business.Business
{
    public class AmigoBusiness : IAmigoBusiness
    {

        #region CONSTRUTOR E PROPRIEDADES
        private readonly IAmigoRepository _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public AmigoBusiness(IAmigoRepository repository)
        {
            _repository = repository;
        }

        #endregion CONSTRUTOR E PROPRIEDADES

        #region CONSULTAS

      

        /// <summary>
        /// Metodo que recupera um cliente pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Amigo Recuperar(Guid id)
        {
            return _repository.Recuperar(id);
        }

        /// <summary>
        /// Metodo que recupera o cliente pelo seu nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Amigo RecuperarPorNome(string nome)
        {
            return _repository.RecuperarPorNome(nome);
        }

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Amigo> RecuperarDapper()
        {
            return _repository.RecuperarDapper();
        }

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um cliente
        /// </summary>
        /// <param name="amigo"></param>
        public void Salvar(Amigo amigo)
        {
            _repository.Salvar(amigo);
        }

        /// <summary>
        /// Metodo que altera um cliente
        /// </summary>
        /// <param name="amigo"></param>
        public void Alterar(Amigo amigo)
        {
            _repository.Alterar(amigo);
        }

        /// <summary>
        /// Metodo que Deletar um cliente
        /// </summary>
        /// <param name="amigo"></param>
        public void Deletar(Amigo amigo)
        {
            _repository.Deletar(amigo);
        }

        #endregion AÇÕES


    }
}
