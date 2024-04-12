﻿using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Contexts;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : IdentityDbContext<UserEntity>(options)
{
}
