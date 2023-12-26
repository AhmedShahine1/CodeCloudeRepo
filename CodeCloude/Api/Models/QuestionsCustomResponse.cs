using CodeCloude.API.Models;
using CodeCloude.Models;

namespace CodeCloude.Api.Models
{
    public class QuestionsCustomResponse : CustomResponse
    {
        public IEnumerable<QuestionsVM> Records { get; set; }
        public QuestionsVM Record { get; set; }
    }
}
