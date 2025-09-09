using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//Criação do modelo de URL
public class URLModel

{
    //define o ID como chave primária do MongoDB

    [BsonId]
    
    //define o tipo do ID como string
    [BsonRepresentation(BsonType.ObjectId)]

    public string Id { get; set; } = string.Empty;
    public string OriginalURL { get; set; } = string.Empty;
    public string ShortenedURL { get; set; } = string.Empty;

    //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    //public int ClickCount { get; set; } = 0;

}