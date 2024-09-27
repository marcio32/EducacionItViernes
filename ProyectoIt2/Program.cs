using Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using ProyectoIt2.Middlewares;
using Web;

namespace ProyectoIt2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ApplicationDbContext.ConnectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient("UseApi", config =>
            {
                config.BaseAddress = new Uri(builder.Configuration["Url:Api"]);
            });

            builder.Services.AddSignalR();

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
            {
                config.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.Redirect("https://localhost:44313");
                    return Task.CompletedTask;
                };
            }).AddGoogle(GoogleDefaults.AuthenticationScheme, option =>
            {
                option.ClientId = builder.Configuration["Authentications:Google:ClientId"];
                option.ClientSecret = builder.Configuration["Authentications:Google:ClientSecret"];
            });

            builder.Services.AddAuthorization(option =>
            {
                option.AddPolicy("ADMINISTRADORES", policy =>
                {
                    policy.RequireRole("Administrador");
                });

                option.AddPolicy("USUARIOS", policy =>
                {
                    policy.RequireRole("Usuario");
                });
            });

            builder.Services.AddSession();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}");

            app.MapHub<ChatHub>("/Chat");

            app.UseMiddleware<ExceptionMiddleware>();

            app.Run();
        }
    }
}
