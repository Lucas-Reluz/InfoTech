using System.Text.Json.Serialization;

namespace InfoTech.src.tipos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoUsuario
    {
        COMUM,
        ADMIN
    }
}
