using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Meditation.api.Models
{
	public class MeditationClass
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }

        public int pageNumber { get; private set; }

        public string text { get; private set; } = null!;

        public string dateDisplay { get; private set; } = null!;

        public string dateTemp { get; private set; } = null!;

        public string date { get; private set; } = null!;

        public string title { get; private set; } = null!;

        public string verseText { get; private set; } = null!;

        public string verseRef { get; private set; } = null!;
    }
}