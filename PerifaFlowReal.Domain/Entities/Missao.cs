namespace PerifaFlow.Domain.Entities;

public class Missao : Audit
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public Entrega? Entrega { get; private set; }
    
    public Guid TrilhaId { get; private set; }
    public Trilha Trilha { get; private set; }

    public Missao()
    {
        
    }

    public Missao(string titulo, string descricao, Guid trilhaId)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Descricao = descricao;
        TrilhaId = trilhaId;
        
        SetCreated(CreatedBy);
    }

    public void Uodate(string titulo, string descricao)
    {
        Titulo = titulo;
        Descricao = descricao;
        
        SetUpdated(UpdatedBy);
    }
}