using MessagePack;

namespace CodeCloude.Data.Entities
{
    public class ContcatUs
    {
        public int Id { get; set; }
        public string About_App { get; set; }
        public string Our_Vision { get; set; }
        public string Our_Goals { get; set; }

        //Social Media Links
        public string Insat_Link { get; set; }
        public string Faceebokk_Link { get; set; }
        public string LinkdLin_Link { get; set; }
        public string Twitter_Link { get; set; }
    }
}
