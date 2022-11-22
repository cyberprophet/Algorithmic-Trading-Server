using System.Text.RegularExpressions;

namespace ShareInvest.Server.Extensions.Options;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value is not null)

            return Regex.Replace(value.ToString()!,
                                 "([a-z])([A-Z])",
                                 "$1-$2",
                                 RegexOptions.CultureInvariant,
                                 TimeSpan.FromMilliseconds(0x64))
                        .ToLowerInvariant();
        return null;
    }
}