﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(CashAdminDbContext))]
    [Migration("20250123172003_DropFKinAttentionStatus")]
    partial class DropFKinAttentionStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ModelLayer.Models.AttentionModel", b =>
                {
                    b.Property<int>("AttentionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttentionId"));

                    b.Property<string>("AttentionTypeId")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("TurnId")
                        .HasColumnType("int");

                    b.HasKey("AttentionId")
                        .HasName("Attention_PK");

                    b.HasIndex("AttentionTypeId")
                        .IsUnique();

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("TurnId")
                        .IsUnique();

                    b.ToTable("Attentions");
                });

            modelBuilder.Entity("ModelLayer.Models.AttentionStatusModel", b =>
                {
                    b.Property<string>("Descrription")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.ToTable("AttentionsStatuses");
                });

            modelBuilder.Entity("ModelLayer.Models.AttentionTypeModel", b =>
                {
                    b.Property<string>("AttentionTypeId")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("AttentionDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AttentionTypeId")
                        .HasName("AttentionType_PK");

                    b.ToTable("AttentiontTypes");
                });

            modelBuilder.Entity("ModelLayer.Models.CashModel", b =>
                {
                    b.Property<int>("CashId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CashId"));

                    b.Property<string>("CashDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("active")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("CashId")
                        .HasName("Cash_PK");

                    b.ToTable("Cashs");
                });

            modelBuilder.Entity("ModelLayer.Models.ClientModel", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("ReferenceAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("identification")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("ClientId")
                        .HasName("Client_PK");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ModelLayer.Models.ContractModel", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("MethodPaymentId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("StatusContractId")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("ContractId")
                        .HasName("Contract_PK");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("MethodPaymentId")
                        .IsUnique();

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.HasIndex("StatusContractId")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("ModelLayer.Models.DeviceModel", b =>
                {
                    b.Property<int>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeviceId"));

                    b.Property<string>("DeviceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("DeviceId")
                        .HasName("Device_PK");

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("ModelLayer.Models.MethodPaymentModel", b =>
                {
                    b.Property<int>("MethodPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MethodPaymentId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MethodPaymentId")
                        .HasName("MethodPayment_PK");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("ModelLayer.Models.PaymentsModel", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId")
                        .HasName("Payments_PK");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ModelLayer.Models.RolModel", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"));

                    b.Property<string>("RolDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RolId")
                        .HasName("Rol_PK");

                    b.ToTable("Rols");
                });

            modelBuilder.Entity("ModelLayer.Models.ServiceModel", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"));

                    b.Property<decimal>("Price")
                        .HasPrecision(4)
                        .HasColumnType("decimal(4,2)");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ServiceId")
                        .HasName("Service_PK");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ModelLayer.Models.StatusContractModel", b =>
                {
                    b.Property<string>("StatusContractId")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StatusContractId")
                        .HasName("StatusContract_PK");

                    b.ToTable("StatusContracts");
                });

            modelBuilder.Entity("ModelLayer.Models.TurnModel", b =>
                {
                    b.Property<int>("TurnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurnId"));

                    b.Property<int>("CashId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("UserGestorId")
                        .HasColumnType("int");

                    b.HasKey("TurnId")
                        .HasName("Tun_PK");

                    b.HasIndex("CashId")
                        .IsUnique();

                    b.ToTable("Turns");
                });

            modelBuilder.Entity("ModelLayer.Models.UserCashModel", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CashId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CashId");

                    b.HasIndex("CashId");

                    b.ToTable("UsersCashes");
                });

            modelBuilder.Entity("ModelLayer.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateApproval")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("UserApprovalId")
                        .HasColumnType("int");

                    b.Property<int>("UserCreateId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserStatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("UserId")
                        .HasName("User_PK");

                    b.HasIndex("RolId")
                        .IsUnique();

                    b.HasIndex("UserStatusId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ModelLayer.Models.UserStatusModel", b =>
                {
                    b.Property<string>("StatusId")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StatusId")
                        .HasName("UserStatus_PK");

                    b.ToTable("UserStatuses");
                });

            modelBuilder.Entity("ModelLayer.Models.AttentionModel", b =>
                {
                    b.HasOne("ModelLayer.Models.AttentionTypeModel", "AttentionType")
                        .WithOne("Attention")
                        .HasForeignKey("ModelLayer.Models.AttentionModel", "AttentionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.ClientModel", "Client")
                        .WithOne("Attention")
                        .HasForeignKey("ModelLayer.Models.AttentionModel", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.TurnModel", "Turn")
                        .WithOne("Attention")
                        .HasForeignKey("ModelLayer.Models.AttentionModel", "TurnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttentionType");

                    b.Navigation("Client");

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("ModelLayer.Models.ContractModel", b =>
                {
                    b.HasOne("ModelLayer.Models.ClientModel", "Client")
                        .WithOne("Contract")
                        .HasForeignKey("ModelLayer.Models.ContractModel", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.MethodPaymentModel", "MethodPayment")
                        .WithOne("Contract")
                        .HasForeignKey("ModelLayer.Models.ContractModel", "MethodPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.ServiceModel", "Service")
                        .WithOne("Contract")
                        .HasForeignKey("ModelLayer.Models.ContractModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.StatusContractModel", "StatusContract")
                        .WithOne("Contract")
                        .HasForeignKey("ModelLayer.Models.ContractModel", "StatusContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("MethodPayment");

                    b.Navigation("Service");

                    b.Navigation("StatusContract");
                });

            modelBuilder.Entity("ModelLayer.Models.DeviceModel", b =>
                {
                    b.HasOne("ModelLayer.Models.ServiceModel", "Service")
                        .WithOne("Device")
                        .HasForeignKey("ModelLayer.Models.DeviceModel", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ModelLayer.Models.PaymentsModel", b =>
                {
                    b.HasOne("ModelLayer.Models.ClientModel", "Client")
                        .WithOne("Payments")
                        .HasForeignKey("ModelLayer.Models.PaymentsModel", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ModelLayer.Models.TurnModel", b =>
                {
                    b.HasOne("ModelLayer.Models.CashModel", "Cash")
                        .WithOne("Turn")
                        .HasForeignKey("ModelLayer.Models.TurnModel", "CashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cash");
                });

            modelBuilder.Entity("ModelLayer.Models.UserCashModel", b =>
                {
                    b.HasOne("ModelLayer.Models.CashModel", "Cash")
                        .WithMany("UsersCashes")
                        .HasForeignKey("CashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.UserModel", "User")
                        .WithMany("UsersCashes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cash");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModelLayer.Models.UserModel", b =>
                {
                    b.HasOne("ModelLayer.Models.RolModel", "Rol")
                        .WithOne("User")
                        .HasForeignKey("ModelLayer.Models.UserModel", "RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelLayer.Models.UserStatusModel", "UserStatus")
                        .WithOne("User")
                        .HasForeignKey("ModelLayer.Models.UserModel", "UserStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("UserStatus");
                });

            modelBuilder.Entity("ModelLayer.Models.AttentionTypeModel", b =>
                {
                    b.Navigation("Attention");
                });

            modelBuilder.Entity("ModelLayer.Models.CashModel", b =>
                {
                    b.Navigation("Turn");

                    b.Navigation("UsersCashes");
                });

            modelBuilder.Entity("ModelLayer.Models.ClientModel", b =>
                {
                    b.Navigation("Attention");

                    b.Navigation("Contract");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("ModelLayer.Models.MethodPaymentModel", b =>
                {
                    b.Navigation("Contract");
                });

            modelBuilder.Entity("ModelLayer.Models.RolModel", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("ModelLayer.Models.ServiceModel", b =>
                {
                    b.Navigation("Contract");

                    b.Navigation("Device");
                });

            modelBuilder.Entity("ModelLayer.Models.StatusContractModel", b =>
                {
                    b.Navigation("Contract");
                });

            modelBuilder.Entity("ModelLayer.Models.TurnModel", b =>
                {
                    b.Navigation("Attention");
                });

            modelBuilder.Entity("ModelLayer.Models.UserModel", b =>
                {
                    b.Navigation("UsersCashes");
                });

            modelBuilder.Entity("ModelLayer.Models.UserStatusModel", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
