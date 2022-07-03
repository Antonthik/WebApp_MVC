using Serilog;
using WebApp_MVC.DomainEvents.EventConsummers;
using WebApp_MVC.Models;

Log.Logger = new LoggerConfiguration()
   .WriteTo.Console()
   .CreateBootstrapLogger(); //означает, что глобальный логер будет заменен на вариант из Host.UseSerilog
Log.Information("Starting up");
try
{
    /*
     * тут должна находитьс€ вс€ логика создани€ веб-приложени€
     * (содержимое файла Program.cs: builder, app и тд)
     */



    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    //builder.Services.AddSingleton<ThreadSafeCatalog>();
    builder.Services.AddSingleton<Catalog>();
    //builder.Services.AddSingleton<EmailService>();
    builder.Services.AddHostedService<ProductAddedEmailSend>();

    //builder.Services.AddScoped<Good>();

    //добавл€ем Serilog
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

    //--- ¬недр€ем свой middleware урок9 ---
    app.Use(async (HttpContext context, Func<Task> next) =>
    {
        var userAgent = context.Request.Headers.UserAgent.ToString();
        if (!userAgent.Contains("Edg"))
        {
            context.Response.ContentType = "text/plain; charset=UTF-8";//мен€ем кодировку сообщени€
            await context.Response.WriteAsync("¬аш браузер не поддерживаетс€.");
            return;
        }
        await next();
    });
    //-----------------------------
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
    Log.Fatal(ex, "—ервер рухнул!");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush(); //перед выходом дожидаемс€ пока все логи будут записаны
}
