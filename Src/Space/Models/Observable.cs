namespace Space.Models;

public sealed class Observable<T> where T : class?
{
    private T mValue;

    public event Action<Observable<T>>? Changed;

    public Observable(T value)
    {
        mValue = value;
    }

    public T Value
    {
        get => mValue;
        set
        {
            if (value is null == mValue is null && (value is null || value.Equals(mValue)))
            {
                return;
            }

            mValue = value!;

            this.Changed?.Invoke(this);
        }
    }
}
