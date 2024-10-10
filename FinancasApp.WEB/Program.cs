using Blazored.LocalStorage;
using FinancasApp.WEB;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Configurar a biblioteca Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

//Configurar o endereço da API que iremos acessar no Blazor
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:5269") 

});

await builder.Build().RunAsync();
