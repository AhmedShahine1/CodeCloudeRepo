//using CodeCloude.Data;
//using CodeCloude.Models;
//using static CodeCloude.Api.Bll.CarApiRep;

//namespace CodeCloude.Api.Bll
//{
//    public class CarApiRep : ICarApiRep
//    {
//        private readonly CodeCloude_DbContext db;
//        public CarApiRep(CodeCloude_DbContext db)
//        {
//            this.db = db;
//        }
//        public IEnumerable<CarsVM> GetAll()
//        {

//            var data = db.Cars.Select(a => new CarsVM
//            {

//                Id = a.Id,
//                CarModel = a.CarModel,
//                MaintenanceTime = a.MaintenanceTime,
//                CarColor = a.CarColor,
//                CarNumbers = a.CarNumbers,
//                CarImgUrl = "/Uploads/Cars/"+a.CarImgUrl,
//                licenseImgUrl = "/Uploads/Cars/"+a.licenseImgUrl,
//                InsurancesImgUrl = "/Uploads/Cars/" + a.InsurancesImgUrl,
//            });

//            return data;

//        }

//        public IEnumerable<CarsVM> GetByDate(int yer, int month, int day)
//        {
//            var data = db.Cars.Where(a => a.MaintenanceTime.Year == yer && a.MaintenanceTime.Month == month && a.MaintenanceTime.Day == day)
//                .Select(a => new CarsVM
//                {

//                    Id = a.Id,
//                    CarModel = a.CarModel,
//                    MaintenanceTime = a.MaintenanceTime,
//                    CarNumbers = a.CarNumbers,
//                });
//            return data;

//        }
//        public interface ICarApiRep
//    {
//        IEnumerable<CarsVM> GetAll();
//        IEnumerable<CarsVM> GetByDate(int yer , int month , int day);


//}
//    }
//}