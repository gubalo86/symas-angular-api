using Microsoft.EntityFrameworkCore;
using Symas.SymasSalud.Repositories.SqlServer.Entities;
using System;

namespace Symas.SymasSalud.Repositories.SqlServer
{
    public class SymasSaludDbContext : DbContext
    {
        public SymasSaludDbContext(DbContextOptions<SymasSaludDbContext> options) : base(options)
        { }

        #region Catalogs
        public DbSet<CategoryEntity> Categories { get; set; }
        #endregion Catalogs

        public DbSet<ProductEntity> Products { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<UserEntity>()
        //         .HasOne(u => u.Credentials)
        //         .WithOne(c => c.User)
        //         .HasForeignKey<UserEntity>(u => u.CredentialsId);

        //    builder.Entity<UserRoleEntity>()
        //        .HasKey(c => new { c.UserId, c.RoleId });

        //    builder.Entity<UserRoleEntity>()
        //        .HasOne(u => u.User)
        //        .WithMany(c => c.UserRoles)
        //        .HasForeignKey(uc => uc.UserId);

        //    builder.Entity<UserRoleEntity>()
        //        .HasOne(u => u.Role)
        //        .WithMany(c => c.UserRoles)
        //        .HasForeignKey(uc => uc.RoleId);

        //    builder.Entity<UserPolicyEntity>()
        //        .HasKey(c => new { c.UserId, c.PolicyId });

        //    builder.Entity<UserPolicyEntity>()
        //        .HasOne(u => u.User)
        //        .WithMany(c => c.UserPolicies)
        //        .HasForeignKey(uc => uc.UserId);

        //    builder.Entity<UserPolicyEntity>()
        //        .HasOne(u => u.Policy)
        //        .WithMany(c => c.UserPolicies)
        //        .HasForeignKey(uc => uc.PolicyId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ResetTokenEntity>()
        //        .HasOne(u => u.User)
        //        .WithMany(c => c.ResetTokens)
        //        .HasForeignKey(uc => uc.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<RolePolicyEntity>()
        //        .HasKey(c => new { c.RoleId, c.PolicyId });

        //    builder.Entity<RolePolicyEntity>()
        //        .HasOne(u => u.Role)
        //        .WithMany(c => c.RolePolicies)
        //        .HasForeignKey(uc => uc.RoleId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<RolePolicyEntity>()
        //        .HasOne(u => u.Policy)
        //        .WithMany(c => c.RolePolicies)
        //        .HasForeignKey(uc => uc.PolicyId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<BundleTermEntity>()
        //        .HasKey(c => new { c.BundleId, c.TermId });

        //    builder.Entity<BundleTermEntity>()
        //        .HasOne(u => u.Bundle)
        //        .WithMany(c => c.BundleTerms)
        //        .HasForeignKey(uc => uc.BundleId);

        //    builder.Entity<BundleTermEntity>()
        //        .HasOne(u => u.Term)
        //        .WithMany(c => c.BundleTerms)
        //        .HasForeignKey(uc => uc.TermId);

        //    builder.Entity<TranslationEntity>()
        //        .HasOne(u => u.Term)
        //        .WithMany(c => c.Translations)
        //        .HasForeignKey(uc => uc.TermId);

        //    builder.Entity<TranslationEntity>()
        //        .HasOne(u => u.Bundle)
        //        .WithMany(c => c.Translations)
        //        .HasForeignKey(uc => uc.BundleId);

        //    builder.Entity<TranslationEntity>()
        //        .HasOne(u => u.Language)
        //        .WithMany(c => c.Translations)
        //        .HasForeignKey(uc => uc.LanguageId);


        //    #region Application

        //    builder.Entity<ApplicationEntity>()
        //        .HasMany(c => c.Resources)
        //        .WithOne(u => u.Application)
        //        .HasForeignKey(uc => uc.Id)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ResourceEntity>()
        //        .HasOne(u => u.Application)
        //        .WithMany(c => c.Resources)
        //        .HasForeignKey(uc => uc.ApplicationId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<OperationEntity>()
        //        .HasOne(c => c.Resource)
        //        .WithMany(u => u.Operations)
        //        .HasForeignKey(uc => uc.ResourceId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<PolicyEntity>()
        //        .HasOne(c => c.Operation)
        //        .WithMany(u => u.Policies)
        //        .HasForeignKey(uc => uc.OperationId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<RolePolicyEntity>()
        //        .HasOne(c => c.Role)
        //        .WithMany(u => u.RolePolicies)
        //        .HasForeignKey(uc => uc.PolicyId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ApplicationEntity>()
        //        .HasMany(c => c.Roles)
        //        .WithOne(u => u.Application)
        //        .HasForeignKey(uc => uc.ApplicationId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<RoleEntity>()
        //        .HasOne(u => u.Application)
        //        .WithMany(c => c.Roles)
        //        .HasForeignKey(uc => uc.ApplicationId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<UserApplicationEntity>()
        //        .HasKey(c => new { c.UserId, c.ApplicationId });

        //    #endregion Application

        //    builder.Entity<UserHierarchyEntity>()
        //        .HasKey(c => new { c.UserId });

        //    builder.Entity<UserHierarchyEntity>()
        //        .HasOne(u => u.User)
        //        .WithMany(u => u.UsersHierarchy)
        //        .HasForeignKey(u => u.UserId);
        //}        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<UserEntity>()
        //         .HasOne(u => u.Credentials)
        //         .WithOne(c => c.User)
        //         .HasForeignKey<UserEntity>(u => u.CredentialsId);

        //    builder.Entity<UserRoleEntity>()
        //        .HasKey(c => new { c.UserId, c.RoleId });

        //    builder.Entity<UserRoleEntity>()
        //        .HasOne(u => u.User)
        //        .WithMany(c => c.UserRoles)
        //        .HasForeignKey(uc => uc.UserId);

        //    builder.Entity<UserRoleEntity>()
        //        .HasOne(u => u.Role)
        //        .WithMany(c => c.UserRoles)
        //        .HasForeignKey(uc => uc.RoleId);

        //    builder.Entity<UserPolicyEntity>()
        //        .HasKey(c => new { c.UserId, c.PolicyId });

        //    builder.Entity<UserPolicyEntity>()
        //        .HasOne(u => u.User)
        //        .WithMany(c => c.UserPolicies)
        //        .HasForeignKey(uc => uc.UserId);

        //    builder.Entity<UserPolicyEntity>()
        //        .HasOne(u => u.Policy)
        //        .WithMany(c => c.UserPolicies)
        //        .HasForeignKey(uc => uc.PolicyId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ResetTokenEntity>()
        //        .HasOne(u => u.User)
        //        .WithMany(c => c.ResetTokens)
        //        .HasForeignKey(uc => uc.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<RolePolicyEntity>()
        //        .HasKey(c => new { c.RoleId, c.PolicyId });

        //    builder.Entity<RolePolicyEntity>()
        //        .HasOne(u => u.Role)
        //        .WithMany(c => c.RolePolicies)
        //        .HasForeignKey(uc => uc.RoleId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<RolePolicyEntity>()
        //        .HasOne(u => u.Policy)
        //        .WithMany(c => c.RolePolicies)
        //        .HasForeignKey(uc => uc.PolicyId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<BundleTermEntity>()
        //        .HasKey(c => new { c.BundleId, c.TermId });

        //    builder.Entity<BundleTermEntity>()
        //        .HasOne(u => u.Bundle)
        //        .WithMany(c => c.BundleTerms)
        //        .HasForeignKey(uc => uc.BundleId);

        //    builder.Entity<BundleTermEntity>()
        //        .HasOne(u => u.Term)
        //        .WithMany(c => c.BundleTerms)
        //        .HasForeignKey(uc => uc.TermId);

        //    builder.Entity<TranslationEntity>()
        //        .HasOne(u => u.Term)
        //        .WithMany(c => c.Translations)
        //        .HasForeignKey(uc => uc.TermId);

        //    builder.Entity<TranslationEntity>()
        //        .HasOne(u => u.Bundle)
        //        .WithMany(c => c.Translations)
        //        .HasForeignKey(uc => uc.BundleId);

        //    builder.Entity<TranslationEntity>()
        //        .HasOne(u => u.Language)
        //        .WithMany(c => c.Translations)
        //        .HasForeignKey(uc => uc.LanguageId);


        //    #region Application

        //    builder.Entity<ApplicationEntity>()
        //        .HasMany(c => c.Resources)
        //        .WithOne(u => u.Application)
        //        .HasForeignKey(uc => uc.Id)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ResourceEntity>()
        //        .HasOne(u => u.Application)
        //        .WithMany(c => c.Resources)
        //        .HasForeignKey(uc => uc.ApplicationId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<OperationEntity>()
        //        .HasOne(c => c.Resource)
        //        .WithMany(u => u.Operations)
        //        .HasForeignKey(uc => uc.ResourceId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<PolicyEntity>()
        //        .HasOne(c => c.Operation)
        //        .WithMany(u => u.Policies)
        //        .HasForeignKey(uc => uc.OperationId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<RolePolicyEntity>()
        //        .HasOne(c => c.Role)
        //        .WithMany(u => u.RolePolicies)
        //        .HasForeignKey(uc => uc.PolicyId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ApplicationEntity>()
        //        .HasMany(c => c.Roles)
        //        .WithOne(u => u.Application)
        //        .HasForeignKey(uc => uc.ApplicationId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<RoleEntity>()
        //        .HasOne(u => u.Application)
        //        .WithMany(c => c.Roles)
        //        .HasForeignKey(uc => uc.ApplicationId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<UserApplicationEntity>()
        //        .HasKey(c => new { c.UserId, c.ApplicationId });

        //    #endregion Application

        //    builder.Entity<UserHierarchyEntity>()
        //        .HasKey(c => new { c.UserId });

        //    builder.Entity<UserHierarchyEntity>()
        //        .HasOne(u => u.User)
        //        .WithMany(u => u.UsersHierarchy)
        //        .HasForeignKey(u => u.UserId);
        //}
    }
}
