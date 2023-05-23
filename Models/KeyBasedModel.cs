using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewTest.Models
{
    public class KeyBasedModel<T> where T : struct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.ComponentModel.DataAnnotations.Key]
        public T Id { get; set; }
    }
}
