using CodeCloude.Data;
using CodeCloude.Models;

namespace CodeCloude.Api.Bll
{
    public class QuestionsApiRep : IQuestionsApiRep
    {
        
        private readonly CodeCloude_DbContext db;
        public QuestionsApiRep(CodeCloude_DbContext db)
        {
            this.db = db;
        }
        public IEnumerable<QuestionsVM> GetAll()
        {

            var data = db.Questions.Select(a => new QuestionsVM
            {

                Id = a.Id,
                Question = a.Question,
                Answer = a.Answer,

            });

            return data;

        }
    }
    public interface IQuestionsApiRep
    {
        IEnumerable<QuestionsVM> GetAll();


    }


}

