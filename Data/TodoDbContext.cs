using AspNetCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}