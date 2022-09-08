using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

public class CameraController : MonoBehaviour
{
    private Camera cam;

    public Transform CamArmTr
    {
        get;
        private set;
    }

    public Transform CamTr
    {
        get;
        private set;
    }

    public Vector3 CamPos
    {
        get { return CamTr.position; }
    }

    public Vector3 ArmAngle
    {
        get { return CamArmTr.rotation.eulerAngles; }
        set { CamArmTr.rotation = Quaternion.Euler(value); }
    }

    public Transform target;

    public void Init(Transform parent, Transform target)
    {
        transform.SetParent(parent);
        this.target = target;

        InitantiateCamera();
        SetViewCamera();
    }

    private void InitantiateCamera()
	{
        // Camera Arm
        GameObject g = new GameObject("Camera Arm");

        CamArmTr = g.transform;
        CamArmTr.SetParent(transform);

        // Camera
        g = new GameObject("Camera");
        cam = g.AddComponent<Camera>();

        CamTr = cam.transform;
        CamTr.SetParent(CamArmTr);
    }

    private void SetViewCamera()
	{
        CamArmTr.localPosition = new Vector3(0, 40, 15);
        CamArmTr.Rotate(new Vector3(60, 180, 0));

    }

    protected virtual void LateUpdate()
    {
        FollowingCamera();
    }

    private void FollowingCamera()
    {
        transform.position = target.position;
    }

    private Vector3 FireRay()
    {
        Ray ray = ScreenPointToRay(InputMgr.MouseScreenPos);
        RaycastHit hit;

        if (SDPhysics.RaycastWithoutLayerType(CamPos, ray.direction * 30f, out hit, 30.0f, ENUM_LAYER_TYPE.Player))
            return hit.point;

        return ray.direction;
    }

    public CollisionObject GetForwardObjectWithRay(Vector2 mousePos)
    {
        Ray ray = ScreenPointToRay(mousePos);
       
        CollisionObject obj = null;

        if (SDPhysics.Raycast(CamPos, ray.direction, out obj, 30.0f, ENUM_LAYER_TYPE.Environment, ENUM_TAG_TYPE.Untagged))
            return obj;

        return null;
    }

    public Vector3 ScreenToWorldPoint(Vector3 inputPos)
    {
        if(cam != null)
            return cam.ScreenToWorldPoint(new Vector3(inputPos.x, inputPos.y, cam.nearClipPlane));

        return Vector3.zero;
    }

    public Ray ScreenPointToRay(Vector3 inputPos)
    {
        if (cam != null)
            return cam.ScreenPointToRay(inputPos);

        return new Ray();
    }
}
