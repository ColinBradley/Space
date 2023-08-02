namespace Space.Models;

using SpaceTraders.Model;

public class ShipModel : IEquatable<ShipModel>
{
    private readonly Timer mUpdateTimer;

    private Ship mShip;
    private Cooldown? mCooldown;

    private bool mIsUpdateTimerActive = false;

    public event Action? Changed;

    public ShipModel(Ship ship)
    {
        mShip = ship;
        mUpdateTimer = new(_ =>
        {
            if (this.EnsureCooldownStillValid())
            {
                this.NotifyChanged();
            }
        });
    }

    public Ship Ship
    {
        get => mShip;
        set
        {
            if (mShip == value)
            {
                return;
            }

            mShip = value;
            this.NotifyChanged();
        }
    }

    public Cooldown? Cooldown
    {
        get
        {
            this.EnsureCooldownStillValid();
            return mCooldown;
        }
        set
        {
            mCooldown = value;

            this.UpdateTimerState();

            this.NotifyChanged();
        }
    }

    private bool EnsureCooldownStillValid()
    {
        if (mCooldown is null)
        {
            return true;
        }

        if (mCooldown.Expiration < DateTime.UtcNow)
        {
            mCooldown = null;

            this.UpdateTimerState();

            this.NotifyChanged();

            return false;
        }

        return true;
    }

    public TimeSpan? CooldownTimeLeft()
    {
        return this.Cooldown?.Expiration - DateTime.UtcNow;
    }

    public TimeSpan? ArrivalTimeLeft()
    {
        this.UpdateTimerState();

        if (this.Ship.Nav.Status == ShipNavStatus.INTRANSIT)
        {
            var result = this.Ship.Nav.Route.Arrival - DateTime.UtcNow;
            if (result >= TimeSpan.Zero)
            {
                return result;
            }

            this.Ship.Nav.Status = ShipNavStatus.INORBIT;
            this.NotifyChanged();
        }

        return null;
    }

    public void NotifyChanged()
    {
        this.Changed?.Invoke();
    }

    public bool Equals(ShipModel? other)
    {
        return other is not null && this.Ship.Equals(other.Ship);
    }

    public override bool Equals(object? obj)
    {
        return this.Equals(obj as ShipModel);
    }

    public override int GetHashCode()
    {
        return this.Ship.GetHashCode();
    }

    private void UpdateTimerState()
    {
        var shouldBeActive = mCooldown is not null || this.Ship.Nav.Status == ShipNavStatus.INTRANSIT;

        if (shouldBeActive == mIsUpdateTimerActive)
        {
            return;
        }

        if (shouldBeActive)
        {
            mUpdateTimer.Change(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }
        else
        {
            mUpdateTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
