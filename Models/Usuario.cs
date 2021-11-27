using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UsuarioAPI.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get;set; }

        [MaxLength(100)]
        [Column("nome")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get;set; }

        [MaxLength(150)]
        [Column("email")]
        [Required]
        //[Index(IsUnique=true)] #Ef 6+
        public string Email { get;set; }

        [MaxLength(45)]
        [Column("senha")]
        [Required]
        public string Senha { get;set; }
        
        [Column("empresa_id")]
        public int? IdEmpresa { get;set; }

        [Column("observacao", TypeName="text")]
        [Required(ErrorMessage = "A observação é obrigatória")]
        public string Observacao { get;set; }

        [Column("data_criacao")]
        [Required]
        public DateTime DataCriacao { get;set; }

        [Column("data_atualizacao")]
        [Required]
        public DateTime DataAtualizacao { get;set; }
    }
}