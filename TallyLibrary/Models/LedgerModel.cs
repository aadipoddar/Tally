namespace TallyLibrary.Models;

public class LedgerModel
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int Under { get; set; }
	public int? InventoryAffected { get; set; }
	public int? MaintainBalances { get; set; }
	public int? DefaultCreditPeriod { get; set; }
	public DateTime? DateReconciliation { get; set; }
    public double? PercentageCalculation { get; set; }
    public int? MethodOfCalculation { get; set; }
}

public class MethodOfCalculationModel
{
	public int Id { get; set; }
	public string Name { get; set; }
}