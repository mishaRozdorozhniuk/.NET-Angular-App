using System;
namespace ApiAds.Controllers.Request;

public class AdRequest
{
    public string Name { get; set; } = string.Empty;

    public int Price { get; set; }

    public string PhotoLink { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
}