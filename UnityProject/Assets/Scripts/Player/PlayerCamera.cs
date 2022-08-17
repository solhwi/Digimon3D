using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;

public class PlayerCamera : MonoBehaviour
{
    public Camera cam;

    public Transform camArmTr = null;
    public Transform CamArmTr
    {
        get { return camArmTr; }
    }

    private Transform camTr = null;
    public Transform CamTr
    {
        get { return camTr; }
    }

    public Vector3 CamPos
    {
        get { return camTr.position; }
    }

    public Vector3 ArmAngle
    {
        get { return camArmTr.rotation.eulerAngles; }
        set { camArmTr.rotation = Quaternion.Euler(value); }
    }

    public Quaternion CamArmRotation
    {
        get
        {
            return camArmTr.rotation;
        }
        set
        {
            camArmTr.rotation = value;
        }
    }

    public Vector3 CamRayVec
    {
        get { return FireRay(); }
    }

    public Transform target;

    public void Init(Transform parent, Transform target)
    {
        // Player Camera
        transform.SetParent(parent);

        // Camera Arm
        GameObject g = new GameObject("Camera Arm");

        camArmTr = g.transform;
        camArmTr.SetParent(transform);

        // Camera
        g = new GameObject("Camera");
        cam = g.AddComponent<Camera>();

        camTr = cam.transform;
        camTr.SetParent(camArmTr);

        // Target
        this.target = target;

        Vector3 lookingPos = new Vector3(0, 1.5f, 0);
        Vector3 cameraPos = new Vector3(0, 1.1f, -6.6f);

        camArmTr.localPosition = lookingPos;
        camTr.localPosition = target.transform.position + cameraPos;
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

        if (SDPhysics.Raycast(CamPos, ray.direction, out obj, 30.0f, ENUM_LAYER_TYPE.Environment, ENUM_TAG_TYPE.Interactable))
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
