using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Models;

[Table("Contato")]
public partial class Contato
{
    [Key]
    public Guid IdUsuario { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string FormaDeContato { get; set; } = null!;

 

    [StringLength(400)]
    public string? Imagem { get; set; }

    public Guid? IdTipoUsuario { get; set; }

    [ForeignKey("IdTipoUsuario")]
    [InverseProperty("Contatos")]
    public virtual TipoContato? IdTipoUsuarioNavigation { get; set; }
}
