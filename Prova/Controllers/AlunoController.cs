using Microsoft.AspNetCore.Mvc;
using Prova.Data;

[Route("api/aluno")]
[ApiController]
    public class AlunoController : ControllerBase{
        private readonly AppDataContext _ctx;
        public AlunoController(AppDataContext ctx ) =>
        _ctx = ctx;


[HttpGet]
[Route("listar")]  

    public IActionResult Listar()
    {
        var alunos = _ctx.Alunos.ToList();
        return Ok(alunos);

    }

[HttpPost]
[Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Aluno aluno){

        _ctx.Alunos.Add(aluno);
        _ctx.SaveChanges();
        return Created("",aluno);
    }
}