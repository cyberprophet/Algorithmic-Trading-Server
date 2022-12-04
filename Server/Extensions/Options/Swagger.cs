using ShareInvest.Server.Properties;

namespace ShareInvest.Server.Extensions.Options;

static class Swagger
{
    internal static string TransformOutbound(string parameter)
    {
        return string.Concat('/',
                             nameof(Resources.SWAGGER).ToLowerInvariant(),
                             '/',
                             parameter,
                             '/',
                             Resources.SWAGGER);
    }
}