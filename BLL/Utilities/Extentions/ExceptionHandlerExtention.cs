

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BLL.Utilities.Extentions
{
    public static class ExceptionHandlerExtention
    {
        public static void CustomExceptionHandler(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    int statusCode = 500;
                    string msg = "Internal server error!";

                    if (contextFeature != null)
                    {
                        msg = contextFeature.Error.Message;

                        if (contextFeature.Error is NotFoundException)
                            statusCode = 404;

                        context.Response.Redirect("/Home/ErrorPage");

                    }
                    else
                    {
                        context.Response.StatusCode = statusCode;

                        string responseStr = JsonConvert.SerializeObject(new
                        {
                            code = statusCode,
                            message = msg
                        });

                        await context.Response.WriteAsync(responseStr);
                    }

                  
                });
            }); 
        }
    }
}
