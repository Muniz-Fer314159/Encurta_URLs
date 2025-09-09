using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
class URLModel

{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id { get; set; }
    public string OriginalURL { get; set; }
    public string ShortenedURL { get; set; }

    //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    //public int ClickCount { get; set; } = 0;

}