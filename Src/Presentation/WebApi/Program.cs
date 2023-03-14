using WebApi.Configure;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebService();

var app = builder.Build();

await app.AddWebMiddleware().ConfigureAwait(false);
