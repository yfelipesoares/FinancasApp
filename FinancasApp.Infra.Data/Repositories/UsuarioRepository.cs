﻿using FinancasApp.Domain.Entities;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario usuario)
        {
            //Abrindo a conexão com o banco de dados através do EntityFram
            using( var dataContext = new DataContext())
            {
                dataContext.Add(usuario); //adicionando usuário para gravação
                dataContext.SaveChanges();//executando a gravação do usuário
            }
        }

        public bool VerifyExists(string email)
        {
            //Abrindo a conexão com o banco de dados através do EntityFram
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Usuario>()
                    .Any(u => u.Email.Equals(email));
            }
        }
        public Usuario? Get(string email, string senha)
        {
           using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Usuario>()
                    .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                    .FirstOrDefault();
            }
        }

    }
}
