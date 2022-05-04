using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SB.BlazorServer.Data.Auth;
using SB.BlazorServer.Data.LiveChat;
using SB.BlazorServer.Data.Supporter;
using SB.BlazorServer.Data.Ticket;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient();
builder.Services.AddScoped<HttpClient>();

builder.Services.AddHttpClient<TicketService>(client => 
    client.BaseAddress = new Uri("http://vps.qvistgaard.me:8980/api/ticket/"));

builder.Services.AddHttpClient<SupporterService>(client => 
    client.BaseAddress = new Uri("http://vps.qvistgaard.me:8980/api/auth/"));

builder.Services.AddHttpClient<AuthService>(client => 
    client.BaseAddress = new Uri("http://vps.qvistgaard.me:8980/api/auth/"));

builder.Services.AddHttpClient<LiveChatService>(client =>
    client.BaseAddress = new Uri("http://vps.qvistgaard.me:8980/api/livechat/"));

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