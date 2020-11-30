namespace IdokladSdk.Validation.Attributes
{
    public class NullableForeignKeyAttribute : CannotEqualAttribute
    {
        public NullableForeignKeyAttribute()
            : base(default(int))
        {
        }
    }
}
