using MfaSample.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<MultiFactorAuthenticationService>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
//        options.SignIn.RequireConfirmedAccount = false)
//    // .AddEntityFrameworkStores<ApplicationDbContext>() token Ç EF åoóRÇ≈ï€ë∂Ç∑ÇÈÇ¡Çƒê›íËÇ™èoóàÇÈ
//    .AddDefaultTokenProviders();

//builder.Services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>,
//    AdditionalUserClaimsPrincipalFactory>();

//builder.Services.AddAuthorization(options =>
//    options.AddPolicy("TwoFactorEnabled", x => x.RequireClaim("amr", "mfa")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
