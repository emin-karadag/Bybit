using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bybit.Core.Converters
{
    public class LongToDateTimeConvertor : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.Number
                ? DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).DateTime
                : default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException($"Unable to parse {value} to datetime");
        }
    }
}
