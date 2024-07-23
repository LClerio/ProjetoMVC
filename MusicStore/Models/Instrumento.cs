using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Instrumento
    {
        [Key]
        public int InstrumentoId { get; set; }

        [Required(ErrorMessage = "O nome do instumento deve ser informado")]
        [Display(Name = "instumento")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string InstrumentoNome { get; set; }

        [Required(ErrorMessage = "A descrição do instumento deve ser informada")]
        [Display(Name = "Resumo")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição pode exceder {1} caracteres")]
        public string Resumo { get; set; }

        [Required(ErrorMessage = "O descrição detalhada do instumento deve ser informada")]
        [Display(Name = "Descrição detalhada do instumento")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(800, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
        public string ResumoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do instumento")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Destaque")]
        public bool Destaque { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }


    }
}
