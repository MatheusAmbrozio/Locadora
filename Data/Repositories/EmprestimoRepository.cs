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
    public class EmprestimoRepository : IEmprestimoRepository
    {
        #region CONSTRUTOR E PROPRIEDADES
        private readonly LocadoraS2ITDataContext _context;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        public EmprestimoRepository(LocadoraS2ITDataContext context)
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
        public Emprestimo Recuperar(Guid id)
        {
            return _context
                .Emprestimo
                .Include(x=>x.Amigo)
                .Include(x => x.Jogo)
                .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Metodo que retorna emprestimos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Emprestimo> RecuperarEmprestimos()
        {
            return _context
                .Emprestimo
                .Include(x => x.Amigo)
                .Include(x => x.Jogo)
                .AsEnumerable();
        }

        /// <summary>
        /// Metodo que exemplifica uma consulta dapper
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Emprestimo> RecuperarDapper()
        {
            var query = "SELECT * FROM [Emprestimo]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<Emprestimo>(query)
                    .ToList();
            }
        }

        #endregion CONSULTAS

        #region AÇÕES
        /// <summary>
        /// Metodo que salva um emprestimo
        /// </summary>
        /// <param name="emprestimo"></param>
        public void Salvar(Emprestimo emprestimo)
        {
            emprestimo.GerarId();
            emprestimo.Amigo = _context.Amigo.Find(emprestimo.Amigo.Id);
            emprestimo.Jogo = _context.Jogo.Find(emprestimo.Jogo.Id);
            _context.Emprestimo.Add(emprestimo);
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo que altera um emprestimo
        /// </summary>
        /// <param name="emprestimo"></param>
        public void Alterar(Emprestimo emprestimo)
        {
            _context.Entry(emprestimo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Metodo que remover um emprestimo
        /// </summary>
        /// <param name="emprestimo"></param>
        public void Deletar(Emprestimo emprestimo)
        {
            _context.Entry(Recuperar(emprestimo.Id)).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        #endregion AÇÕES
    }
}
