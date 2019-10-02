using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PI06.Data.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Cargo",
                schema: "dbo",
                columns: table => new
                {
                    IDCargo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    DescricaoCargo = table.Column<string>(nullable: false),
                    IsHealthProfession = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IDCargo", x => x.IDCargo);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "dbo",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 300, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Rg = table.Column<string>(nullable: false),
                    Sus = table.Column<int>(nullable: false),
                    CodigoCpf = table.Column<long>(nullable: false),
                    EnderecoEmail = table.Column<string>(maxLength: 150, nullable: false),
                    Logradouro = table.Column<string>(nullable: false),
                    Complemento = table.Column<string>(nullable: true),
                    NumeroEndereco = table.Column<string>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Uf = table.Column<int>(nullable: false),
                    NumeroTelefone = table.Column<long>(nullable: false),
                    DDD = table.Column<int>(nullable: false),
                    CepCod = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdPessoa", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "TipoExame",
                schema: "dbo",
                columns: table => new
                {
                    IdtipoExame = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: false),
                    ResultadoReferencia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdTipoExame", x => x.IdtipoExame);
                });

            migrationBuilder.CreateTable(
                name: "TipoProcedimento",
                schema: "dbo",
                columns: table => new
                {
                    IdtipoProcedimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdtipoProcedimento", x => x.IdtipoProcedimento);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                schema: "dbo",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    DataContratacao = table.Column<DateTime>(nullable: false),
                    DataDemissao = table.Column<DateTime>(nullable: true),
                    IdCargo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdFuncionario", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "PFK_PessoaFuncionario",
                        column: x => x.IdFuncionario,
                        principalSchema: "dbo",
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cargo",
                        column: x => x.IdCargo,
                        principalSchema: "dbo",
                        principalTable: "Cargo",
                        principalColumn: "IDCargo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conselho",
                schema: "dbo",
                columns: table => new
                {
                    IdConselho = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    NumeroConselho = table.Column<int>(nullable: false),
                    DescricaoConselho = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdConselho", x => x.IdConselho);
                    table.ForeignKey(
                        name: "PFK_PessoaFuncionarioConselho",
                        column: x => x.IdConselho,
                        principalSchema: "dbo",
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                schema: "dbo",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    IdPaciente = table.Column<int>(nullable: false),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataTermino = table.Column<DateTime>(nullable: true),
                    diagnostico = table.Column<string>(nullable: false),
                    medicacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdConsulta", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_FuncionarioConsulta",
                        column: x => x.IdConsulta,
                        principalSchema: "dbo",
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacienteConsulta",
                        column: x => x.IdPaciente,
                        principalSchema: "dbo",
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Login = table.Column<string>(nullable: false),
                    Senha = table.Column<byte[]>(nullable: false),
                    TokenAlteracaoDeSenha = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdUsuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "PFK_PessoaFuncionarioUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "dbo",
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                schema: "dbo",
                columns: table => new
                {
                    idProcedimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    observacao = table.Column<string>(nullable: false),
                    TipoProcedimentoId = table.Column<int>(nullable: true),
                    Procedimento_idProcedimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdProcedimento", x => x.idProcedimento);
                    table.ForeignKey(
                        name: "FK_Procedimento_TipoProcedimento_TipoProcedimentoId",
                        column: x => x.TipoProcedimentoId,
                        principalSchema: "dbo",
                        principalTable: "TipoProcedimento",
                        principalColumn: "IdtipoProcedimento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta",
                        column: x => x.Procedimento_idProcedimento,
                        principalSchema: "dbo",
                        principalTable: "Consulta",
                        principalColumn: "IdConsulta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cirurgia",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdCirurgiaProcedimento", x => x.Id);
                    table.ForeignKey(
                        name: "PFK_ProcedimentoCirurgia",
                        column: x => x.Id,
                        principalSchema: "dbo",
                        principalTable: "Procedimento",
                        principalColumn: "idProcedimento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                schema: "dbo",
                columns: table => new
                {
                    IdExame = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    resultado = table.Column<string>(nullable: false),
                    tipoExameId = table.Column<int>(nullable: true),
                    consultasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdExame", x => x.IdExame);
                    table.ForeignKey(
                        name: "PFK_ProcedimentoExame",
                        column: x => x.IdExame,
                        principalSchema: "dbo",
                        principalTable: "Procedimento",
                        principalColumn: "idProcedimento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exame_Consulta_consultasId",
                        column: x => x.consultasId,
                        principalSchema: "dbo",
                        principalTable: "Consulta",
                        principalColumn: "IdConsulta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exame_TipoExame_tipoExameId",
                        column: x => x.tipoExameId,
                        principalSchema: "dbo",
                        principalTable: "TipoExame",
                        principalColumn: "IdtipoExame",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                schema: "dbo",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_consultasId",
                schema: "dbo",
                table: "Exame",
                column: "consultasId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_tipoExameId",
                schema: "dbo",
                table: "Exame",
                column: "tipoExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdCargo",
                schema: "dbo",
                table: "Funcionario",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimento_TipoProcedimentoId",
                schema: "dbo",
                table: "Procedimento",
                column: "TipoProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimento_Procedimento_idProcedimento",
                schema: "dbo",
                table: "Procedimento",
                column: "Procedimento_idProcedimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cirurgia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Conselho",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Exame",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Procedimento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoExame",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoProcedimento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Consulta",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Funcionario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Paciente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cargo",
                schema: "dbo");
        }
    }
}
