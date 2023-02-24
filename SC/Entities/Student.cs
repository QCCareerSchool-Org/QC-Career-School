namespace SC.Entities;

public class Student
{
    public int Id { get; set; }

    public uint ProvinceId { get; set; }

    public uint CountryId { get; set; }

    public Province Province { get; set; }

    public Country Country { get; set; }
}
