//using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace FigureDrawing
{
    class Figure
    {
        [JsonPropertyName("X")]
        public int X { get; set; }
        [JsonPropertyName("Y")]
        public int Y { get; set; }
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Shape")]
        public char[][] Shape { get; set; }
        public virtual char[][] Draw(int width)
        {
            return null;
        }
    }
}
