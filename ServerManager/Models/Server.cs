using System.ComponentModel.DataAnnotations;

namespace ServerManager.Models
{
  public class Server
  {
    [Key]
    public int Id { get; set; }

    [Required, StringLength(20)]
    public string Name { get; set; }
    
    [Required, StringLength(6)]
    public string Instance { get; set; }
    
    [DataType(DataType.Url)]
    public string Uri { get; set; }

    [Required, StringLength(20)]
    public string IpAddress { get; set; }

    [Required]
    public string Role { get; set; }
    
    [StringLength(80)]
    public string Description { get; set; }
  }
}