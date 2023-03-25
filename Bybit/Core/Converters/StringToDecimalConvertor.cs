using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bybit.Core.Converters
{
    public class StringToDecimalConvertor : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType == JsonTokenType.String && decimal.TryParse(reader.GetString(), NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result)
                ? result
                : 0;
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException($"Unable to parse {value} to decimal");
        }
    }
}
