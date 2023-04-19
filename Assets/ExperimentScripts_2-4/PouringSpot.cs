using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringSpot : MonoBehaviour
{
    [Tooltip("The pouring particle system, so this script can move it to the correct position.")]
    public Transform pouredLiquid;
    [Tooltip("The radius of the pouring range, make sure gizmos is enabled and try to make that white sphere touches the edges of the beaker or bottle it's pouring from. Red sphere is the pouring position based on rotation.")]
    public float radius;
    private float r;

    [Header("Debugging Info")]
    public Vector3 newPos;
    public Vector2 newValues;
    public float x, z;
    // For further testing
    private float xConv, zConv;
    public Vector3 dir;

    private void Update()
    {
        if (!transform.parent)
            return;
        x = transform.parent.localEulerAngles.x / 360;
        z = transform.parent.localEulerAngles.z / 360;

        if (x > 0.5f)
            x = -1;
        else if (x < 0.5 && x > 0.1f)
            x = 1;
        else
            x = 0;

        if (z > 0.5f)
            z = 1;
        else if (z < 0.5 && z > 0.1f)
            z = -1;
        else
            z = 0;

        //x = -math.remap(0, 1, -1, 1, x);
        //z = math.remap(0, 1, -1, 1, z);
        // Testing the new values
        newValues.x = Vector3.Dot(transform.forward, Vector3.down);
        newValues.y = Vector3.Dot(transform.right, Vector3.down);

        if (newValues.x > 0.15f)
            xConv = Mathf.Ceil(newValues.x);
        else if (newValues.x < -0.15f)
            xConv = Mathf.Floor(newValues.x);
        else
            xConv = 0;

        if (newValues.y > 0.15f)
            zConv = Mathf.Ceil(newValues.y);
        else if (newValues.x < -0.15f)
            zConv = Mathf.Floor(newValues.y);
        else
            zConv = 0;

        r = radius / 100;

        dir = new Vector3(z, 0, x).normalized;

        newPos = transform.position + transform.TransformDirection(dir * r);
        //newPos = transform.position + transform.TransformDirection(new Vector3(zConv, 0, xConv) * r);
        pouredLiquid.position = newPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, r);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(newPos, r / 10);
    }
}
