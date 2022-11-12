namespace ShareInvest.Server.Extensions;

public static class ViewExtensions
{
    public static WebApplicationBuilder ConfigureViews(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages(o =>
        {

        });
        return builder;
    }
}