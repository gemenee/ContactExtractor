using BlazorWebApplication.Data;
using PersonContactExtractor.Persistance;
using Microsoft.EntityFrameworkCore;
using PersonContactExtractor;
using TextPreparation;

namespace BlazorWebApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			builder.Services.AddSingleton<WeatherForecastService>();
			builder.Services.AddSingleton<IFileService, FileService>();
			builder.Services.AddScoped<IResultService, ResultService>();
			builder.Services.AddHttpClient();
			builder.Services.AddScoped<IDocumentProcessor, DocumentProcessor>();
			builder.Services.AddSingleton<IDocxTextExtractor, DocxTextExtractor>();
			builder.Services.AddDbContext<ContactExtractorContext>(options =>
				options.UseSqlite("Filename=ContactExtractor.db"));
			builder.Services.AddScoped<IDocumentService, DocumentService>();

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
		}
	}
}