using Gestion_note.Data;
using Gestion_note.Data.FiliereRepo;
using Gestion_note.Data.StudentRepo;
using Gestion_note.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Gestion_note.Data.NoteRepo;
using Gestion_note.Data.MatiereRepo;
using Gestion_note.Data.TeacherRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IStudentRepo, StudentRepo>();
builder.Services.AddTransient<IFiliereRepo, FiliereRepo>();
builder.Services.AddTransient<IMatiereRepo, MatiereRepo>();
builder.Services.AddTransient<ITeacherRepo, TeacherRepo>();
builder.Services.AddTransient<INoteRepo, NoteRepo>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PROJ_CONN_STRING"))
);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
        
app.Run();
