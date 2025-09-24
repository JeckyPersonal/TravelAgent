using Microsoft.AspNetCore.Http.Extensions;

namespace Invoice.MiddleWare
{
    public class CompanyContextMiddleware : IMiddleware
    {
        private readonly IAppContext _appContext;

        public CompanyContextMiddleware(IAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Headers.TryGetValue("X-Company-Id", out var companyIdHeader))
            {
                if (int.TryParse(companyIdHeader, out var companyId))
                {
                    _appContext.CompanyId = companyId;
                    _appContext.AccYearId = 0;
                }
            }

            await next(context);
        }
    }
}
