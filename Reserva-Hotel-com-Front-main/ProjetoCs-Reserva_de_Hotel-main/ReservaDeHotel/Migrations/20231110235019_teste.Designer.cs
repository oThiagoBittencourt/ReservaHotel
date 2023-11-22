﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservaDeHotel.Data;

#nullable disable

namespace ReservaDeHotel.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20231110235019_teste")]
    partial class teste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("AvaliacaoHotel", b =>
                {
                    b.Property<int>("HoteisIDHotel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ListaAvaliacoesIdAvaliacao")
                        .HasColumnType("INTEGER");

                    b.HasKey("HoteisIDHotel", "ListaAvaliacoesIdAvaliacao");

                    b.HasIndex("ListaAvaliacoesIdAvaliacao");

                    b.ToTable("AvaliacaoHotel");
                });

            modelBuilder.Entity("CidadeHotel", b =>
                {
                    b.Property<int>("CidadesIdCidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HoteisIDHotel")
                        .HasColumnType("INTEGER");

                    b.HasKey("CidadesIdCidade", "HoteisIDHotel");

                    b.HasIndex("HoteisIDHotel");

                    b.ToTable("CidadeHotel");
                });

            modelBuilder.Entity("DonoHotel", b =>
                {
                    b.Property<int>("DonosIdDono")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HoteisIDHotel")
                        .HasColumnType("INTEGER");

                    b.HasKey("DonosIdDono", "HoteisIDHotel");

                    b.HasIndex("HoteisIDHotel");

                    b.ToTable("DonoHotel");
                });

            modelBuilder.Entity("EstadiaHotelReservaHotel", b =>
                {
                    b.Property<int>("EstadiasIdEstadia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReservasIdReserva")
                        .HasColumnType("INTEGER");

                    b.HasKey("EstadiasIdEstadia", "ReservasIdReserva");

                    b.HasIndex("ReservasIdReserva");

                    b.ToTable("EstadiaHotelReservaHotel");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.Avaliacao", b =>
                {
                    b.Property<int?>("IdAvaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AvaliacaoEstrelas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comentario")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataAvaliacao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HotelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdAvaliacao");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.Cidade", b =>
                {
                    b.Property<int?>("IdCidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("País")
                        .HasColumnType("TEXT");

                    b.HasKey("IdCidade");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.Cliente", b =>
                {
                    b.Property<int?>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NumeroTelefone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.Comodidade", b =>
                {
                    b.Property<int?>("IDComodidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Disponibilidade")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HotelId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NumeroDoQuarto")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("PrecoPorNoite")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoDeQuarto")
                        .HasColumnType("TEXT");

                    b.HasKey("IDComodidade");

                    b.HasIndex("HotelId");

                    b.ToTable("Comodidade");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.Dono", b =>
                {
                    b.Property<int>("IdDono")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroTelefone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.HasKey("IdDono");

                    b.ToTable("Dono");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.EstadiaHotel", b =>
                {
                    b.Property<int?>("IdEstadia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataEntrada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataSaida")
                        .HasColumnType("TEXT");

                    b.Property<int?>("QtdQuartos")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdEstadia");

                    b.ToTable("EstadiaHotel");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.Hotel", b =>
                {
                    b.Property<int>("IDHotel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("ListaDeQuartos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroDeQuartosDisponiveis")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumeroTotalDeQuartos")
                        .HasColumnType("INTEGER");

                    b.HasKey("IDHotel");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.Pagamento", b =>
                {
                    b.Property<int?>("IdPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("MetodoPagamento")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("IdPagamento");

                    b.HasIndex("ReservaId");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.ReservaHotel", b =>
                {
                    b.Property<int?>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeHospede")
                        .HasColumnType("TEXT");

                    b.HasKey("IdReserva");

                    b.ToTable("ReservaHotel");
                });

            modelBuilder.Entity("AvaliacaoHotel", b =>
                {
                    b.HasOne("ReservaDeHotel.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HoteisIDHotel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservaDeHotel.Models.Avaliacao", null)
                        .WithMany()
                        .HasForeignKey("ListaAvaliacoesIdAvaliacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CidadeHotel", b =>
                {
                    b.HasOne("ReservaDeHotel.Models.Cidade", null)
                        .WithMany()
                        .HasForeignKey("CidadesIdCidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservaDeHotel.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HoteisIDHotel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DonoHotel", b =>
                {
                    b.HasOne("ReservaDeHotel.Models.Dono", null)
                        .WithMany()
                        .HasForeignKey("DonosIdDono")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservaDeHotel.Models.Hotel", null)
                        .WithMany()
                        .HasForeignKey("HoteisIDHotel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EstadiaHotelReservaHotel", b =>
                {
                    b.HasOne("ReservaDeHotel.Models.EstadiaHotel", null)
                        .WithMany()
                        .HasForeignKey("EstadiasIdEstadia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservaDeHotel.Models.ReservaHotel", null)
                        .WithMany()
                        .HasForeignKey("ReservasIdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReservaDeHotel.Models.Comodidade", b =>
                {
                    b.HasOne("ReservaDeHotel.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.Pagamento", b =>
                {
                    b.HasOne("ReservaDeHotel.Models.ReservaHotel", "Reserva")
                        .WithMany("Pagamento")
                        .HasForeignKey("ReservaId");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("ReservaDeHotel.Models.ReservaHotel", b =>
                {
                    b.Navigation("Pagamento");
                });
#pragma warning restore 612, 618
        }
    }
}
