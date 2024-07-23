using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [Display(Name = "Categoria")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da categoria deve ter entre 3 e 100 caracteres.")]
        public string CategoriaNome { get; set; }

        [Required(ErrorMessage = "A descrição da categoria deve ser informada.")]
        [Display(Name = "Resumo")]
        [MinLength(20, ErrorMessage = "A descrição da categoria não pode ser menor que {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "A descrição da categoria não pode ter mais de {1}  caracteres.")]
        public string Resumo { get; set; }
        public List<Instrumento> Instrumentos { get; set; }
    }
}
