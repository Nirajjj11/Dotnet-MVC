var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure routes
// app.MapControllerRoute(                      // for taking input from form in RsvpForm Learning from book
//     name: "customRoutes",
//     pattern: "{action}",                         // for direct access for routing
//     defaults: new { controller = "Home" } // Ensure "Home" is used for actions
// );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}" ,// Default fallback route
    defaults: new { controller = "Home" }
);

app.Run();



// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllersWithViews();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// } 


// app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();

// app.UseAuthorization();

// app.UseRouting();

// // app.UseEndpoints(endpoints =>
// // {
// //     // Custom routes for simplified URLs
// //     endpoints.MapControllerRoute(
// //         name: "customRoutes",
// //         pattern: "{action}",
// //         defaults: new { controller = "Home" });

// //     // Default route (optional, fallback for other controllers)
// //     endpoints.MapControllerRoute(
// //         name: "default",
// //         pattern: "{controller=Home}/{action=Index}/{id?}");
// // });


// app.MapControllerRoute(
//     name: "default",
//     // pattern: "{controller=Home}/{action=Index}/{id?}");
//     pattern: "{action}"
// );

// app.Run();
