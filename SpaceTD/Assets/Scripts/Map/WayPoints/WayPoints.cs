
using UnityEngine;

namespace Map
{

    public class WayPoints : MonoBehaviour, IWayPoints
    {
        public static WayPoints SharedInstance;

        private Rode[] rodes;

        void Awake()
        {
            if (SharedInstance != null)
            {
                Debug.LogError("World is too small for two WayPointsHandler");
                return;
            }

            SharedInstance = this;
            CreateRodes();
        }

        private void CreateRodes()
        {
            for (int roadIndex = 0; roadIndex < transform.childCount; roadIndex++)
            {
                Rode rode = new Rode();
                rode.rodeIndex = roadIndex;

                Transform childTransform = transform.GetChild(roadIndex);
                for (int wayPointIndex = 0; wayPointIndex < childTransform.childCount; wayPointIndex++)
                {
                    rode.wayPoints[wayPointIndex] = childTransform.GetChild(wayPointIndex);
                }

                rodes[roadIndex] = rode;
            }
        }

        public Transform GetWayPoint(int roadIndex, int wayPointIndex)
        {
            return rodes[roadIndex].wayPoints[wayPointIndex];
        }

        public bool HasReachedToFinish(int roadIndex, int wayPointIndex)
        {
            return wayPointIndex >= rodes[roadIndex].wayPoints.Length - 1 ? true : false;
        }
    }
}