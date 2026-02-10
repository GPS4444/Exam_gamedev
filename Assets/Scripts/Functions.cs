using UnityEngine;

public class Functions
{
    public static Vector3 PointToVector(Vector3 target, Vector3 pos)
    {
        Vector3 toTarget = (target - pos).normalized;

        return toTarget;
    }
    
    public static float VectorToAngle(Vector3 vector)
    {
        float angle = Mathf.Atan(vector.x / vector.z) * Mathf.Rad2Deg;

        //fix rotation (seems like a porcheria)
        if (vector.z < 0)
        {
            if (vector.x < 0)
            {
                angle += 180;
            }
            else
            {
                angle -= 180;
            }
        }
        return angle;
    }
}
