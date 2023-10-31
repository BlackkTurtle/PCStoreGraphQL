using System.Data;
using System.Data.SqlClient;
using System.Text;
using GraphQL;
using HotChocolate.Execution.Processing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PCStoreGraphQL.API.DataLoaders;
using PCStoreGraphQL.API.Mutations;
using PCStoreGraphQL.API.Queries;
using PCStoreGraphQL.API.Types;
using PCStoreGraphQL.DataAccess.Repositories;
using PCStoreGraphQL.DataAccess.Repositories.Contracts;
using PCStoreGraphQL.Database.DbContext;
using PCStoreGraphQL.Database.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<BrandType>()
    .AddType<CommentType>()
    .AddType<OrderType>()
    .AddType<PartOrderType>()
    .AddType<ProductType>()
    .AddType<StatusType>()
    .AddType<TypesType>()
    .AddType<UserType>()
    .AddTypeExtension<BrandQuery>()
    .AddTypeExtension<CommentQuery>()
    .AddTypeExtension<OrderQuery>()
    .AddTypeExtension<ProductsQuery>()
    .AddTypeExtension<PartOrderQuery>()
    .AddTypeExtension<StatusQuery>()
    .AddTypeExtension<TypeQuery>()
    .AddTypeExtension<UserQuery>()
    .AddTypeExtension<OrderMutation>()
    .AddTypeExtension<UserMutation>()
    .AddTypeExtension<PartOrderMutation>()
    .AddTypeExtension<CommentMutation>();
builder.Services.AddScoped<BrandDataLoader>();

builder.Services.AddDbContext<PCStoreDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MSSQLConnection"), b => b.MigrationsAssembly("PCStoreGraphQL.API"))).AddIdentity<User, Role>(config =>
{
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireDigit = false;
    config.Password.RequiredLength = 6;
    config.Password.RequireLowercase = false;
    config.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<PCStoreDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.ConfigureApplicationCookie(config => {
    config.LoginPath = "/Admin/Login";
    config.AccessDeniedPath = "/Admin/AccessDenied";
});

builder.Services.AddScoped<IEFTypesRepository, EFTypesRepository>();
builder.Services.AddScoped<IEFBrandsRepository, EFBrandsRepository>();
builder.Services.AddScoped<IEFCommentsRepository, EFCommentRepository>();
builder.Services.AddScoped<IEFOrdersRepository, EFOrdersRepository>();
builder.Services.AddScoped<IEFPartOrdersRepository, EFPartOrdersRepository>();
builder.Services.AddScoped<IEFProductsRepository, EFProductsRepository>();
builder.Services.AddScoped<IEFStatusesRepository, EFStatusesRepository>();
builder.Services.AddScoped<IEFUsersRepository, EFUsersRepository>();
builder.Services.AddScoped<IEFUnitOfWork, EFUnitOfWork>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();