using DecoratorPatternNetCore.Data;
using DecoratorPatternNetCore.Models; 

namespace DecoratorPatternNetCore.Repos{
    public class MemberRepository : IMemberRepository
{
    private readonly DatabaseContext _dbContext;

    public MemberRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Member GetById(int id)
    {
        return _dbContext
            .Set<Member>()
            .First(member => member.Id == id);
    }

      
    }
}