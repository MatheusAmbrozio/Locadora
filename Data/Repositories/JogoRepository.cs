using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LocadoraS2IT.Data.Contexts;
using LocadoraS2IT.Data.IRepositories;
using LocadoraS2IT.Shared;
using LocadoraS2IT.Shared.Entities;

namespace LocadoraS2IT.Data.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        #region CONSTRUTOR E PROPRIEDADES
        private readonly LocadoraS2ITDataContext _context;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public JogoRepository(LocadoraS2ITDataContext context)
        {
            _context = context;
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
            return _context
                .Jogo
                .Include(x => x.Genero)
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Metodo que recupera o jogo pelo seu nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public Jogo RecuperarPorNome(string nome)
        {
            return _context
                .Jogo
                .AsNoTracking()
                .FirstOrDefault(x => x.Nome == nome);
        }

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Jogo> RecuperarDapper()
        {

            var query = "SELECT * FROM [Jogo]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<Jogo>(query)
                    .ToList();
            }
        }

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Jogo> RecuperarDisponiveis()
        {

            var query = "SELECT * FROM[LocadoraS2IT].[dbo].[Jogo] J LEFT JOIN[dbo].[Emprestimo] E ON E.Jogo_Id = J.[Id] WHERE E.Jogo_Id IS NULL";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<Jogo>(query)
                    .ToList();
            }
        }

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Salvar(Jogo jogo)
        {
            jogo.GerarId();
            jogo.Genero = _context.Genero.Find(jogo.Genero.Id);
            _context.Jogo.Add(jogo);

            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo que altera um jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Alterar(Jogo jogo)
        {

            _context.Entry(jogo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo que deleta um jogo
        /// </summary>
        /// <param name="jogo"></param>
        public void Deletar(Jogo jogo)
        {
            jogo = _context.Jogo.Find(jogo.Id);
            _context.Entry(jogo).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        #endregion AÇÕES
    }
}
