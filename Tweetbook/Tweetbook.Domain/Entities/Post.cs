using System;
using System.ComponentModel.DataAnnotations;

namespace Tweetbook.Domain.Entities
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
