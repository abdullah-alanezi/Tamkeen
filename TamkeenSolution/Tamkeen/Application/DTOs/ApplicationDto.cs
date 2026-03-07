namespace Tamkeen.Application.DTOs
{
    public class ApplicationDto
    {
        public int Id { get; set; } // من BaseEntity
        public string FullName { get; set; }
        public string Email { get; set; }
        public string University { get; set; }
        public string Major { get; set; }
        public string CVPath { get; set; }
        public int ProgramPostId { get; set; }
        public string ProgramPostName { get; set; } // اسم البرنامج فقط، بدلاً من إرسال كل الكائن
        public string Status { get; set; } // نرسل enum كـ string
    }
}
