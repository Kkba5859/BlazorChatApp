using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorChatApp.Layout;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Chat>("#chat");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Set up HttpClient to point to ChatAppApi
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5049") });

// SignalR service for chat hub connection
builder.Services.AddSingleton(serviceProvider =>
{
    var hubConnection = new HubConnectionBuilder()
        .WithUrl("https://localhost:5049/chathub") // Point to your API's SignalR hub
        .Build();

    return hubConnection;
});

// SignalR service for WebRTC hub connection (if needed for video call handling)
builder.Services.AddSingleton(serviceProvider =>
{
    var webrtcHubConnection = new HubConnectionBuilder()
        .WithUrl("https://localhost:5049/webrtchub") // Point to WebRTC Hub
        .Build();

    return webrtcHubConnection;
});

await builder.Build().RunAsync();
