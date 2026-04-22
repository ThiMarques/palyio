using Palyio.Domain.Enum;

namespace Palyio.Domain.Entities
{
    public record class User : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }

        public User(string name,
                    DateTime birthDate,
                    EGender gender)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
        }
    }
}