using HIMSServer;

var builder = WebApplication.CreateBuilder(args);


// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder => builder
            .WithOrigins("http://localhost:4200") // Allow specific origin
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()); // Allow credentials if needed
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//below are midleware
app.UseMiddleware<CheckSecurityMiddleware>();//my middleware
app.UseHttpsRedirection();
app.UseStaticFiles();

// Enable the CORS middleware
app.UseCors("AllowSpecificOrigins");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
