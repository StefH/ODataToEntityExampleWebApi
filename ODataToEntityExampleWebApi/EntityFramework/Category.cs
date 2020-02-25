using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataToEntityExampleWebApi.EntityFramework
{
  [Table("Categories")]
  public partial class Category
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryID
    {
      get;
      set;
    }


    [InverseProperty("Category")]
    public ICollection<Product> Products { get; set; }
    public string CategoryName
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public byte[] Picture
    {
      get;
      set;
    }
  }
}
