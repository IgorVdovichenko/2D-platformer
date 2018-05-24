using UnityEngine;

public class GroundedChecker : ICheckIfGrounded
{
    GameObject objectToCheck;
    string groundLayerMaskName;
    float distanceToGround = 0.01f;

    public GroundedChecker(GameObject obj, string groundLayerMaskName)
    {
        objectToCheck = obj;
        this.groundLayerMaskName = groundLayerMaskName;
    }

    public bool IsGrounded()
    {
        LayerMask layerMask = LayerMask.GetMask(groundLayerMaskName);
        RaycastHit2D hit =
            Physics2D.Raycast(objectToCheck.transform.position, Vector2.down, distanceToGround, layerMask);

        if (hit.collider != null)
            return true;
        else
            return false;

    }
}
