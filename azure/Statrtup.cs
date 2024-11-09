namespace azure
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=App}/{action=Home}/{id?}");

                // Add another endpoint for /translator
                endpoints.MapControllerRoute(
                    name: "translator",
                    pattern: "translator",
                    defaults: new { controller = "Translator", action = "Translator" });
                endpoints.MapControllerRoute(
                    name: "translatorResults",
                    pattern: "translatorResults",
                    defaults: new { controller = "Translator", action = "TranslatorResults" });

                // Add another endpoint for /vision and /face
                endpoints.MapControllerRoute(
                    name: "vision",
                    pattern: "vision",
                    defaults: new { controller = "Vision", action = "Vision" });

                endpoints.MapControllerRoute(
                    name: "face",
                    pattern: "face",
                    defaults: new { controller = "Vision", action = "Face" });

                // Add another endpoint for /game
                endpoints.MapControllerRoute(
                    name: "game",
                    pattern: "game",
                    defaults: new { controller = "Game", action = "Rockpaperscissors" });

                // Add another endpoint for /planet_distances
                endpoints.MapControllerRoute(
                    name: "planet_distances",
                    pattern: "planet_distances",
                    defaults: new { controller = "Planet", action = "PlanetDistances" });
            });
        }
    }
}