using UnityEngine;

namespace Monsters
{
    public class BaseMonsterMovement : MonoBehaviour, IMonsterMovement
    {
        public float Speed { get { return speed; } }

        [Header("General Attributes")]
        public float speed;

        private Transform target;
        private int wayPointIndex = 0;

        private const float wayPointTolerance = 0.2f;

        void Start()
        {
            target = Map.WayPoints.SharedInstance.GetWayPoint(wayPointIndex);
        }

        void Update()
        {
            Move();
        }

        public void Move()
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= wayPointTolerance)
            {
                GetNextWayPoint();
            }
        }

        void GetNextWayPoint()
        {
            if (Map.WayPoints.SharedInstance.HasReachedToFinish(wayPointIndex))
            {
                PathEnded();
                return;
            }

            wayPointIndex++;
            target = Map.WayPoints.SharedInstance.GetWayPoint(wayPointIndex);
        }

        void PathEnded()
        {
            Destroy(gameObject);
        }
    }
}