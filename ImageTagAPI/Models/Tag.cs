using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ImageTagApi.Models
{
    [Table("tags")]
    public class Tag
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tagid")]
        [SwaggerSchema("The Tag Id", ReadOnly = true)]
        public int TagId { get; set; }
        [Column("name")]
        [MaxLength(50)]
        public string? Name { get; set; }     

        //Relationship properties
        // public ICollection<PictureTag> PictureTags { get; set; }   
    }
}