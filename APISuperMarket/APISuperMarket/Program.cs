using APISuperMarket.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<GoogleDriveService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataSuperMarketContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MarketDB")));


// Dang ki dich vu RoleService
builder.Services.AddScoped<RoleService>();

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
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var token = context.Request.Cookies["AuthToken"];
            if (token != null)
            {
                context.Token = token;
            }
            return Task.CompletedTask;
        }
    };
});



//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ManagerOnly", policy => policy.RequireRole("Manager"));
//    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
//});


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


using (var scope = app.Services.CreateScope())
{
    var roleService = scope.ServiceProvider.GetRequiredService<RoleService>();
    var roles = await roleService.GetRolesFromDatabaseAsync();

    var authorizationOptions = app.Services.GetRequiredService<IOptions<AuthorizationOptions>>().Value;
    foreach (var role in roles)
    {
        authorizationOptions.AddPolicy(role, policy => policy.RequireRole(role));
    }
}


app.MapControllers();

app.Run();

public class RoleService
{
    private readonly DataSuperMarketContext _context;

    public RoleService(DataSuperMarketContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetRolesFromDatabaseAsync()
    {
        return await _context.Roles.Select(r => r.RoleName).ToListAsync();
    }
}