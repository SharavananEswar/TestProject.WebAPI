using System.ComponentModel.DataAnnotations.Schema;

namespace ZipPay.Model
{
    public class User : IEntity<long>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public long MonthlySalary { get; set; }
        public long MonthlyExpenses { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}