namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

public class Category
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Default constructor
    public Category()
    {
        Name = "";
        Description = "";
    }

    // Parameterized constructor
    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"Category: {Name} - {Description}";
    }
}
