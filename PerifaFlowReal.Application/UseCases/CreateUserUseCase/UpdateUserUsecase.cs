using PerifaFlowReal.Application.Dtos.Request;
using PerifaFlowReal.Application.Interfaces.Repositories;

namespace PerifaFlowReal.Application.UseCases.CreateUserUseCase;

public class UpdateUserUsecase(IUserRepository userRepository): IUpdateUserUseCase
{
    public async Task<bool> Execute(Guid userId, UserRequest request)
    {
        var user = await userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new KeyNotFoundException($"Usuario com id: {userId}, Não foi encontrado");
        
        
        user.Update(
            request.Username,
            request.Email,
            request.Password
        );
        
        await userRepository.UpdateAsync(user);
        
        return true;
    }
}