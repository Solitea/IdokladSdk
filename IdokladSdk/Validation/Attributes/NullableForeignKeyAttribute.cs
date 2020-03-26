namespace IdokladSdk.Validation.Attributes
{
    internal class NullableForeignKeyAttribute : CannotEqualAttribute
    {
        public NullableForeignKeyAttribute()
            : base(default(int))
        {
        }
    }
}
