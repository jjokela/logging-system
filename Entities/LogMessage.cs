using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class LogMessage
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
        public DateTime Created { get; set; }
        public bool IsRead { get; set; }
    }
}
