using System.ComponentModel.DataAnnotations.Schema;
using Tamkeen.Domain.Entities.Base;

namespace Tamkeen.Domain.Entities
{
    public class ProgramPost:BaseEntity
    {
        
        public int? programId {  get; set; }
        public TrainingProgram trainingProgram { get; set; }

        
       
        public ICollection<Application> application { get; set; }
    }
}
