using System.Reflection;

namespace ShareInvest.Server.Services;

public class PropertyService
{
    public void SetValueOfColumn<T>(T tuple, T param) where T : class
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
}