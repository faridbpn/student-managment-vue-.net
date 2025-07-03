namespace SimpleApi.Models
{
  public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string OriginAddress { get; set; } = string.Empty;
        public string AddressInSemarang { get; set; } = string.Empty;
        public string BirthPlace { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Religion { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string BloodType { get; set; } = string.Empty;
        public string PreviousSchool { get; set; } = string.Empty;
        public string HighSchoolMajor { get; set; } = string.Empty;
        public int GraduationYear { get; set; }
        public string SelectedDepartment { get; set; } = string.Empty;
        public string HomePhone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        public Parent? Parent { get; set; } = new(); 
    }

public class Parent
{
    public int Id { get; set; }
    public string FatherName { get; set; } = string.Empty;
    public string MotherName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}


   public class User
    {
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    public Student? Student { get; set; } 
    }

}
