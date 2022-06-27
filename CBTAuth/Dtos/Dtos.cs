using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CBTAuth.Dtos
{

    public class HallLoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
    public class HallLoginDto
    {
        public string Name { get; set; }
        public string FIR { get; set; }
    }
    public class StudentDto
    {
        public string Name { get; set; }
        public string FIR { get; set; }
        public string ImageURL { get; set; }
    }

    public class CourseDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }

    public class EnrollDto
    {
        public string MatNo { get; set; }
        public string CourseCode { get; set; }
        public string Pwd { get; set; }
        public string FIR { get; set; }
        public DateTime EnrollDate { get; set; }
    }

    public class EnrollFresherDto
    {
        public string Number { get; set; }  
        public string FIR { get; set; }
        public string Enroller { get; set; }
        public DateTime EnrollDate { get; set; }
    }

    public class GetStudentDto
    {
        [Required]
        public string MatNo { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public string hall { get; set; } = GlobalClass.HallName;
    }
    public class BiodataGetStudentDto
    {
        public string Name { get; set; }
        public string Utme { get; set; }
        public string ImageURL { get; set; }
    }
}
