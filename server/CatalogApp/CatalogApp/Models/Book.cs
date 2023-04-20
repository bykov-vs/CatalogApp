using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogApp.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string name { get; set; }
    public string author { get; set; }
    public int yearOfPubl { get; set; }
    public int pages { get; set; }
    public string publisher { get; set; }
    public string genre { get; set; }
    public string description { get; set; }
}