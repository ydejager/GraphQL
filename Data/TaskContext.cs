using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfGraphQl.Data
{

    public class TaskContext: DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>        
            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData( 
                new Task(Guid.Parse("35d3904b-6715-4ab5-ba41-73271e584bd6")),
                new Task(Guid.Parse("73482990-5eb5-42ea-b7dd-e600d2019db7")),
                new Task(Guid.Parse("70e765d2-1356-444c-a1aa-9195df7a8aed")),
                new Task(Guid.Parse("6fee5a1b-1e9c-4d9b-9433-fec84ee41037")),
                new Task(Guid.Parse("7c016b7f-baae-49c7-b55a-acc9e74cfd56")),
                new Task(Guid.Parse("d9227513-1f13-4110-a583-de7eca5782a7")),
                new Task(Guid.Parse("12d5e479-709d-4662-895a-4950bc48c29b")),
                new Task(Guid.Parse("0fdccd70-e341-459a-8279-30db9c8d7b63")),
                new Task(Guid.Parse("d6f5da4e-aac4-4ad4-8ba5-b0343d805472")),
                new Task(Guid.Parse("bee24e9c-f7c2-41a3-ab86-d2e7986110e1")),
                new Task(Guid.Parse("3a815a13-b3ef-4bed-b806-770bf5100ad2")),
                new Task(Guid.Parse("6322df36-4643-471d-82bf-8980900ba20f")),
                new Task(Guid.Parse("3fe3574a-2d70-4af0-af65-a4570d4d9404"))
            );
        }
    }
}