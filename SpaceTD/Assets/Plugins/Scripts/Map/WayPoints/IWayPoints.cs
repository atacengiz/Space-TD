using UnityEngine;

namespace Map
{
    interface IWayPoints
    {
        Transform GetWayPoint(int index);
        bool HasReachedToFinish(int index);
    }
}
