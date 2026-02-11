using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Database_Final_Project.Models;

public partial class DbProjectContext : DbContext
{
    public DbProjectContext()
    {
    }

    public DbProjectContext(DbContextOptions<DbProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionAnswerOption> QuestionAnswerOptions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<StudentExamAnswer> StudentExamAnswers { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DB_project;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("Course_ID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Course_Name");
            entity.Property(e => e.TrackId).HasColumnName("Track_ID");

            entity.HasOne(d => d.Track).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK_Course_Track");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.ToTable("Exam");

            entity.Property(e => e.ExamId)
                .ValueGeneratedNever()
                .HasColumnName("Exam_ID");
            entity.Property(e => e.CrsId).HasColumnName("Crs_ID");
            entity.Property(e => e.ExamDurationMins).HasColumnName("Exam_Duration_mins");

            entity.HasOne(d => d.Crs).WithMany(p => p.Exams)
                .HasForeignKey(d => d.CrsId)
                .HasConstraintName("FK_Exam_Course");

            entity.HasMany(d => d.Questions).WithMany(p => p.Exams)
                .UsingEntity<Dictionary<string, object>>(
                    "ExamQuestion",
                    r => r.HasOne<Question>().WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Exam_Question_Question"),
                    l => l.HasOne<Exam>().WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Exam_Question_Exam"),
                    j =>
                    {
                        j.HasKey("ExamId", "QuestionId");
                        j.ToTable("Exam_Question");
                        j.IndexerProperty<int>("ExamId").HasColumnName("Exam_ID");
                        j.IndexerProperty<int>("QuestionId").HasColumnName("Question_ID");
                    });
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InsId);

            entity.ToTable("Instructor");

            entity.Property(e => e.InsId).HasColumnName("Ins_ID");
            entity.Property(e => e.HiringDate)
                .HasDefaultValueSql("(getdate())", "DF_Instructor_Hiring_date")
                .HasColumnName("Hiring_date");
            entity.Property(e => e.InsName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())", "DF_Instructor_Ins_name")
                .HasColumnName("Ins_name");
            entity.Property(e => e.TrackId).HasColumnName("Track_ID");

            entity.HasOne(d => d.Track).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK_Instructor_Track");

            entity.HasMany(d => d.Crs).WithMany(p => p.Ins)
                .UsingEntity<Dictionary<string, object>>(
                    "InstructorCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Instructor_Course_Course"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InsId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Instructor_Course_Instructor"),
                    j =>
                    {
                        j.HasKey("InsId", "CrsId");
                        j.ToTable("Instructor_Course");
                        j.IndexerProperty<int>("InsId").HasColumnName("Ins_ID");
                        j.IndexerProperty<int>("CrsId").HasColumnName("Crs_ID");
                    });
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.QuestionId).HasColumnName("Question_ID");
            entity.Property(e => e.CrsId).HasColumnName("Crs_ID");
            entity.Property(e => e.ModelAnswer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Model_Answer");
            entity.Property(e => e.QDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Q_Description");
            entity.Property(e => e.QType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Q_Type");

            entity.HasOne(d => d.Crs).WithMany(p => p.Questions)
                .HasForeignKey(d => d.CrsId)
                .HasConstraintName("FK_Question_Course");
        });

        modelBuilder.Entity<QuestionAnswerOption>(entity =>
        {
            entity.HasKey(e => new { e.QuestionId, e.QAnsOption });

            entity.ToTable("Question_Answer_Options");

            entity.Property(e => e.QuestionId).HasColumnName("Question_ID");
            entity.Property(e => e.QAnsOption)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Q_Ans_Option");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionAnswerOptions)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Question_Answer_Options_Question");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Student_Name");
            entity.Property(e => e.TrackId).HasColumnName("Track_ID");

            entity.HasOne(d => d.Track).WithMany(p => p.Students)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK_Student_Track");
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.CrsId });

            entity.ToTable("Student_Course");

            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.CrsId).HasColumnName("Crs_ID");

            entity.HasOne(d => d.Crs).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.CrsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Course");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Student");
        });

        modelBuilder.Entity<StudentExamAnswer>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.ExamId, e.QId });

            entity.ToTable("Student_Exam_Answer");

            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.ExamId).HasColumnName("Exam_ID");
            entity.Property(e => e.QId).HasColumnName("Q_ID");
            entity.Property(e => e.StudAnswer)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Stud_Answer");

            entity.HasOne(d => d.Exam).WithMany(p => p.StudentExamAnswers)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Exam_Answer_Exam");

            entity.HasOne(d => d.QIdNavigation).WithMany(p => p.StudentExamAnswers)
                .HasForeignKey(d => d.QId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Exam_Answer_Question");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentExamAnswers)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Exam_Answer_Student");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => new { e.TopicName, e.CourseId });

            entity.ToTable("Topic");

            entity.Property(e => e.TopicName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Topic_Name");
            entity.Property(e => e.CourseId).HasColumnName("Course_ID");

            entity.HasOne(d => d.Course).WithMany(p => p.Topics)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Topic_Course");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.ToTable("Track");

            entity.Property(e => e.TrackId).HasColumnName("Track_ID");
            entity.Property(e => e.MaxNoStudents).HasDefaultValue(100, "DF_Track_Max number of students");
            entity.Property(e => e.TrackName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Track_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
