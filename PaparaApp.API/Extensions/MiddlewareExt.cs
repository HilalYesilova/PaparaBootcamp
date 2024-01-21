using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using PaparaApp.API.Middleware;
using PaparaApp.API.Models;

namespace PaparaApp.API.Extensions

;

public static class MiddlewareExt
{
    public static void AddDefaultMiddlewaresExt(this WebApplication app)
    {
        //Middleware işleyiş sırası
        //app.Use(async (context, next) =>
        //{
        //    Console.WriteLine("Middleware 1 rq");
        //    await next();
        //    Console.WriteLine("Middleware 1 rs");

        //});
        //app.Use(async (context, next) =>
        //{
        //    Console.WriteLine("Middleware 2 rq");
        //    await next();
        //    Console.WriteLine("Middleware 2 rs");

        //});

        //app.Run(context =>//sonlandırıcı middleware
        //{
        //    Console.WriteLine("Middleware Run Rq");
        //    return Task.CompletedTask;
        //});

        app.UseMiddleware<IPCheckMiddleware>();



        //Exception Handle
        app.UseExceptionHandler(app =>
        {
            app.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;


                if (exception is null) return;

                var responseDto = ResponseDto<object>.Fail(exception.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(responseDto);
            });

        });

        //use ile başlayanlar middleware'dir.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();//SWAGGER json body oluşturur.
            app.UseSwaggerUI();//swagger uı oluşturur.
        }

        app.UseHttpsRedirection();//request http geliyorsa bunu httpsE çeviri. Şifreler
        app.UseStaticFiles();//wwwroot'daki dosyaları dünyaya açar yani ilgili path'e göre dosyayı döner.
        app.UseAuthorization();//kimlik yetkilendirmesi yapar
        app.MapControllers();//endpointlerdeki route'a göre düzgün çalışmasını sağlar.Middleware değildir.
    }
}