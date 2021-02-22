using System.ComponentModel.DataAnnotations;

namespace IRT.Api.Models
{
    public class Parameter<T> where T : class
    {
        public T Filter { get; set; }

        [Required]
        public int MaxResults { get; set; }
    }
}
