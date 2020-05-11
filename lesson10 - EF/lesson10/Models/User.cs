using System.ComponentModel.DataAnnotations;
namespace lesson10.Models
{
    class User
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)] 
        public string Surname { get; set; }
        [Range(1, 100)]
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name {Name} Surname {Surname} Age {Age}";
        }
    }
}
