using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.Data;

[Route("api/imc")]
[ApiController]
public class ImcController : ControllerBase{
        private readonly AppDataContext _ctx;
        public ImcController(AppDataContext ctx ) =>
        _ctx = ctx;

[HttpPost]
[Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Imc imc){

        _ctx.Imcs.Add(imc);
        _ctx.SaveChanges();
        return Created("",imc);
    }

[HttpPatch]
[Route("alterar/{id}")]

public IActionResult Alterar([FromRoute]int id,[FromBody]Imc imc ){

    var existingImc = _ctx.Imcs.FirstOrDefault(f => f.ImcId ==id );
    existingImc.Peso = imc.Peso;
    existingImc.Altura = imc.Altura;
    existingImc.Classificacao = imc.Classificacao;
     existingImc.ValorImc = imc.ValorImc;

    _ctx.Imcs.Update(existingImc);
    _ctx.SaveChanges();
    return Ok(existingImc);
}

[HttpGet]
[Route("listar")]
 public IActionResult Listar(){
    var  imcs = _ctx.Imcs.Include(i =>i.Aluno).ToList();
    return Ok(imcs);
 }
}      
