using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dados
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Avaliacao> Avaliacaos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Filme> Filmes { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Ingresso> Ingressos { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Poltrona> Poltronas { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<Sessao> Sessaos { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ASDKP;Initial Catalog=Cinema2022;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.ToTable("Avaliacao");

                entity.Property(e => e.Avaliacao1)
                    .HasMaxLength(100)
                    .HasColumnName("avaliacao");

                entity.Property(e => e.TotalAvaliacao).HasColumnName("totalAvaliacao");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Pessoa");

                entity.HasOne(d => d.IdSexoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Sexo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Usuario");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.ToTable("Filme");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Destaque).HasColumnName("destaque");

                entity.Property(e => e.Imagem)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lancamento).HasColumnName("lancamento");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValorIngresso).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Filmes)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Filme_Empresa");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("Funcionario");

                entity.Property(e => e.Cnpj).HasMaxLength(50);

                entity.Property(e => e.Cpf).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Pessoa");

                entity.HasOne(d => d.IdSexoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Sexo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Usuario");
            });

            modelBuilder.Entity<Ingresso>(entity =>
            {
                entity.ToTable("Ingresso");

                entity.Property(e => e.ValorTotal).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.Ingressos)
                    .HasForeignKey(d => d.IdFilme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingresso_Filme");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Poltrona>(entity =>
            {
                entity.ToTable("Poltrona");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Poltronas)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK_Poltrona_Sala");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("Sala");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sessao>(entity =>
            {
                entity.ToTable("Sessao");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Horario).HasColumnType("datetime");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Sessaos)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK_Sessao_Sala");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.ToTable("Sexo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Papel)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
