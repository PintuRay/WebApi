﻿using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class CompanyModel
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string GSTIN { get; set; }
        [Required]
        public IFormFile Logo { get; set; }
        public string LogoPath { get; set; }
    }
    public class CompanyValidator : AbstractValidator<CompanyModel>
    {
        public CompanyValidator(CustomValidation vaidator)
        {

        }
    }
    public class CompanyUpdateModel
    {
        [Required]
        public Guid CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string GSTIN { get; set; }
        [Required]
        public IFormFile Logo { get; set; }
        public string LogoPath { get; set; }
    }
    public class CompanyUpdateValidator : AbstractValidator<CompanyUpdateModel>
    {
        public CompanyUpdateValidator(CustomValidation vaidator)
        {

        }
    }
    public class CompanyDto
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string GSTIN { get; set; }
        public string LogoPath { get; set; }
    }
    public class Company
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string GSTIN { get; set; }
        public string LogoPath { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
    }
    internal class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", "public");
            builder.HasKey(e => e.CompanyId);
            builder.Property(e => e.CompanyId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.CompanyName).HasColumnType("text").HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.LogoPath).IsRequired(true);
            builder.Property(e => e.GSTIN).IsRequired(true);
            builder.Property(e => e.Email).IsRequired(true);
            builder.Property(e => e.PhoneNo).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
        }
    }
}
