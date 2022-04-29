using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private PatrolPath patrolPath = null;
    [SerializeField] private float wayPointDistance = 1f;
    [SerializeField] private float dwellingTime = 3f;

    private Mover mover;
    private Vector3 guardPosition;
    private int currentPatrolWaypoint = 0;
    private float timeSinceArrivedAtWaypoint = Mathf.Infinity;

    private void Start() {
        guardPosition = transform.position;
        mover = GetComponent<Mover>();
    }

    private void Update() {
        PatrolBehaviour();

        timeSinceArrivedAtWaypoint += Time.deltaTime;
    }

    private void PatrolBehaviour() {
        Vector3 nextPosition = guardPosition;
        
        if(patrolPath != null) {
            if(AtWayPoint()) {
                timeSinceArrivedAtWaypoint = 0;
                CycleWaypoint();
            }

            nextPosition = GetCurrentWaypoint();
        }
        
        if(timeSinceArrivedAtWaypoint > dwellingTime) {
            mover.MoveTo(nextPosition);
        }
    }

    private bool AtWayPoint() {
        float distanceToWayPoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
        return distanceToWayPoint < wayPointDistance;
    }

    private void CycleWaypoint() {
        currentPatrolWaypoint = patrolPath.GetNextIndex(currentPatrolWaypoint);
    }

    private Vector3 GetCurrentWaypoint() {
        return patrolPath.GetTransformChild(currentPatrolWaypoint);
    }
}
