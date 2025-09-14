using Microsoft.AspNetCore.Http.Extensions;

namespace Invoice
{
    public class CompanyContextMiddleware
    {
        private readonly RequestDelegate _next;

        public CompanyContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAppContext appContext)
        {
            if (context.Request.Headers.TryGetValue("X-Company-Id", out var companyIdHeader))
            {
                if (int.TryParse(companyIdHeader, out var companyId))
                {
                    appContext.CompanyId = companyId;
                    appContext.AccYearId = 0;
                }
            }

            await _next(context);
        }

    }
}
