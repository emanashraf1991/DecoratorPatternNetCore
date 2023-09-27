using DecoratorPatternNetCore.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DecoratorPatternNetCore.Repos{
    public class CachingMemberRepository : IMemberRepository
{
    private readonly IMemberRepository _repository;
    private readonly IMemoryCache _cache;

    public CachingMemberRepository(
        IMemberRepository repository,
        IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public Member GetById(int id)
    {
        string key = $"members-{id}";

        return _cache.GetOrCreate(
            key,
            entry => {
                entry.SetAbsoluteExpiration(
                    TimeSpan.FromMinutes(5));


                return _repository.GetById(id);
            });
    }
}
}