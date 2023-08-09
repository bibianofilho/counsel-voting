﻿// <auto-generated />
using CounselVoting.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CounselVoting.Infrastructure.Migrations
{
    [DbContext(typeof(CounselContext))]
    [Migration("20230809055212_tribo-migration-V3")]
    partial class tribomigrationV3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("CounselVoting.Domain.Model.MeasureRuleModel", b =>
                {
                    b.Property<long>("MeasureRuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinNumberOfVotes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinPercentageOfYes")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UserMustUploadPicture")
                        .HasColumnType("INTEGER");

                    b.HasKey("MeasureRuleId");

                    b.ToTable("MeasureRule");
                });

            modelBuilder.Entity("CounselVoting.Domain.Model.SampleModel", b =>
                {
                    b.Property<long>("SampleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SampleId");

                    b.ToTable("Sample");
                });

            modelBuilder.Entity("CounselVoting.Domain.Model.UserNamesMustVoteToPassModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("MeasureRuleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MeasureRuleId");

                    b.ToTable("UserNamesMustVoteToPassModel");
                });

            modelBuilder.Entity("CounselVoting.Domain.Model.UserNamesMustVoteToPassModel", b =>
                {
                    b.HasOne("CounselVoting.Domain.Model.MeasureRuleModel", "MeasureRule")
                        .WithMany("UserNamesMustVoteToPassList")
                        .HasForeignKey("MeasureRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeasureRule");
                });

            modelBuilder.Entity("CounselVoting.Domain.Model.MeasureRuleModel", b =>
                {
                    b.Navigation("UserNamesMustVoteToPassList");
                });
#pragma warning restore 612, 618
        }
    }
}