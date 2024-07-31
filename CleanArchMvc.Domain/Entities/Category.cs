using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invlaid Id");
            Id = id;
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required!");
            DomainExceptionValidation.When(name.Length < 3, "Name cannot be less than 3 characters!");

            Name = name;
        }
    }
}
