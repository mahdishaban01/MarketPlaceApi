namespace Framework.Base.ValueObjects;

public abstract record BaseRecordValueObject
{
	protected BaseRecordValueObject()
	{
		Validate();
	}

	protected abstract void Validate();
}
