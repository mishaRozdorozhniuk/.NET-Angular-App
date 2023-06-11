using System;
namespace ApiAds.Models;

public class Ad
{
    public Guid Gid { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Name { get; set; } = string.Empty;

	public string PhotoLink { get; set; } = string.Empty;

    public int Price { get; set; }
}
