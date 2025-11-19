public class UrlsServices
{
    private readonly URLRepository _repository;
    public UrlsServices(URLRepository repository)
    {
        _repository = repository;
    }

    public URLModel CreateShortUrl(string originalUrl)
    {
        //Validar URL

        if (!Uri.IsWellFormedUriString(originalUrl, UriKind.Absolute))
        {
            throw new ArgumentException("URL inválida");
        }
        //Gerar Url Curta
        string shortCode = GenerateShortCode();
        var urlModel = new URLModel
        {
            OriginalURL = originalUrl,
            ShortenedURL = shortCode
        };
        _repository.Insert(urlModel);
        return urlModel;
    }
   
    //Buscar todas as URLs
    public List<URLModel> GetAllUrls()
    {
        return _repository.GetAll();
    }
    //Buscar URL Curta
    public URLModel GetByShortenedUrl(string shortenedURL)
    {
        if(string.IsNullOrEmpty(shortenedURL))
        {
            throw new ArgumentException("URL curta inválida");
        }
        return _repository.GetByShortenedUrl(shortenedURL);
    }
    //Atualizar URL
    public void UpdateUrl(URLModel url)
    {
        if(string.IsNullOrEmpty(url.ShortenedURL))
        {
            throw new ArgumentException("URL curta inválida");
        }
        _repository.Update(url);
    }
    //Deletar URL
    public bool DeleteUrl(string shortenedURL)
    {
        if(string.IsNullOrEmpty(shortenedURL))
        {
            throw new ArgumentException("URL curta inválida");
        }
        return _repository.Delete(shortenedURL);
    }

    //Função para gerar código curto
    private string GenerateShortCode()
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();

        string shortCode;
        do
        {
            shortCode = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        } while (_repository.GetByShortenedUrl(shortCode) != null);
       
        return shortCode;
    }

}
