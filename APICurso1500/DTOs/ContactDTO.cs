using System.ComponentModel.DataAnnotations;

namespace APICurso1500.Models
{
    public class ContactDTO
    {
        [Required(ErrorMessage = "O campo de tipo é obrigatório!")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "O campo de e-mail é obrigatório!")]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "O campo de mensagem é obrigatório!")]
        public string? Message { get; set; }
        [Required(ErrorMessage = "O campo com o nome do app é obrigatório")]
        public string? App { get; set; }
        [Required(ErrorMessage = "O campo com o de nome é obrigatório")]
        public string? Name { get; set; }

    }
}
