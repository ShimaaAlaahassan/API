﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Task1_API.Models;

[Table("Course")]
public partial class Course
{
    [Key]
    public int id { get; set; }

    [Column("Crs-Name")]
    [StringLength(50)]
    public string Crs_Name { get; set; }

    [Column("Crs-desc")]
    [StringLength(150)]
    public string Crs_desc { get; set; }

    public int? duration { get; set; }
}