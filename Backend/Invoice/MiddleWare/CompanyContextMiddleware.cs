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
                }
            }


            if (context.Request.Headers.TryGetValue("X-AccountYear-Id", out var accountYearHeader))
            {
                if (int.TryParse(accountYearHeader, out var accountYear))
                {
                    _appContext.AccYearId = accountYear;
                }
            }


            await next(context);
        }
    }
}
