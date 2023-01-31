using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Projetomvc.Models;

namespace Projetomvc.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) :base (options)
        {

        }   

        public DbSet<Contato> Contatos{get;set;}
    }
}