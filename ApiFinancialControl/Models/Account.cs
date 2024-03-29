﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFinancialControl.Models;

[Table("Account")]
public class Account
{
    [Column("Id")]
    [Display(Name = "Id")]

    public int Id { get; set; }

    [Column("name")]
    [Display(Name = "Name")]
    public string Name { get; set; }
    }
