using Meeting.Core.Entities.EntityTypeConfigurations;
using Meeting.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meeting.Ent.Conf;

public class MeetingConfiguration: AuditableEntityConfiguration<MeetingPlanning>
{
    public override void Configure(EntityTypeBuilder<MeetingPlanning> builder)
    {
        base.Configure(builder);

        builder.HasKey(e => e.Id);
        builder.Property(m => m.MeetingName).IsRequired().HasMaxLength(256);
        builder.Property(m => m.MeetingDescription).HasMaxLength(1024);
        builder.Property(m => m.DocumentPath).HasMaxLength(512);

    }

}
