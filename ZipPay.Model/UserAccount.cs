using System.ComponentModel.DataAnnotations.Schema;

namespace ZipPay.Model
{
    public class UserAccount : IEntity<long>
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long UserId { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}