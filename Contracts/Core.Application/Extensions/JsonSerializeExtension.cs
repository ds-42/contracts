using System.Text.Json.Serialization;
using System.Text.Json;

namespace Core.Application.Extensions;

public static class JsonSerializeExtension
{
    public static string JsonSerialize(this object value)
    {
        return JsonSerializer.Serialize(value, new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });
    }
}
