using ImageTagApi.Models;
using ImageTagApi.Repositories;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;


namespace ImageTagApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureRepository _pictureRepository;

        public PictureController(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }
        
        [HttpGet(Name = "ListPictures")]
        public async Task<IActionResult> ListPictures()
        {
            var pics = await _pictureRepository.Get();
            if(pics.Any()){
                return Ok(pics);
            }

            return NotFound();
            // return await _pictureRepository.Get();
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<Picture>> GetPictures(int id)
        // {
        //     return await _pictureRepository.Get(id);
        // }


        [HttpGet("{tag}")]
        public async Task<IEnumerable<Picture>> GetPicturesByTag(string tag)
        {
            return await _pictureRepository.GetByTag(tag);
        }

        [HttpPost]
        public async Task<ActionResult<Picture>> PostPictures([FromBody] Picture picture)
        {
            var newPic = await _pictureRepository.Create(picture);            
            return CreatedAtAction(nameof(ListPictures), new {Pic = newPic.PictureId}, newPic);            
        }

        // [HttpPost]
        // public string PostPictures([FromBody] Picture json)
        // {
        //     // IEnumerable<Picture> p = JsonConvert.DeserializeObject<Picture>(json);
        //     // List<Tag> tags = JsonConvert.DeserializeObject<List<Tag>>(json);
        //     return json.FileName;
        // }

        // [HttpPut]
        // public async Task<ActionResult<Picture>> PutPictures(int id, [FromBody]  Picture picture)
        // {
        //     if(id != picture.Id)
        //         return BadRequest();

        //     await _pictureRepository.Update(picture);

        //     return NoContent();
        // }

    }
}