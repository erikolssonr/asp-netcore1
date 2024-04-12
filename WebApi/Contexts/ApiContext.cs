using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Contexts
{
    public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
    {
        public DbSet<SubscriberEntity> Subscribers { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
    }
}
