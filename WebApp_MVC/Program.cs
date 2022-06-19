using Serilog;
using WebApp_MVC.Models;

Log.Logger = new LoggerConfiguration()
   .WriteTo.Console()
   .CreateBootstrapLogger(); //означает, что глобальный логер будет заменен на вариант из Host.UseSerilog
Log.Information("Starting up");
try
{
    /*
     * тут должна находиться вся логика создания веб-приложения
     * (содержимое файла Program.cs: builder, app и тд)
     */



    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddSingleton<ThreadSafeCatalog>();
    builder.Services.AddSingleton<Catalog>();
    //builder.Services.AddScoped<Good>();

    //добавляем Serilog
    builder.Host.UseSerilog((ctx, conf) =>
    {
        conf
            .WriteTo.Console()
            .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
            .ReadFrom.Configuration(ctx.Configuration)
        ;
    });


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

}
catch (Exception ex)
{
    Log.Fatal(ex, "Сервер рухнул!");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush(); //перед выходом дожидаемся пока все логи будут записаны
}
