using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestTask.Infrastructure.Models;

[Table("logs")]
public partial class Log
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user")]
    public string User { get; set; } = null!;

    [Column("datetime", TypeName = "timestamp without time zone")]
    public DateTime Datetime { get; set; }

    [Column("recordtype")]
    public int Recordtype { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("logguid")]
    public Guid? Logguid { get; set; }

    [Column("logguidlinked")]
    public Guid? Logguidlinked { get; set; }

    [Column("entity")]
    public int? Entity { get; set; }

    [Column("eventinfo")]
    public int? Eventinfo { get; set; }

    [Column("fieldname")]
    public string? Fieldname { get; set; }

    [Column("oldvalue")]
    public string? Oldvalue { get; set; }

    [Column("newvalue")]
    public string? Newvalue { get; set; }
}
