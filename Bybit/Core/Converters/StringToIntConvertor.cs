using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bybit.Core.Converters
{
    public class StringToIntConvertor : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), out int result)
                ? result
                : reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException($"Unable to parse {value} to int");
        }
    }
}
