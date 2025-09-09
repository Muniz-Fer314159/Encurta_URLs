using Microsoft.AspNetCore.Mvc;

//controller teste para verificar a conexão com o banco MongoDB

[ApiController]
[Route("[controller]")]
public class UrlsController : ControllerBase
{
    private readonly URLRepository _repository;

    public UrlsController(URLRepository repository)
    {
        _repository = repository;
    }

    // Endpoint de teste de conexão
    [HttpPost("test-insert")]
    public IActionResult TestInsert()
    {
        var url = new URLModel
        {
            OriginalURL = "https://example.com",
            ShortenedURL = "ex123"
        };

        _repository.Insert(url);
        return Ok("URL inserida no Mongo com sucesso!");
    }

    // Endpoint de teste de leitura
    [HttpGet("test-get/{shortUrl}")]
    public IActionResult TestGet(string shortUrl)
    {
        var url = _repository.GetByShortenedUrl(shortUrl);
        if (url == null) return NotFound("URL não encontrada no Mongo");
        return Ok(url);
    }
}
