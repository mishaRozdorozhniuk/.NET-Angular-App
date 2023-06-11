using System;
using ApiAds.Abstract;
using ApiAds.Controllers;
using ApiAds.Controllers.Request;
using ApiAds.DAL;
using ApiAds.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAds.Services;

public class AdServices
{
    private readonly AdsContext _adsContext;

    public AdServices(AdsContext adsContext)
    {
        _adsContext = adsContext;
    }

    public async Task<DataServiceMessage> CreateAdAsync(AdRequest adRequest)
    {
        var isAdExist = await _adsContext.Ad.FirstOrDefaultAsync(x => x.Name == adRequest.Name);

        if (isAdExist is not null) return new DataServiceMessage(false, "Ad already created");

        var ad = new Ad();

        ad.Name = adRequest.Name;
        ad.PhotoLink = adRequest.PhotoLink;
        ad.Price = adRequest.Price;
        ad.CreatedDate = adRequest.CreatedDate;

        await _adsContext.Ad.AddAsync(ad);
        await _adsContext.SaveChangesAsync();

        return new DataServiceMessage(true, ad);
    }

    public async Task<List<Ad>> GetAdsAsync(AdsQueryParameters queryParams)
    {
        IQueryable<Ad> query = _adsContext.Ad;

        switch (queryParams.SortBy.ToLower())
        {
            case "price":
                query = queryParams.Ascending ? query.OrderBy(ad => ad.Price) : query.OrderByDescending(ad => ad.Price);
                break;
            case "date":
                query = queryParams.Ascending ? query.OrderBy(ad => ad.CreatedDate) : query.OrderByDescending(ad => ad.CreatedDate);
                break;
            default:
                break;
        }

        query = query.Skip(queryParams.Skip).Take(queryParams.Take);

        return await query.ToListAsync();

    }

    public async Task<Ad> GetByGidAsync(Guid gid)
        => await _adsContext.Ad.FindAsync(gid);
}

