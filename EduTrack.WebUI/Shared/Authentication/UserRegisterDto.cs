namespace EduTrack.Contracts.Authentication
{
    public record UserRegisterDto(    
        string? Email, 
        string? Password,
        string? FirstName,
        string? LastName
    );
}