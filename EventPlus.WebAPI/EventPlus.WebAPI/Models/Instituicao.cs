using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("Instituicao")]
[Index("Cnpj", Name = "UQ__Institui__AA57D6B4DB42AA0A", IsUnique = true)]
public partial class Instituicao
{
    [Key]
    public Guid IdInstituicao { get; set; }

    [StringLength(100)]
    public string Endereco { get; set; } = null!;

    [StringLength(100)]
    public string NomeFantasia { get; set; } = null!;

    [Column("CNPJ")]
    [StringLength(14)]
    public string Cnpj { get; set; } = null!;

    [InverseProperty("IdInstituicaoNavigation")]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
