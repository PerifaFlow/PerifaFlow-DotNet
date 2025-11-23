using System.Data;

namespace PerifaFlow.Domain.Entities;

public class Trilha : Audit
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public List<Missao> Missao { get; private set; }

    public Trilha(string titulo, string descricao)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Descricao = descricao;
        Missao = new List<Missao>();
        
        SetCreated(CreatedBy);
    }

    public void Update(string titulo, string descricao)
    {
        Titulo = titulo;
        Descricao = descricao;
        
        SetUpdated(UpdatedBy);
    }
}