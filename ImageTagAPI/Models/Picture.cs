using System.Text;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ImageTagApi.Models
{
    [Table("pictures")]
    public class Picture : PictureContent
    {
        public Picture() {}
        internal Picture(PictureContent content)
        {
            this.Tags = content.Tags;
            this.Title = content.Title;
            this.Description = content.Description;
            this.TimeStampUtc = DateTime.UtcNow;
        }

        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema("Picture Id", ReadOnly = true)]
        [Column("pictureid")]

        public int PictureId { get; set; }

        [Column("filename")]
        public string FileName { get; set; }

        [SwaggerSchema("When the data first added", ReadOnly = true)]
        public DateTime TimeStampUtc { get; set; }

        //Relationship properties        
        // public ICollection<PictureTag> PictureTags { get; set; }

    }
    //User Modifiable portion of the data
    public class PictureContent
    {

        // [SwaggerSchema("Image bytes",ReadOnly = true)]
        [Column("tags")]
        public string Tags { get; set; }
        [Column("title")]
        public string Title  { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}