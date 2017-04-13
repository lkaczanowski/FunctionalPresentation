<Query Kind="Expression" />

[Serializable]
public sealed class Document :
		IEquatable<Document>,
		IStructuralEquatable,
		IComparable<Document>,
		IComparable,
		IStructuralComparable
{

	public string Data { get; internal set; }

	public int Number { get; internal set; }

	public Document(string Data, int Number)
	{
		this.Data = Data;
		this.Number = Number;
	}

	public int GetHashCode(IEqualityComparer comp)
	{
		var num = 0;
		const int offset = -1640531527;
		num = offset + (this.Number + ((num << 6) + (num >> 2)));
		var Data = this.Data;
		return offset + (((Data == null) ? 0 : Data.GetHashCode()) + ((num << 6) + (num >> 2)));
	}

	public override int GetHashCode()
	{
		return this.GetHashCode(LanguagePrimitives.GenericEqualityComparer);
	}

	public bool Equals(Document obj)
	{
		return obj != null
					 && string.Equals(this.Data, obj.Data)
					 && this.Number == obj.Number;
	}

	public override bool Equals(object obj)
	{
		var Document = obj as Document;
		return Document != null && this.Equals(Document);
	}

	public bool Equals(object obj, IEqualityComparer comp)
	{
		// ignore the IEqualityComparer as a simplification -- the generated F# code is more complex
		return Equals(obj);
	}

	public int CompareTo(Document obj)
	{
		if (obj == null)
		{
			return 1;
		}

		int num = string.CompareOrdinal(this.Data, obj.Data);
		if (num != 0)
		{
			return num;
		}

		return this.Number.CompareTo(obj.Number);
	}

	public int CompareTo(object obj)
	{
		return this.CompareTo((Document)obj);
	}

	public int CompareTo(object obj, IComparer comp)
	{
		// ignore the IComparer as a simplification -- the generated F# code is more complex
		return this.CompareTo((Document)obj);
	}

}