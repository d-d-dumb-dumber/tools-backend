﻿using Domain.Entities;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts;

public class ToolsContext : DbContext
{
    
    public virtual  DbSet<User>? Users { get; set; }
    
    public ToolsContext()
    {
    }

    public ToolsContext(DbContextOptions<ToolsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ValidateNullArgument(nameof(modelBuilder));

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToolsContext).Assembly);
    }
}
