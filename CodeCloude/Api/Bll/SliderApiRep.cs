using CodeCloude.Data;
using CodeCloude.Models;
using static CodeCloude.Api.Bll.SliderApiRep;

namespace CodeCloude.Api.Bll
{
    public class SliderApiRep : ISliderApiRep
    {
        private readonly CodeCloude_DbContext db;
        public SliderApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<SliderVM> GetAll()
        {

            var data = db.Slider.Select(a => new SliderVM
            {

                Id = a.Id,
                Title = a.Title,
                Sub_Title = a.Sub_Title,
            
                Slider_ImgUrl = "/Uploads/Slider/" + a.Slider_ImgUrl,
            });

            return data;

        }

     
        public interface ISliderApiRep
        {
            IEnumerable<SliderVM> GetAll();


        }
    }
}