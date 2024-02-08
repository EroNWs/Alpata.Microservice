using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Meeting.Dal.EF.Seeds;

internal static class MeetingPlanningSeed
{
    public static async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder<AlpataDbContext>();

        dbContextBuilder.UseSqlServer(configuration.GetConnectionString("AlpataDbContext"));

        using AlpataDbContext context = new(dbContextBuilder.Options);

        if (!context.MeetingPlannings.Any())
        {
            var meetingPlannings = new MeetingPlanning[]
            {
                new MeetingPlanning
                {
                    MeetingName = "Yönetim Kurulu Toplantısı",
                    StartDateTime = new DateTime(2024, 2, 1, 14, 0, 0),
                    FinishDateTime = new DateTime(2024, 2, 1, 16, 0, 0),
                    MeetingDescription = "Yıllık bütçe planlaması ve stratejik hedeflerin gözden geçirilmesi.",
                    DocumentPath = "/documents/yonetim-kurulu-toplantisi.pdf",
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDate = DateTime.UtcNow,
                    Status = Core.Enums.Status.Added
                }, 
                new MeetingPlanning
                {
                    MeetingName = "Ürün Değerleme Toplantısı",
                    StartDateTime = new DateTime(2024, 2, 5, 14, 0, 0),
                    FinishDateTime = new DateTime(2024, 2, 8, 16, 0, 0),
                    MeetingDescription = "Yeni çıkacak olan ürünlerin değerlendirilmesi.",
                    DocumentPath = "/documents/urun-degerleme-toplantisi.pdf",
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDate = DateTime.UtcNow,
                    Status = Core.Enums.Status.Added
                },
                new MeetingPlanning
                {
                    MeetingName = "Fabrika Problemleri Toplantısı",
                    StartDateTime = new DateTime(2024, 2, 12, 14, 0, 0),
                    FinishDateTime = new DateTime(2024, 2, 16, 16, 0, 0),
                    MeetingDescription = "FAbrika Sorunları Değerlendirilmesi.",
                    DocumentPath = "/documents/fabrika-sorunu-toplantisi.pdf",
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "System",
                    ModifiedDate = DateTime.UtcNow,
                    Status = Core.Enums.Status.Added
                },
            
            };

            await context.MeetingPlannings.AddRangeAsync(meetingPlannings);
            await context.SaveChangesAsync();
        }
    }





}
