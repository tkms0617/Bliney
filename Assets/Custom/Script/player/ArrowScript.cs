using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform playerCamera;
    [SerializeField] GameObject arrow;

    void Update()
    {
        // ?????????????????
        Vector3 cameraPosition = playerCamera.position;
        Vector3 cameraForward = playerCamera.forward;

        // ????????????????????
        transform.position = cameraPosition;

        // ?????????????????????
        Vector3 targetDirection = (target.position - cameraPosition).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        arrow.transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
    }
}
