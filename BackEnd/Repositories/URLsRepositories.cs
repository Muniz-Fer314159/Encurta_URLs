using MongoDB.Driver;
using Microsoft.Extensions.Options;
public class URLRepository
{
    //Configuração do MongoDB
    private readonly IMongoCollection<URLModel> _collection;
    public URLRepository(IOptions<MongoDbConfig> config)
    {
        //Valida se o valor que entra é nulo
        if (string.IsNullOrEmpty(config.Value.ConnectionString))
            throw new ArgumentException("MongoDB não pode ser nulo");

        //cria o cliente, conecta ao banco e pega a coleção
        var client = new MongoClient(config.Value.ConnectionString);
        var database = client.GetDatabase(config.Value.DatabaseName);
        _collection = database.GetCollection<URLModel>("urls");
    }
    //insere e consulta uma URL
    public void Insert(URLModel url)
    {
        _collection.InsertOne(url);
    }
    public URLModel GetByShortenedUrl(string shortenedURL)
    {
        return _collection.Find(u => u.ShortenedURL == shortenedURL).FirstOrDefault();
    }
}