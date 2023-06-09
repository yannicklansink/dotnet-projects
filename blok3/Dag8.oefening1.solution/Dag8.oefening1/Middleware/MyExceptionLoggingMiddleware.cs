using Dag8.oefening1.Middleware;

namespace Dag8.oefening1.Middleware
{
    public class MyExceptionLoggingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				var log = $"[{DateTime.Now.ToLongTimeString()}] {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";

				File.AppendAllText(@"C:\WORK\YannickLansink\blok3\errors.log", log);
				throw; // rethrow zodat die bij pagina en middleware komt.
			}
        }
    }

}

public static class MyExceptionLoggingMiddlewareExtensions
{
	// extension method
	public static IApplicationBuilder UseMyExceptionLogger(this IApplicationBuilder app)
	{
        return app.UseMiddleware<MyExceptionLoggingMiddleware>();
    }
}