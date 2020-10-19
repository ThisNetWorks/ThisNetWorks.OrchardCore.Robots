using System;
using System.Collections.Generic;
using System.Text;

namespace ThisNetWorks.OrchardCore.Robots.Models
{
    public class RobotsSettings
    {
        public bool MatchBaseUrlOrServeDisallow { get; set; } = true;

        public string RobotsContent { get; set; }
    }
}
