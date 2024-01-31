using System;
using System.Text.Json;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class QuotedDoubleConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return Convert.ToDouble(reader.GetString());
            }
            else
            {
                return reader.GetDouble();
            }
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            // throw new NotImplementedException();
            //writer.WriteStartObject();
            writer.WriteNumberValue(value);
            //writer.WriteEndObject();
        }
    }

    public class QuotedIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return Convert.ToInt32(reader.GetString());
            }
            else
            {
                return reader.GetInt32();
            }
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            // throw new NotImplementedException();
            //writer.WriteStartObject();
            writer.WriteNumberValue(value);
            //writer.WriteEndObject();
        }
    }
}

