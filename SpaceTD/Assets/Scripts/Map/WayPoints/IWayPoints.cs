using UnityEngine;

namespace Map
{
    interface IWayPoints
    {
        Transform GetWayPoint(int roadIndex, int wayPointIndex);
        bool HasReachedToFinish(int roadIndex, int wayPointIndex);
    }
}
