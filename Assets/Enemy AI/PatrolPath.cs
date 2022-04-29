using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    [SerializeField] private float wayPointGizomsRadius = 2f;

    private void OnDrawGizmos() {
        for(int i = 0; i < transform.childCount; i++) {
            int j = GetNextIndex(i);
            GizmosColor();
            Gizmos.DrawSphere(GetTransformChild(i), wayPointGizomsRadius);
            Gizmos.DrawLine(GetTransformChild(i), GetTransformChild(j));
        }
    }

    private void GizmosColor() {
        Gizmos.color = Color.black;
    }

    public int GetNextIndex(int i) {
        return (i + 1) % transform.childCount;
    }

    public Vector3 GetTransformChild(int i) {
        return transform.GetChild(i).position;
    }
}
