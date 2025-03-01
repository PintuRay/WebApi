﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class LedgerDevModel
    {
        [Required]
        public string LedgerName { get; set; }
        [Required]
        public string LedgerType { get; set; }
        [Required]
        public string HasSubLedger { get; set; }
        [Required]
        public Guid Fk_LedgerGroupId { get; set; }
        [Required]
        public Guid? Fk_LedgerSubGroupId { get; set; }
    }
    public class LedgerDevUpdateModel
    {
        [Required]
        public Guid LedgerId { get; set; }
        [Required]
        public string LedgerName { get; set; }
        [Required]
        public string LedgerType { get; set; }
        [Required]
        public string HasSubLedger { get; set; }
        [Required]
        public Guid Fk_LedgerGroupId { get; set; }
        [Required]
        public Guid? Fk_LedgerSubGroupId { get; set; }
    }
    public class LedgerDevDto 
    {
        public Guid LedgerId { get; set; }
        public string LedgerName { get; set; }
        public string LedgerType { get; set; }
        public string HasSubLedger { get; set; }
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid? Fk_LedgerSubGroupId { get; set; }
    }
    public class LedgerDev
    {
        public Guid LedgerId { get; set; }
        public string LedgerName { get; set; }
        public string LedgerType { get; set; }
        public string HasSubLedger { get; set; }
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid? Fk_LedgerSubGroupId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LedgerGroup LedgerGroup { get; set; }
        public LedgerSubGroupDev LedgerSubGroup { get; set; } = null;
        public ICollection<SubLedger> SubLedgers { get; set; }
        public ICollection<LedgerBalance> LedgerBalances { get; set; }
        public ICollection<Party> Parties { get; set; }
        public ICollection<JournalTransaction> JournalTransactions { get; set; }
        public ICollection<PaymentOrder> PaymentOrders { get; set; }
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }
        public ICollection<ReceiptOrder> ReceiptOrders { get; set; }
        public ICollection<ReceiptTransaction> ReceiptTransactions { get; set; }
    }
    internal class LedgersDevConfig : IEntityTypeConfiguration<LedgerDev>
    {
        public void Configure(EntityTypeBuilder<LedgerDev> builder)
        {
            builder.ToTable("LedgersDev", "public");
            builder.HasKey(e => e.LedgerId);
            builder.Property(e => e.LedgerId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.LedgerName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.LedgerType).HasMaxLength(10).IsRequired(false);
            builder.Property(e => e.HasSubLedger).HasMaxLength(10).IsRequired(false);
            builder.Property(e => e.Fk_LedgerGroupId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_LedgerSubGroupId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(l => l.LedgerGroup).WithMany(g => g.LedgersDev).HasForeignKey(l => l.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(l => l.LedgerSubGroup).WithMany(g => g.LedgersDev).HasForeignKey(l => l.Fk_LedgerSubGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
               new LedgerDev() { LedgerId = Guid.Parse("D982B189-3326-430D-ACDE-13C12BBA7992"), LedgerName = "Sundry Creditors", LedgerType = "None", HasSubLedger = "Yes", Fk_LedgerGroupId = Guid.Parse("ACA9CAF1-EA9B-4602-BB60-6C354EAC5CE6") },
               new LedgerDev() { LedgerId = Guid.Parse("FBF4A6C7-C33D-4AD0-B7A5-ABB319CC1B93"), LedgerName = "Sundry Debtors", LedgerType = "None", HasSubLedger = "Yes", Fk_LedgerGroupId = Guid.Parse("2FC89E45-7365-46B7-933C-9ABAE2E5967A") },
               new LedgerDev() { LedgerId = Guid.Parse("F07A3165-D63B-4DAE-A820-EC79D83363B1"), LedgerName = "Labour A/c", LedgerType = "None", HasSubLedger = "Yes", Fk_LedgerGroupId = Guid.Parse("01548EF6-3FE2-4C0F-9A5F-CEED35066136") },
               new LedgerDev() { LedgerId = Guid.Parse("1ECFF7D8-702B-4DCD-93C5-B95A67E36FC9"), LedgerName = "Sales A/c", LedgerType = "None", HasSubLedger = "No", Fk_LedgerGroupId = Guid.Parse("15FE2512-D922-45C5-9E03-64C32B903A5B") },
               new LedgerDev() { LedgerId = Guid.Parse("75E1FE3D-047D-41AD-A138-F0BB5BBC8B1F"), LedgerName = "Purchase A/c", LedgerType = "None", HasSubLedger = "No", Fk_LedgerGroupId = Guid.Parse("4458BCE5-4546-4120-A7DE-03ACEFD07B85") },
               new LedgerDev() { LedgerId = Guid.Parse("80025398-C02F-4A1A-9DB7-8A21F9EFD9EF"), LedgerName = "Sales Return A/c", LedgerType = "None", HasSubLedger = "No", Fk_LedgerGroupId = Guid.Parse("15FE2512-D922-45C5-9E03-64C32B903A5B") },
               new LedgerDev() { LedgerId = Guid.Parse("712D600B-DFD6-4704-9E32-317FE62499A9"), LedgerName = "Purchase Return A/c", LedgerType = "None", HasSubLedger = "No", Fk_LedgerGroupId = Guid.Parse("4458BCE5-4546-4120-A7DE-03ACEFD07B85") },
               new LedgerDev() { LedgerId = Guid.Parse("701C663E-DAC3-4A39-8D2A-36EB68426B54"), LedgerName = "Cash A/c", LedgerType = "None", HasSubLedger = "No", Fk_LedgerGroupId = Guid.Parse("F3EEF2DD-09BB-4E21-B036-1E5BBA920EFE") },
               new LedgerDev() { LedgerId = Guid.Parse("9BFA6931-977F-4A3D-A582-DA5F1F4AB773"), LedgerName = "Bank A/c", LedgerType = "None", HasSubLedger = "No", Fk_LedgerGroupId = Guid.Parse("F3EEF2DD-09BB-4E21-B036-1E5BBA920EFE") },
               new LedgerDev() { LedgerId = Guid.Parse("7F740148-ED36-48AD-B194-031BC717842C"), LedgerName = "Labour Charges", LedgerType = "None", HasSubLedger = "No", Fk_LedgerGroupId = Guid.Parse("01548EF6-3FE2-4C0F-9A5F-CEED35066136") },
               new LedgerDev() { LedgerId = Guid.Parse("9EFD7830-125A-40E3-8F44-68AB03F52591"), LedgerName = "Transporting Charges Recive", LedgerType = "None", HasSubLedger = "No", Fk_LedgerGroupId = Guid.Parse("15FE2512-D922-45C5-9E03-64C32B903A5B") },
               new LedgerDev() { LedgerId = Guid.Parse("D281CBFB-3CAC-4C6A-8CE1-7B51973B8CA4"), LedgerName = "Transporting Charges Payment", LedgerType = "None", HasSubLedger = "No", Fk_LedgerGroupId = Guid.Parse("4458BCE5-4546-4120-A7DE-03ACEFD07B85") }
               );
        }
    }
}

