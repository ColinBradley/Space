namespace Space.Components;

using Microsoft.AspNetCore.Components;
using Space.Models;
using SpaceTraders.Client;
using SpaceTraders.Model;

public class SpaceComponentBase : ComponentBase, IDisposable
{
    private SpaceApplication? mApplication;
    private bool mIsWatchingApplication;

    private bool mIsDisposed;

    [Inject]
    public SpaceApplication Application
    {
        get
        {
            if (!mIsWatchingApplication)
            {
                mIsWatchingApplication = true;
                mApplication!.Changed += this.Application_Changed;
            }

            return mApplication!;
        }
        set
        {
            mApplication = value;
            mApplication.SelectedShip.Changed += this.SelectedShip_Changed;
            mApplication.SelectedWaypoint.Changed += this.SelectedWaypoint_Changed;

            this.OnSelectedShipChanged(mApplication.SelectedShip.Value);
            this.OnSelectedWaypointChanged(mApplication.SelectedWaypoint.Value);
        }
    }

    private void SelectedWaypoint_Changed(Observable<Waypoint?> observable)
    {
        this.OnSelectedWaypointChanged(observable.Value);
    }

    private void SelectedShip_Changed(Observable<ShipModel?> observable)
    {
        this.OnSelectedShipChanged(observable.Value);
    }

    protected virtual void OnSelectedWaypointChanged(Waypoint? selectedWaypoint)
    {
    }

    protected virtual void OnSelectedShipChanged(ShipModel? selectedShip)
    {
    }

    public Configuration Configuration => mApplication!.Configuration;

    private void Application_Changed()
    {
        this.InvokeAsync(this.StateHasChanged);
    }

    protected virtual void DisposeCore()
    {
        if (mIsDisposed)
        {
            return;
        }

        mIsDisposed = true;

        if (mApplication is not null)
        {
            if (mIsWatchingApplication)
            {
                mApplication.Changed -= this.Application_Changed;
            }

            mApplication.SelectedShip.Changed -= this.SelectedShip_Changed;
            mApplication.SelectedWaypoint.Changed -= this.SelectedWaypoint_Changed;
        }
    }

    public void Dispose()
    {
        this.DisposeCore();
        GC.SuppressFinalize(this);
    }
}
