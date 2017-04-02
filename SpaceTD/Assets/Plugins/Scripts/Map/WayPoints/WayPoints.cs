
using UnityEngine;

namespace Map
{
    public class WayPoints : MonoBehaviour, IWayPoints
    {
        public static WayPoints SharedInstance;
        private static Transform[] Points;
        void Awake()
        {
            if (SharedInstance == null)
                SharedInstance = this;

            Points = new Transform[transform.childCount];

            for (int i = 0; i < Points.Length; i++)
                Points[i] = transform.GetChild(i);
        }

        public Transform GetWayPoint(int index)
        {
            return Points[index];
        }

        public bool HasReachedToFinish(int index)
        {
            return index >= Points.Length - 1 ? true : false;
        }
    }
}