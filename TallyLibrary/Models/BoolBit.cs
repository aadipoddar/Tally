namespace TallyLibrary.Models;

public class BoolBit
{
	public string Value { get; }

	public int Bit { get; set; }

	public BoolBit(int bitValue)
	{
		Bit = bitValue;
		Value = bitValue == 1 ? "Yes" : "No";
	}
}
