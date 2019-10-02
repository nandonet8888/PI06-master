using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using PI06.Data.Models.Entity;
using PI06.Models.Entity;

namespace PI06.Data.Context {
    public class Contexto : DbContext {
        
        public Contexto (DbContextOptions<Contexto> options) : base (options) { }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Conselho> Conselho { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<TipoExame> TipoExame { get; set; }
        public DbSet<TipoProcedimento> TipoProcedimento { get; set; }

        public DbSet<Cirurgia> cirurgia { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            foreach (var relacionamento in modelBuilder.Model.GetEntityTypes().SelectMany( e=> e.GetForeignKeys()))
            {
                relacionamento.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ForSqlServerUseIdentityColumns ();
            modelBuilder.HasDefaultSchema ("dbo");

            modelBuilder.Entity<Pessoa> (mb => {
                mb.ToTable ("Pessoa");
                mb.HasKey (c => c.Id).HasName ("IdPessoa");
                mb.Property (c => c.Id).HasColumnName ("IdPessoa").ValueGeneratedOnAdd ();
                mb.Property (c => c.Nome)
                    .IsRequired ()
                    .HasMaxLength (300);
                mb.Property (f => f.DataNascimento).IsRequired ();
                mb.Property (f => f.EnderecoEmail)
                    .IsRequired ()
                    .HasMaxLength (150);
                mb.Property (f => f.Bairro).IsRequired ();
                mb.Property (f => f.Cidade).IsRequired ();
                mb.Property (f => f.Logradouro).IsRequired ();
                mb.Property (f => f.NumeroEndereco).IsRequired ();
                mb.Property (f => f.Uf).IsRequired ();
                mb.Property (f => f.Complemento);
                mb.Property (f => f.CodigoCpf).IsRequired ();

            });

            modelBuilder.Entity<Funcionario> (mb => {
                mb.ToTable ("Funcionario");
                mb.HasKey (c => c.Id).HasName ("IdFuncionario");
                mb.Property (c => c.Id).HasColumnName ("IdFuncionario").IsRequired();
                mb.Property (f => f.DataContratacao).IsRequired ();
                mb.Property (f => f.DataDemissao).HasDefaultValue (null);
                mb.HasOne(d => d.Pessoa)
                    .WithOne(p => p.Funcionario)
                    .HasForeignKey<Funcionario>(d => d.Id)
                    .HasConstraintName("PFK_PessoaFuncionario");
                mb.HasOne(d => d.Cargo)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK_Cargo").OnDelete(DeleteBehavior.Restrict);
                  

            });

            modelBuilder.Entity<Usuario> (mb => {
                mb.ToTable ("Usuario");
                mb.HasKey (c => c.Id).HasName ("IdUsuario");
                mb.Property(c => c.Id).HasColumnName("IdUsuario").IsRequired();
                mb.Property (f => f.Login).IsRequired ();
                mb.Property (f => f.Senha).IsRequired ();
                mb.Property (f => f.TokenAlteracaoDeSenha).IsRequired ();
                mb.HasOne(d => d.Funcionario)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.Id)
                    .HasConstraintName("PFK_PessoaFuncionarioUsuario");
            });

            modelBuilder.Entity<Conselho> (mb => {
                mb.ToTable ("Conselho");
                mb.HasKey (c => c.Id).HasName ("IdConselho");
                mb.Property (c => c.Id).HasColumnName ("IdConselho").IsRequired();
                mb.Property (f => f.DescricaoConselho).IsRequired ();
                mb.Property (f => f.NumeroConselho).IsRequired ();
                mb.HasOne(d => d.Funcionario)
                    .WithOne(p => p.Conselho)
                    .HasForeignKey<Conselho>(d => d.Id)
                    .HasConstraintName("PFK_PessoaFuncionarioConselho");
            });

            modelBuilder.Entity<Cargo> (mb => {
                mb.ToTable ("Cargo");
                mb.HasKey (c => c.Id).HasName ("IDCargo");
                mb.Property (c => c.Id).HasColumnName ("IDCargo")
                    .ValueGeneratedOnAdd ();
                mb.Property (f => f.DescricaoCargo).IsRequired ();
                mb.Property (f => f.IsHealthProfession).IsRequired ();
            });
            /*e.hasone (d=>d.pessoa).withone (p=>p.aluno).hasforeignkey<Aluno>(d=> d.idpessoa).
             * hasconstraintName("PFK_pessoaAluno);"
            
            e.hasone (d=>d.Curso).withmany (p=>p.aluno).hasforeignkey(d=> d.idCurso).
             * hasconstraintName("FK_CursoAluno);"

             */
             //Fernando
            modelBuilder.Entity<Consulta>(pro => {
                pro.ToTable("Consulta");
                pro.HasKey(c => c.Id).HasName("IdConsulta");
                pro.Property(c => c.Id).HasColumnName("IdConsulta")
                .ValueGeneratedOnAdd();
                pro.Property(c => c.dataInicio).IsRequired();
                pro.Property(c => c.dataTermino).HasDefaultValue(null);
                pro.Property(c => c.diagnostico).IsRequired();
                pro.Property(c => c.medicacao).IsRequired();
                pro.HasOne(d => d.Funcionario)
                    .WithOne(p => p.consulta)
                    .HasForeignKey<Consulta>(a => a.Id)
                    .HasConstraintName("FK_FuncionarioConsulta");

                pro.HasOne(d => d.Paciente)
                   .WithMany(p => p.Prontuarios)
                   .HasForeignKey(d => d.IdPaciente)
                   .HasConstraintName("FK_PacienteConsulta")
                   .OnDelete(DeleteBehavior.Restrict); 


            });
            modelBuilder.Entity<TipoExame>(te => {
                te.ToTable("TipoExame");
                te.HasKey(c => c.Id).HasName("IdTipoExame");
                te.Property(c => c.Id).HasColumnName("IdtipoExame").ValueGeneratedOnAdd();
                te.Property(c => c.Descricao).IsRequired();
                te.Property(c => c.ResultadoReferencia).IsRequired();
                    

            });
            modelBuilder.Entity<TipoProcedimento>(tp => {
                tp.ToTable("TipoProcedimento");
                tp.HasKey(c => c.Id).HasName("IdtipoProcedimento");
                tp.Property(c => c.Id).HasColumnName("IdtipoProcedimento").ValueGeneratedOnAdd();
                tp.Property(c => c.descricao).IsRequired();

            });

            modelBuilder.Entity<Cirurgia>(ci => {
                ci.ToTable("Cirurgia");
                ci.HasKey(c => c.Id).HasName("IdCirurgiaProcedimento");
                ci.HasOne(d => d.procedimento)
                .WithOne(p => p.cirurgia)
                .HasForeignKey<Cirurgia>(d => d.Id)
                .HasConstraintName("PFK_ProcedimentoCirurgia");
                ci.Property(c => c.descricao).IsRequired();


            });

            modelBuilder.Entity<Exame>(ex => {
                ex.ToTable("Exame");
                ex.HasKey(c => c.Id).HasName("IdExame");
                ex.Property(c => c.Id).HasColumnName("IdExame");
                ex.Property(e => e.resultado).IsRequired();
                ex.HasOne(p => p.procedimento)
                .WithOne(p => p.exame)
                .HasForeignKey<Exame>(a => a.Id).HasConstraintName("PFK_ProcedimentoExame");
             

            });



            modelBuilder.Entity<Procedimento>(proc => {
                proc.ToTable("Procedimento");
                proc.HasKey(c => c.Id).HasName("IdProcedimento");
                proc.Property(c => c.Id).HasColumnName("idProcedimento");
                proc.Property(e => e.observacao).IsRequired();
                proc.HasOne(d => d.consulta)
                   .WithMany(p => p.procedimentos)
                   .HasForeignKey(d => d.idProcedimento)
                   .HasConstraintName("FK_Consulta").OnDelete(DeleteBehavior.Restrict);


            });




            //Fim Fernando

        }
    }
}