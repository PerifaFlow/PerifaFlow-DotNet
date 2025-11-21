namespace PerifaFlow.Domain.Entities;

public class Audit
{
    public DateTime CreatedAt { get; protected set; }
    public string CreatedBy { get; protected set; } = string.Empty; 
    
    public DateTime UpdatedAt { get; protected set; }
    public string UpdatedBy { get; protected set; } = string.Empty;
    
    // Método para inicializar a criação
    protected void SetCreated(string user)
    {
        CreatedAt = DateTime.UtcNow;
        CreatedBy = user;
        UpdatedAt = CreatedAt;
        UpdatedBy = CreatedBy;
    }

    // Método para atualizar auditoria
    protected void SetUpdated(string user)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = user;
    }
}