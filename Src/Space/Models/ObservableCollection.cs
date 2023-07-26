namespace Space.Models;

using System;
using System.Linq;

public sealed class ObservableCollection<T> where T : class, IEquatable<T>
{
    private readonly List<Observable<T>> mValues;
    private readonly Func<T, string> mKeySelector;

    public event Action<ObservableCollection<T>>? Changed;

    public ObservableCollection(T[] values, Func<T, string> keySelector)
    {
        mValues = values.Select(v => new Observable<T>(v)).ToList();
        mKeySelector = keySelector;
    }

    public IReadOnlyCollection<Observable<T>> Values => mValues;

    public bool SetValues(T[] values)
    {
        var oldValues = mValues.Select(o => o.Value).ToArray();
        if (values.SequenceEqual(oldValues))
        {
            return false;
        }

        var observablesByKey = mValues.ToDictionary(o => mKeySelector(o.Value));

        mValues.Clear();
        foreach (var value in values)
        {
            if (observablesByKey.TryGetValue(mKeySelector(value), out var observable))
            {
                observable.Value = value;
            }
            else
            {
                observable = new Observable<T>(value);

                // Controversial, but this is for UI and everything re-renders when a single thing does
                observable.Changed += _ => this.Changed?.Invoke(this);
            }

            mValues.Add(observable);
        }

        this.Changed?.Invoke(this);

        return true;
    }
}
