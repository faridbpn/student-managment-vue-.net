public class RegisterStudentDto
{
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
    public IFormFile Photo { get; set; } = default!;

    public string FatherName { get; set; } = string.Empty;
    public string MotherName { get; set; } = string.Empty;
    public string ParentAddress { get; set; } = string.Empty;
    public string ParentPhone { get; set; } = string.Empty;
}
