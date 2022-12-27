﻿using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebApplication1.Areas.Adminn.ViewModels.Slider;

public class SlideCreateVM
{

    [Required]
    public IFormFile Photo { get; set; }
    [MaxLength(100)]
    public string? Offer { get; set; }
    [Required,MaxLength(150)]
    public string? Title { get; set; }
    [MaxLength(255)]
    public string? Description { get; set; }
}
