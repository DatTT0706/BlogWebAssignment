using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Models
{
    public partial class PRN231_BlogContext : DbContext
    {
        public PRN231_BlogContext()
        {
        }

        public PRN231_BlogContext(DbContextOptions<PRN231_BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<PostComment> PostComments { get; set; }
        public virtual DbSet<PostMetum> PostMeta { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=PRN231_Blog;uid=sa;pwd=123456789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(150)
                    .HasColumnName("metaTitle");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.Property(e => e.Slug)
                    .HasMaxLength(150)
                    .HasColumnName("slug");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(150)
                    .HasColumnName("metaTitle");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("publishedAt");

                entity.Property(e => e.Slug)
                    .HasMaxLength(150)
                    .HasColumnName("slug");

                entity.Property(e => e.Summary)
                    .HasMaxLength(255)
                    .HasColumnName("summary");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_post_user");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("post_category");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_post_category_category");

                entity.HasOne(d => d.Post)
                    .WithMany()
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_post_category_post");
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.ToTable("post_comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.PublishedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("publishedAt");

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .HasColumnName("title");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_post_comment_post");
            });

            modelBuilder.Entity<PostMetum>(entity =>
            {
                entity.ToTable("post_meta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Key)
                    .HasMaxLength(100)
                    .HasColumnName("key");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostMeta)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_post_meta_post");
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("post_tag");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.TagId).HasColumnName("tagId");

                entity.HasOne(d => d.Post)
                    .WithMany()
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_post_tag_post");

                entity.HasOne(d => d.Tag)
                    .WithMany()
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_post_tag_tag");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tag");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(150)
                    .HasColumnName("metaTitle");

                entity.Property(e => e.Slug)
                    .HasMaxLength(150)
                    .HasColumnName("slug");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.Intro)
                    .HasMaxLength(255)
                    .HasColumnName("intro");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("lastLogin");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .HasColumnName("middleName");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .HasColumnName("mobile");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(50)
                    .HasColumnName("passwordHash");

                entity.Property(e => e.Proflie).HasColumnName("proflie");

                entity.Property(e => e.RegisteredAt)
                    .HasColumnType("datetime")
                    .HasColumnName("registeredAt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
