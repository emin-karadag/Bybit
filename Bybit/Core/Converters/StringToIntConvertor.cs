using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bybit.Core.Converters
{
    public class StringToIntConvertor : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                return 0;

            _ = int.TryParse(reader.GetString(), out int result);
            return result;
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException($"Unable to parse {value} to int");
        }
    }
}
