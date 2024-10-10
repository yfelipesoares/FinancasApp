using FinancasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM (Mapeamento Objeto / Relacional) para a entidade Conta
    /// </summary>
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("TB_CONTA");

            builder.HasKey(c => c.Id);

            //Mapeamento dos campos da tabela

            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(c => c.Data).HasColumnName("DATA").IsRequired();
            builder.Property(c => c.Valor).HasColumnName("VALOR").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(c => c.CategoriaId).HasColumnName("CATEGORIA_ID").IsRequired();
            builder.Property(c => c.UsuarioId).HasColumnName("USUARIO_ID").IsRequired();

            //mapeamento dos relacionamentos

            builder.HasOne(c => c.Categoria) //Conta tem 1 Categoria
                .WithMany(c => c.Contas) //Categoria TEM muitas Contas
                .HasForeignKey(c => c.CategoriaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //Não permitir exclusão em cascata

            builder.HasOne(c => c.Usuario) //Conta tem 1 Usuario
                .WithMany(u => u.Contas) //usuario TEM muitas contas
                .HasForeignKey(c => c.UsuarioId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //Não permirtir exclusão em cascata
        }
    }
}
