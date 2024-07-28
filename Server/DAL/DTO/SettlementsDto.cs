using System.ComponentModel.DataAnnotations;

namespace DAL.DTO
{
    public class SettlementsDto
    {
        [Required]
        public string Name { get; set; }
        // שדות נוספים
    }
}


//using System.ComponentModel.DataAnnotations;

//namespace DAL.DTO
//{
//    public class SettlementsDto
//    {
//        public int Id { get; set; }

//        [Required]
//        public string Name { get; set; }
//        // שדות נוספים
//    }
//}
