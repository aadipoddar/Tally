namespace TallyLibrary.Models;

public class CompanyModel
{
	public string Name { get; set; }
	public string MailingName { get; set; }
	public string Address { get; set; }
	public string State { get; set; }
	public int PinCode { get; set; }
	public long TelephoneNumber { get; set; }
	public string EMail { get; set; }
	public DateOnly FinancialYearFrom { get; set; }
	public DateOnly BooksBeginFrom { get; set; }
    public string Password { get; set; }
}
