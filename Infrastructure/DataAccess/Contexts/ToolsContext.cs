﻿using System.Diagnostics.CodeAnalysis;
using Domain.Entities;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts;

[ExcludeFromCodeCoverage]
public class ToolsContext : DbContext
{

    public virtual DbSet<User> Users { get; init; } = null!;
    
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
