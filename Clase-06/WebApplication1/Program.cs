var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string HTML_CONTENT = "<!DOCTYPE html>\r\n<html>\r\n<body>\r\n<h1>Hello World!</h1>\r\n</body>\r\n</html>";

//app.MapGet("/", () => "Hello World!");

//app.MapGet("/", () => HTML_CONTENT);

app.MapGet("/", () => { 
    var mimeType = "text/html";
    return Results.Content(HTML_CONTENT, mimeType);
});

app.MapGet("/otracosa", () => {
    var mimeType = "text/html";
    return Results.Content(HTML_CONTENT.Replace("Hello World", "Otra Cosa v2"), mimeType);
});


app.Run();
