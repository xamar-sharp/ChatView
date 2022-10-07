using System;
using System.Collections.Generic;
using System.Text;

namespace ChatView.Models
{
    public class MessageDTO
    {
        public string IconURI { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Login { get; set; }
        public string TextMessage { get; set; }
    }
}
