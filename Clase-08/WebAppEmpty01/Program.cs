using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//app.MapGet("/demo", () => "Demo!");
//app.MapGet("/demo.html", () => "Demo!");


app.UseStaticFiles();


//Middleware
app.Use(async (context, next) => {

    Console.WriteLine("Middleware 1.Start");
    await next.Invoke();
    await context.Response.WriteAsync("Middleware 1!");
    Console.WriteLine("Middleware 1.End");
});

app.Use(async (context, next) => {
    Console.WriteLine("Middleware 2.Start");
    await next.Invoke();
    await context.Response.WriteAsync("Middleware 2!");
    Console.WriteLine("Middleware 2.End");
});

app.Map("/demomaptest1", HandleMapTest1);

app.Use(async (context, next) => {

    var param1Exists = context.Request.Query.ContainsKey("param1");

    await next.Invoke();

    if (param1Exists)
    {
        //logic...
        var paramValue = context.Request.Query["param1"];
        await context.Response.WriteAsync($"Param1 value = {paramValue}");
    }

});

app.MapWhen(context => context.Request.Query.ContainsKey("param1"),
                       HandleParam1Request);

//app.MapGet("/", () => "Hello World v2!");
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});


app.Run();

static void HandleMapTest1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 1");
    });
}

static void HandleParam1Request(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        var paramValue = context.Request.Query["param1"];
        await context.Response.WriteAsync($"Param1 value = {paramValue}");
    });
}
