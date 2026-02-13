using System.Xml.Linq;
using Tamkeen.Domain.Entities.Base;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Domain.Entities
{
    public class Document : BaseEntity
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public DocumentType Type { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
