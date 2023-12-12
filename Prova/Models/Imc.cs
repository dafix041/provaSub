public class Imc
{
    public int ImcId {get;set;}
    public int AlunoId{get;set;}
    public Aluno?  Aluno {get;set;}
    public double Altura {get;set;}
    public double Peso {get;set;}
    public double ValorImc{get;set;}
    public string? Classificacao {get;set;}
    public DateTime CriadoEm {get;set;} = DateTime.Now;
public void CalcularImc(){
    ValorImc = Peso / (Altura*Altura);
}
public void CalcularClassificacao(){
    if(ValorImc < 18.5)
    {
        Classificacao = "Magreza";
    }
    else if(ValorImc >= 18.5 && ValorImc <=24.9)
    {
        Classificacao = "Normal";
    }
    else if(ValorImc >=25.9 &&  ValorImc<=29.99)
    {
        Classificacao = "Sobrepeso";
    }
    else if(ValorImc>=30.0 && ValorImc <=39.9)
    {
        Classificacao = "Obesidade";
    }
    else
    {
        Classificacao = "Obesidade grave";
    }
}
    public Imc(double altura,double peso, string classificacao){
        Altura=altura;
        Peso = peso;
        Classificacao = classificacao;
        CalcularClassificacao();
        CalcularImc();
    }

    } 