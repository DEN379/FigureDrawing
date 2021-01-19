using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace FigureDrawing
{
    class Figure
    {
        [JsonProperty("X")]
        public int X { get; set; }
        [JsonProperty("Y")]
        public int Y { get; set; }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Shape")]
        public char[,] Shape { get; set; }
        public virtual char[,] Draw(int width)
        {
            return null;
        }
    }
}
