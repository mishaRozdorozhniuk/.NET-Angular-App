using System;
using Microsoft.AspNetCore.Mvc;
using ApiAds.Controllers.Request;
using ApiAds.Services;
namespace ApiAds.Controllers;

[ApiController]
[Route("[controller]")]
public class AdsControllers : ControllerBase
{
    private readonly AdServices _adService;

    public AdsControllers(AdServices adService)
    {
        _adService = adService;
    }

    [HttpPost("ad")]
    public async Task<IActionResult> CreateAd([FromBody] AdRequest adRequest)
       => Ok(await _adService.CreateAdAsync(adRequest));

    [HttpGet("ads")]
    public async Task<IActionResult> GetAds([FromQuery] AdsQueryParameters queryParams)
       => Ok(await _adService.GetAdsAsync(queryParams));

    [HttpGet("gid")]
    public async Task<IActionResult> GetAdById(Guid gid)
        => Ok(await _adService.GetByGidAsync(gid));
}

public class AdsQueryParameters
{
    public string SortBy { get; set; } = string.Empty;

    public bool Ascending { get; set; }

    public int Skip { get; set; }

    public int Take { get; set; }
}