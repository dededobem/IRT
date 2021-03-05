using System.ComponentModel.DataAnnotations;

namespace IRT.Api.Models
{
    public class RequestDrusgtore
    {
        public string Name { get; set; }

        [Required]
        public int MaxResults { get; set; }
    }
}
