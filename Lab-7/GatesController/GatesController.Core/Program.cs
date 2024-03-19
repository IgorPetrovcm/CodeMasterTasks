using GatesController.Core;
using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<GatesManager>();

WebApplication app = builder.Build();
app.UseStaticFiles();

app.MapGet("/", () => Results.Redirect("index.html"));

app.MapGet(
    "/api/request/open/{gateId:int}",
    (int gateId, [FromServices] GatesManager gatesManager) => gatesManager.RequestOpen(gateId));

app.MapGet(
    "/api/request/close/{gateId:int}",
    (int gateId, [FromServices] GatesManager gatesManager) => gatesManager.RequestClose(gateId));

app.MapGet(
    "/api/status",
    ([FromServices] GatesManager gatesManager) => new
    {
        Gates = gatesManager.GetOpenGates(),
        VisitorsTotal = gatesManager.VisitorsCount,
        VisitorsByGates = gatesManager.VisitorsByGates,
    });

app.MapGet(
    "/api/enter/{gateId:int}",
    (int gateId, [FromServices] GatesManager gatesManager) => gatesManager.RegisterVisitorEnter(gateId));

app.MapGet(
    "/api/leave/{gateId:int}",
    (int gateId, [FromServices] GatesManager gatesManager) => gatesManager.RegisterVisitorLeave(gateId));

app.Run();
