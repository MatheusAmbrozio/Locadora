using Dapper;
using LocadoraS2IT.Data.Contexts;
using LocadoraS2IT.Data.IRepositories;
using LocadoraS2IT.Shared;
using LocadoraS2IT.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
namespace LocadoraS2IT.Data.Repositories
{
    public class AmigoRepository : IAmigoRepository 
    {
        #region CONSTRUTOR E PROPRIEDADES
        private readonly LocadoraS2ITDataContext _context;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public AmigoRepository(LocadoraS2ITDataContext context)
        {
            _context = context;
        }

        #endregion CONSTRUTOR E PROPRIEDADES

        #region CONSULTAS
        /// <summary>
        /// Metodo que recupera um Amigo pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Amigo Recuperar(Guid id)
        {
            return _context
                .Amigo
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Metodo que recupera o Amigo pelo seu nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Amigo RecuperarPorNome(string nome)
        {
            return _context
                .Amigo
                .AsNoTracking()
                .FirstOrDefault(x => x.Nome == nome);
        }

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Amigo> RecuperarDapper()
        {

            var query = "SELECT * FROM [Amigo]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<Amigo>(query)
                    .ToList();
            }
        }

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um Amigo
        /// </summary>
        /// <param name="amigo"></param>
        public void Salvar(Amigo amigo)
        {
            amigo.GerarId();
            _context.Amigo.Add(amigo);
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo que altera um Amigo
        /// </summary>
        /// <param name="amigo"></param>
        public void Alterar(Amigo amigo)
        {
            _context.Entry(amigo).State = EntityState.Modified;
            _context.SaveChanges();
        }


        /// <summary>
        /// Metodo que deleta um Amigo
        /// </summary>
        /// <param name="amigo"></param>
        public void Deletar(Amigo amigo)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                amigo = _context.Amigo.Find(amigo.Id);
                _context.Entry(amigo).State = EntityState.Deleted;
                _context.SaveChanges();
                var query = "DELETE [AspNetUsers] WHERE Email = @Email";
                using (var conn = new SqlConnection(Runtime.ConnectionString))
                {
                    conn.Open();
                    var i = conn
                        .Execute(query, new { Email = amigo.Email });

                    if (i == 1)
                    {
                        transactionScope.Complete();       
                    }
                }
            }
        }

        #endregion AÇÕES

    }
}
