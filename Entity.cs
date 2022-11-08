using System.ComponentModel.DataAnnotations;

namespace RepositoryDB
{
    public class Entity
    {
        [Key]
        public uint Id { get; set; }
    }
}
