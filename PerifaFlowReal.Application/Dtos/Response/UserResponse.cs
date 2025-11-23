using PerifaFlow.Domain.Entities;

namespace PerifaFlowReal.Application.Dtos.Response;

public class UserResponse
{
    public UserResponse(Guid userId, string userUsername, string userEmail, string userPassword)
    {
        Id = userId;
        Username = userUsername;
        Email = userEmail;
        Password = userPassword;
    }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Entrega> Entregas { get; set; }
    public Portfolio? Portfolio { get; set; }
    
}