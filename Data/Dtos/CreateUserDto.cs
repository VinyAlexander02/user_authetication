using System.ComponentModel.DataAnnotations;

namespace user_auth.Data.Dto;

public class CreateUserDto
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public DateTime BornDate { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [Compare("Password")]
    public string? RePassword { get; set; }
}