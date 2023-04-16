namespace FordInternHW2.Extension
{
    public static class StartUpApplicationExtension
    {
        public static void AddApplicationServices(this IApplicationBuilder app)
        {
            //app.Use((ctx, next) =>
            //{
            //    // Get all the services and increase their counters...
            //    var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
            //    var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
            //    var transient = ctx.RequestServices.GetRequiredService<TransientService>();

            //    singleton.Counter++;
            //    scoped.Counter++;
            //    transient.Counter++;

            //    return next();
            //});
            //app.Run(async ctx =>
            //{
            //    // ...then do it again...
            //    var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
            //    var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
            //    var transient = ctx.RequestServices.GetRequiredService<TransientService>();

            //    singleton.Counter++;
            //    scoped.Counter++;
            //    transient.Counter++;

            //    // ...and display the counter values.
            //    await ctx.Response.WriteAsync($"Singleton: {singleton.Counter}\n");
            //    await ctx.Response.WriteAsync($"Scoped: {scoped.Counter}\n");
            //    await ctx.Response.WriteAsync($"Transient: {transient.Counter}\n");
            //});

        }
    }
}
