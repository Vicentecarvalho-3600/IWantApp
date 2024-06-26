using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }
    public Category(string name, string createdBy, string editedBy)
    {
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(name, "Name", "Nome é obrigatório")
            .IsGreaterOrEqualsThan(name, 3, "Name", "O Nome precisa ter 3 ou mais caracteres")
            .IsNotNullOrEmpty(createdBy, "CreatedBy", "CreateBy é obrigatório")
            .IsNotNullOrEmpty(editedBy, "EditedBy", "EditedBy é obrigatório");
        AddNotifications(contract);

        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;
    }
}
