// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.MemberOfParliament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberOfParliamentRole")
                        .HasColumnType("int");

                    b.Property<int?>("PartyId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TermId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartyId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TermId");

                    b.ToTable("MemberOfParliaments");
                });

            modelBuilder.Entity("Domain.Entities.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Letter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Parties");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Domain.Entities.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("Domain.Entities.Proposer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MemberOfParliamentId")
                        .HasColumnType("int");

                    b.Property<int?>("ProposalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberOfParliamentId");

                    b.HasIndex("ProposalId");

                    b.ToTable("Proposers");
                });

            modelBuilder.Entity("Domain.Entities.Term", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("Domain.Entities.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MemberOfParliamentId")
                        .HasColumnType("int");

                    b.Property<int?>("ProposalId")
                        .HasColumnType("int");

                    b.Property<int>("VoteType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberOfParliamentId");

                    b.HasIndex("ProposalId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Domain.Entities.MemberOfParliament", b =>
                {
                    b.HasOne("Domain.Entities.Party", "Party")
                        .WithMany()
                        .HasForeignKey("PartyId");

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Domain.Entities.Term", "Term")
                        .WithMany()
                        .HasForeignKey("TermId");

                    b.Navigation("Party");

                    b.Navigation("Person");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("Domain.Entities.Proposer", b =>
                {
                    b.HasOne("Domain.Entities.MemberOfParliament", "MemberOfParliament")
                        .WithMany()
                        .HasForeignKey("MemberOfParliamentId");

                    b.HasOne("Domain.Entities.Proposal", null)
                        .WithMany("Proposers")
                        .HasForeignKey("ProposalId");

                    b.Navigation("MemberOfParliament");
                });

            modelBuilder.Entity("Domain.Entities.Vote", b =>
                {
                    b.HasOne("Domain.Entities.MemberOfParliament", "MemberOfParliament")
                        .WithMany()
                        .HasForeignKey("MemberOfParliamentId");

                    b.HasOne("Domain.Entities.Proposal", null)
                        .WithMany("Votes")
                        .HasForeignKey("ProposalId");

                    b.Navigation("MemberOfParliament");
                });

            modelBuilder.Entity("Domain.Entities.Proposal", b =>
                {
                    b.Navigation("Proposers");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
