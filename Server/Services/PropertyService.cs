using Microsoft.AspNetCore.Authentication;

using ShareInvest.Mappers;

using System.Reflection;

namespace ShareInvest.Server.Services;

public class PropertyService : IPropertyService
{
    public IEnumerable<AuthenticationToken> GetEnumerator<T>(T property) where T : class
    {
        if (property != null)
            foreach (var pi in property.GetType()
                                       .GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (pi.PropertyType == typeof(bool))
                    continue;

                if (pi.PropertyType != typeof(string) &&
                    pi.PropertyType.IsClass)
                {
                    var ctor = pi.GetValue(property);

                    if (ctor != null)
                        foreach (var token in GetEnumerator(ctor))
                        {
                            yield return token;
                        }
                    continue;
                }
                yield return new AuthenticationToken
                {
                    Name = pi.Name,
                    Value = Convert.ToString(pi.GetValue(property)) ?? string.Empty
                };
            }
    }
    public void SetValuesOfColumn<T>(T tuple, T param) where T : class
    {
        foreach (var property in tuple.GetType()
                                      .GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            if (property.CustomAttributes
                        .Any(o => Array.Exists(Status.Types,
                                               type => type == o.AttributeType)))
                continue;

            var obj = param.GetType()
                           .GetProperty(property.Name)?
                           .GetValue(param);

            string? value = obj?.ToString(),

                    existingValue = property.GetValue(tuple)?
                                            .ToString();

            if (string.IsNullOrEmpty(value) || value.Equals(existingValue))

                continue;

            property.SetValue(tuple, obj);
        }
    }
    public IEnumerable<T> OrderBy<T>(string? name,
                                     IEnumerable<T> param) where T : class
    {
        if (string.IsNullOrEmpty(name))
        {
            return param;
        }
        return param.ToArray()
                    .OrderBy(o => Convert.ToDouble(o.GetType()
                                                    .GetProperty(name,
                                                                 BindingFlags.Public |
                                                                 BindingFlags.Instance)?
                                                    .GetValue(o)));
    }
    public IEnumerable<T> OrderByDescending<T>(string? name,
                                               IEnumerable<T> param) where T : class
    {
        if (string.IsNullOrEmpty(name))
        {
            return param;
        }
        return param.ToArray()
                    .OrderByDescending(o => Convert.ToDouble(o.GetType()
                                                              .GetProperty(name,
                                                                           BindingFlags.Public |
                                                                           BindingFlags.Instance)?
                                                              .GetValue(o)));
    }
}