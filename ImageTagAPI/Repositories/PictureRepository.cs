using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using ImageTagApi.Models;

namespace ImageTagApi.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        private readonly PictureContext _context;

        public PictureRepository(PictureContext context){
            _context  = context;
        }
        public async Task<IEnumerable<Picture>> Get(){
            return await _context.Pictures.ToListAsync();

        }
        public async Task<Picture> Get(int id){
            return await _context.Pictures.FindAsync(id);
        }

        public async Task<IEnumerable<Picture>> GetByTag(string searchValue){

            // Query for all tags with values contains param
            // var retTags = from b in _context.Tags
            //             where b.Name.Contains(searchValue)
            //             select b;

            var pictureTags = from t in _context.Tags
                        where t.Name.Contains(searchValue)
                        join pt in _context.PictureTags
                            on t.TagId equals pt.TagId
                        select pt;
            
            var pics = from p in _context.Pictures
                        join pt in pictureTags
                        on p.PictureId equals pt.PictureId
                        select p;                                                                               
    
            return await pics.ToListAsync();            

        }

        public async Task<Picture> Create(Picture picture){
        
        // Picture picture = JsonConvert.DeserializeObject<Picture>(jsonData);
        // List<Tag> tags = JsonConvert.DeserializeObject<List<Tag>>(jsonData);
 
        _context.Pictures.Add(picture);
        _context.SaveChanges();

        //split tags string
        List<string> tags = picture.Tags?.Split(',').ToList();

        Tag newTag = new Tag();
        List<PictureTag> pictureTags = new List<PictureTag>();

        foreach (string strTag in tags)
        {
            var duplicates = (from t in _context.Tags
                        where t.Name.Equals(strTag)
                        select t).FirstOrDefault();

            if(duplicates==null) {
                newTag.Name = strTag;
                _context.Tags.Add(newTag);        
                _context.SaveChanges();                
                pictureTags.Add(new PictureTag{ PictureId = picture.PictureId, TagId = newTag.TagId});
            } else 
            {
                pictureTags.Add(new PictureTag{ PictureId = picture.PictureId, TagId = duplicates.TagId});
            }

        }
            /* TEMP */
            /* generate random byte for dummy image value */
            // Random rnd = new Random();
            // Byte[] b = new Byte[30];
            // var hexArray = Array.ConvertAll(b, x => x.ToString("X2"));
            // var hexStr = String.Concat(hexArray);
            // byte[] image = Encoding.Unicode.GetBytes(hexStr);

            foreach(PictureTag data in pictureTags)
            {
                _context.PictureTags.Add(data);
                await _context.SaveChangesAsync();
            }
            // _context.PictureTags.AddRange(pictureTags);
            // await _context.SaveChangesAsync();

            return picture;
        }


        // public async Task Update(Picture picture){
        //     _context.Entry(picture).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();
        // }
        // public async Task Delete(int id){
        //     var deletedPic = await _context.Pictures.FindAsync(id);
        //     _context.Pictures.Remove(deletedPic);
        //     await _context.SaveChangesAsync();
        // }
    }

}