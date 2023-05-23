using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace computer_info.Models
{
    [Table("ComputerInfo")]
    public class ComputerInfo
    {
        [Key]
        public string Id { get; set; }
        public string LevelName { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }

        public int StorageSize { get; set; }
        public bool isSSD { get; set; }

        public bool isActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string CreatedUserId { get; set; }


        public string UpdatedUserId { get; set; }
    }
}
