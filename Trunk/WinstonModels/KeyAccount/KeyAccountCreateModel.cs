using System.ComponentModel.DataAnnotations;

namespace Winston.Models
{
    public class KeyAccountCreateModel
    {
        public long KeyAccountID { get; set; }

        [Required]
        public string Name { get; set; }
        public byte[] Logo { get; set; }
    }
}
