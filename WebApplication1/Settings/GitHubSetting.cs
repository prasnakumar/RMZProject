using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Settings
{
    public class GitHubSetting
    { 
        public string ClientId { get; set; }

        /// <summary>
        /// Client's Secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Callback for OAuth login.
        /// </summary>
        public string CallbackPath { get; set; }
    }
}

