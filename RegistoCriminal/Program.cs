using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Data;
using RegistoCriminal.Entities;
using RegistoCriminal.Servicos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<RegistoCriminalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("crimeConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<RegistoCriminalContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3; // or even 1, if you want
    options.Password.RequiredUniqueChars = 0;
});


builder.Services.AddAutoMapper(
    AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddScoped<IRepositorioDependente<Cidadao, string>, CidadaoRepositorio>();
builder.Services.AddScoped<IRepositorioDependente<FuncionarioJudicial, string>, FuncionarioJudicialRepositorio>();
builder.Services.AddScoped<ILogRepositorio, LogRepositorio>();
builder.Services.AddScoped<IRepositorioDependente<RegistosCriminal, int>, RegistosCriminalRepositorio>();
builder.Services.AddScoped<IRepositorioDependente<CertificadoRegisto, int>, CertificadoRegistoRepositorio>();
builder.Services.AddScoped<IRepositorioDependente<Solicitacaoregisto, int>, SolicitacaoregistoRepositorio>();
builder.Services.AddScoped<IRepositorioDependente<Pagamento, int>, PagamentoRepositorio>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
