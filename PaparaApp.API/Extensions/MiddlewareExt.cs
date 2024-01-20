namespace PaparaApp.API.Extensions

;

public static class MiddlewareExt
{
    public static void AddDefaultMiddlewaresExt(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthorization();
        app.MapControllers();
    }
}