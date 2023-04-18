using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDemosMVC.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; } //caso va ser salva no DB

        [Required(ErrorMessage ="O campo Título é obrigatório!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="O título precisar ter entre 3 e 20 caracteres")]
        public string? Titulo { get; set; }

        [DataType(DataType.DateTime, ErrorMessage ="Formato de data não está correto!")]
        [Display(Name ="Data de Lançamento")] //altera como sera exibido
        public DateTime DataLancamento { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$")] //inicia com maiuscula, depois minuscula e aceita acentuação
        [Required]
        public string? Genero { get; set; }

        [Range(1,1000)] //entre 1 e 1000
        [Required(ErrorMessage ="O campo {0} obrigatório")]
        [Column(TypeName ="decimal(18,2)")] //tamanho maximo a ser criado no banco de dados
        public decimal Valor { get; set; }

        [RegularExpression(@"^[0-5]*$", ErrorMessage ="Somente números")]
        [Display(Name ="Avaliação")]
        public int Avaliacao { get; set; }
    }
}
