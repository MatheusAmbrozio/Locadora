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

namespace LocadoraS2IT.Data.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        #region CONSTRUTOR E PROPRIEDADES
        private readonly LocadoraS2ITDataContext _context;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public GeneroRepository(LocadoraS2ITDataContext context)
        {
            _context = context;
        }

        #endregion CONSTRUTOR E PROPRIEDADES

        #region CONSULTAS
        /// <summary>
        /// Metodo que recupera um cliente pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Genero Recuperar(Guid id)
        {
            return _context
                .Genero
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Metodo que recupera o genero pelo seu nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Genero RecuperarPorNome(string nome)
        {
            return _context
                .Genero
                .AsNoTracking()
                .FirstOrDefault(x => x.Nome == nome);
        }

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Genero> RecuperarDapper()
        {
            var query = "SELECT * FROM [Genero]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<Genero>(query)
                    .ToList();
            }
        }

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um genero
        /// </summary>
        /// <param name="genero"></param>
        public void Salvar(Genero genero)
        {
            genero.GerarId();
            _context.Genero.Add(genero);
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo que altera um genero
        /// </summary>
        /// <param name="genero"></param>
        public void Alterar(Genero genero)
        {
            _context.Entry(genero).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo que remover um genero
        /// </summary>
        /// <param name="genero"></param>
        public void Deletar(Genero genero)
        {
            _context.Entry(Recuperar(genero.Id)).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        #endregion AÇÕES
    }
}
