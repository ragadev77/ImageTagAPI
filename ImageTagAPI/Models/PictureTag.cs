
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageTagApi.Models
{
    [Table("picture_tag")]
    public class PictureTag
    {
        [Column("pictureid")]
        public int PictureId { get; set; }
        [Column("tagid")]
        public int TagId { get; set; }
    }
}