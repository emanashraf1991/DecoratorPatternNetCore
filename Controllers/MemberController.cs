using DecoratorPatternNetCore.Models;
using DecoratorPatternNetCore.Repos;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPatternNetCore.Controllers;

[ApiController]
[Route("[controller]")]
public class MemberController : ControllerBase
{
  private readonly ILogger<MemberController> _logger;
  private readonly IMemberRepository _member;

    public MemberController(ILogger<MemberController> logger, IMemberRepository member)
    {
        _logger = logger;
        _member = member;
    }

    [HttpGet(Name = "Get")]
    public Member Get(int Id)
    {
       return _member.GetById(Id);
    }
}