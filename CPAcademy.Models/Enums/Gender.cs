using System.Text.Json.Serialization;
namespace CPAcademy.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male,
        Female,
    }
}
