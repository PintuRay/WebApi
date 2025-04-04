﻿using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
namespace FMS.Db.Entity
{
    public class BranchModel
    {
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string BranchCode { get; set; }
        public Guid Fk_AdressId { get; set; }
        public AddressModel Address { get; set; }
    }
    public class BranchValidator : AbstractValidator<BranchModel>
    {
        public BranchValidator(CustomValidation vaidator)
        {
            RuleFor(branch => branch.BranchName)
            .MinimumLength(3).WithMessage("BranchName should be at least 3 characters long.")
            .Matches(@"^[A-Z\s]+$").WithMessage("BranchName should only contain uppercase letter and spaces.");

            RuleFor(branch => branch.ContactNumber)
            .Matches(@"^\d{10}$").WithMessage("ContactNumber should have exactly 10 digits.")
            .Length(10).WithMessage("ContactNumber should have exactly 10 digits.");

            RuleFor(branch => branch.BranchCode)
            .Matches(@"^[A-Z][A-Za-z0-9]*$").WithMessage("BranchCode should start with a upper case letter and followed by a combination of letters and numbers.");
        }
    }
    public class BranchUpdateModel 
    {
        [Required]
        public Guid BranchId { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string BranchCode { get; set; }
        public Guid Fk_AdressId { get; set; }
        public AddressUpdateModel Address { get; set; }
    }
    public class BranchUpdateValidator : AbstractValidator<BranchUpdateModel>
    {
        public BranchUpdateValidator(CustomValidation vaidator)
        {
            RuleFor(branch => branch.BranchName)
                .MinimumLength(3).WithMessage("BranchName should be at least 3 characters long.")
                .Matches(@"^[A-Z\s]+$").WithMessage("BranchName should only contain uppercase letter and spaces.");

            RuleFor(branch => branch.ContactNumber)
                .Matches(@"^\d{10}$").WithMessage("ContactNumber should have exactly 10 digits.")
                .Length(10).WithMessage("ContactNumber should have exactly 10 digits.");

            RuleFor(branch => branch.BranchCode)
                .Matches(@"^[A-Z][A-Za-z0-9]*$").WithMessage("BranchCode should start with a upper case letter and followed by a combination of letters and numbers.");
        }
    }
    public class BranchDto
    {
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }
        public string ContactNumber { get; set; }
        public string BranchCode { get; set; }
        public Guid Fk_AdressId { get; set; }
        public AddressDto Address { get; set; }
    }
    public class Branch 
    {
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }
        public string ContactNumber { get; set; }
        public string BranchCode { get; set; }
        public Guid Fk_AdressId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public Address Address { get; set; }
        public ICollection<FinancialYear> FinancialYears { get; set; }
        public ICollection<UserBranch> UserBranch { get; set; }
        public ICollection<LabourRate> LabourRates { get; set; }
        public ICollection<LedgerSubGroup> LedgerSubGroup { get; set; }
        public ICollection<LedgerSubGroupDev> LedgerSubGroupDev { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<Labour> Labours { get; set; }
        public ICollection<LedgerBalance> LedgerBalances { get; set; }
        public ICollection<SubLedger> SubLedgers { get; set; }
        public ICollection<SubLedgerBalance> SubLedgerBalances { get; set; }
        public ICollection<InwardSupplyOrder> InwardSupplyOrders { get; set; }
        public ICollection<InwardSupplyTransaction> InwardSupplyTransactions { get; set; }
        public ICollection<OutwardSupplyOrder> OutwardSupplyOrders { get; set; }
        public ICollection<OutwardSupplyTransaction> OutwardSupplyTransactions { get; set; }
        public ICollection<ProductionOrder> ProductionOrders { get; set; }
        public ICollection<ProductionTransaction> ProductionTransactions { get; set; }
        public ICollection<DamageOrder> DamageOrders { get; set; }
        public ICollection<DamageTransaction> DamageTransactions { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public ICollection<PurchaseTransaction> PurchaseTransactions { get; set; }
        public ICollection<PurchaseReturnOrder> PurchaseReturnOrders { get; set; }
        public ICollection<PurchaseReturnTransaction> PurchaseReturnTransactions { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public ICollection<SalesReturnOrder> SalesReturnOrders { get; set; }
        public ICollection<SalesReturnTransaction> SalesReturnTransactions { get; set; }
        public ICollection<JournalOrder> JournalOrders { get; set; }
        public ICollection<JournalTransaction> JournalTransactions { get; set; }
        public ICollection<PaymentOrder> PaymentOrders { get; set; }
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }
        public ICollection<ReceiptOrder> ReceiptOrders { get; set; }
        public ICollection<ReceiptTransaction> ReceiptTransactions { get; set; }
    }
    internal class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches", "public");
            builder.HasKey(e => e.BranchId);
            builder.Property(e => e.BranchId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.BranchName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.BranchCode).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.ContactNumber).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            //One-To-One Relationship
            builder.HasOne(d => d.Address).WithOne(p => p.Branch).HasForeignKey<Branch>(d => d.Fk_AdressId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
