using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Sabre.Common.Models;

public abstract class ResponseModelBase
{
    public bool Success { get; set; } = false;
    public string? HostCommand { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

    public string[] Errors { get; set; } = [];
    public string[] Warnings { get; set; } = [];
}
