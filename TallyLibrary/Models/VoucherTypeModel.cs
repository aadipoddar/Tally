namespace TallyLibrary.Models;

public class VoucherTypeModel
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int TypeOfVoucher { get; set; }
    public int? MethodOfNumbering { get; set; }
    public int? PreventDuplicates { get; set; }
    public int UseEffectiveDates { get; set; }
    public int DefaultOptional { get; set; }
    public int CommonNarration { get; set; }
    public int NarrationEachEntry { get; set; }
}

public class MethodOfNumberingModel
{
	public string Value { get; }

	public int Bit { get; set; }

	public MethodOfNumberingModel(int bitValue)
	{
		Bit = bitValue;
		if (bitValue == 0)
			Value = "Automatic";
		else if (bitValue == 1)
			Value = "Manual";
		else
			Value = "None";
	}
}
