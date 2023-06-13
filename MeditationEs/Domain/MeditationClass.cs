using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MeditationEs.Domain
{
	public class MeditationClass
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public int pageNumber { get; set; }

        public string text { get; set; } = null!;

        public string dateDisplay { get; set; } = null!;

        public string dateTemp { get; set; } = null!;

        public string date { get; set; } = null!;

        public string title { get; set; } = null!;

        public string verseText { get; set; } = null!;

        public string verseRef { get; set; } = null!;
    }
}