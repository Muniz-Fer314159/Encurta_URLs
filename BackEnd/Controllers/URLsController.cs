using Microsoft.AspNetCore.Mvc;

//controller teste para verificar a conexão com o banco MongoDB

[ApiController]
[Route("[controller]")]
public class UrlsController : ControllerBase
{
    private readonly UrlsServices _services;

    public UrlsController(UrlsServices services)
    {
        _services = services;
    }

    //Criar URL curta
    [HttpPost ("encurtar")]
    public IActionResult CreateShortUrl([FromBody] string originalURL)
    {
        try
        {
            var result = _services.CreateShortUrl(originalURL);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    //Listar por URL curta
    [HttpGet("{shortenedURL}")]
    public IActionResult GetByShortenedUrl (string shortenedURL)
    {
            var url = _services.GetByShortenedUrl(shortenedURL);

            if (url == null)
            {
                return NotFound("URL não encontrada.");
            }
            return Ok(url);
    }
    //Listar todas as URLs
    [HttpGet]
    public IActionResult GetAllUrls()
    {
        var urls = _services.GetAllUrls();
        return Ok(urls);
    }
    //Atualizar URL
    [HttpPut ("{shortenedURL}")]
        public IActionResult Update (string shortenedURL, [FromBody] string newOriginalUrl)
    {
        var existingUrl = _services.GetByShortenedUrl(shortenedURL);

        if (existingUrl == null)
        {
            return NotFound("URL não encontrada.");

        }
        existingUrl.OriginalURL = newOriginalUrl;
        _services.UpdateUrl(existingUrl);

        return Ok(existingUrl);
    }
    //Deletar URL
    [HttpDelete ("{shortenedURL}")]
    public IActionResult Delete (string shortenedURL)
    {
        var delete = _services.DeleteUrl(shortenedURL);
        if (!delete)
        {
            return NotFound("URL não encontrada.");
        }

        return Ok("URL deletada com sucesso.");
    }
    //Redirecionamento de Urls
    [HttpGet("r/{shortenedURL}")]
    public IActionResult RedirectToOriginalUrl(string shortenedURL)
    {
        var url = _services.GetByShortenedUrl(shortenedURL);

        if (url == null)
        {
            return NotFound("URL não encontrada.");
        }
        return Redirect(url.OriginalURL);
    }
    

}


