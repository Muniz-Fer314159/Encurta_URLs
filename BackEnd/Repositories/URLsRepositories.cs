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
        //Valida o nome do banco
        if(string.IsNullOrEmpty(config.Value.DatabaseName))
            throw new ArgumentException("DatabaseName não pode ser nulo");

        //cria o cliente, conecta ao banco e pega a coleção
        var client = new MongoClient(config.Value.ConnectionString);
        var database = client.GetDatabase(config.Value.DatabaseName);

        _collection = database.GetCollection<URLModel>("urls");

        //Cria índice único para ShortenedURL
        var indexKey = Builders<URLModel>.IndexKeys.Ascending(u => u.ShortenedURL);
        var indexOptions = new CreateIndexOptions { Unique = true };
        _collection.Indexes.CreateOne(new CreateIndexModel<URLModel>(indexKey, indexOptions));

    }
    //insere uma URL na coleção
    public void Insert(URLModel url)
    {
        _collection.InsertOne(url);
    }
    //busca uma URL curta na coleção
    public URLModel GetByShortenedUrl(string shortenedURL)
    {
        return _collection.Find(u => u.ShortenedURL == shortenedURL).FirstOrDefault();
    }
    //busca todas as URLs na coleção
    public List<URLModel> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }
    //Atualiza uma URL na coleção
    public void Update(URLModel url)
    {
        _collection.ReplaceOne(
            u => u.ShortenedURL == url.ShortenedURL,
            url,
            new ReplaceOptions { IsUpsert = false }
        );
    }
    //Deletar uma URL da coleção
    public bool Delete(string shortenedURL)
    {
        var result = _collection.DeleteOne(u => u.ShortenedURL == shortenedURL);
        return result.DeletedCount > 0;
    }
}