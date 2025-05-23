using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RegistoCriminal.Data;
using RegistoCriminal.Entities;
using RegistoCriminal.Servicos;
using System.Text;

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


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = "your-issuer",
//        ValidAudience = "your-audience",
//        IssuerSigningKey = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes("your-very-strong-secret-key"))
//    };
//});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
        )
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "RegistoCriminal API", Version = "v1" });

    // Add JWT Authentication to Swagger
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter your JWT token (e.g. Bearer <your-token>)",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
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

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("FrontendApp", builder =>
//    {
//        builder.WithOrigins("http://localhost:4200") // <--- 
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//    });
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("FrontendApp");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();
