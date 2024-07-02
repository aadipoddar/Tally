namespace TallyLibrary.Models;

public class CompanyModel
{
	public string Name { get; set; }
	public string MailingName { get; set; }
	public string Address { get; set; }
	public string State { get; set; }
	public int PinCode { get; set; }
	public string TelephoneNumber { get; set; }
	public string EMail { get; set; }
	public DateTime FinancialYearFrom { get; set; }
	public DateTime BooksBeginFrom { get; set; }
    public string Password { get; set; }
}
