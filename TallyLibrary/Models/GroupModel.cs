namespace TallyLibrary.Models;

public class GroupModel
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int Under { get; set; }
	public int? NatureOfGroup { get; set; }
	public int? AffectGrossProfit { get; set; }
	public int BehavesSubLedger { get; set; }
	public int NetBalances { get; set; }
	public int UsedForCalculation { get; set; }
	public int MethodToAllocate { get; set; }
}

public class NatureOfGroupModel
{
	public int Id { get; set; }
	public string Name { get; set; }
}

public class MethodToAllocateModel
{
	public int Id { get; set; }
	public string Name { get; set; }
}