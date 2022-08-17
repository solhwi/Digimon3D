using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDDefine;
using ServerLib;

public partial class PlayerCharacter
{
    protected NetworkEventListener<WaitingRoomCharTransSync_NT> transformSyncPacketListener =
        new NetworkEventListener<WaitingRoomCharTransSync_NT>();

    protected IMicroCoroutine reportingCoroutine = null;

    protected void RegisterReport()
    {
        transformSyncPacketListener.Bind(OnRecvTransSync_NT_Packet);
    }

    protected void StartReport()
    {
        if (reportingCoroutine != null)
            this.StopCoroutine(reportingCoroutine);

        reportingCoroutine = this.StartUpdateCoroutine(Reporting());
    }

    protected void StopReport()
    {
        if (reportingCoroutine != null)
            this.StopCoroutine(reportingCoroutine);
    }

    protected IEnumerator Reporting()
    {
        var wfs = new WaitForSeconds(1.0f / 18.0f);

        while (true)
        {
            yield return wfs;

            ReportPCTransform();
        }
    }

    private void ReportPCTransform()
    {
        if (activeCharacter == null)
            return;

        SDNetwork.ReportCharacterTransform(activeCharacter.Position, activeCharacter.RotationAngle);
    }

    protected void OnRecvTransSync_NT_Packet(WaitingRoomCharTransSync_NT packet)
    {
        if (packet == null)
            return;

        var infosDic = packet.TransformInfos;

        RoomCharacterTransformInfo transformInfo = null;

        if (infosDic.TryGetValue(playerId, out transformInfo))
        {
            if (transformInfo != null)
            {
                var pos = transformInfo.Position;
                var rot = transformInfo.Rotation;

                if (activeCharacter != null)
                    activeCharacter.ReplaceObject(new Vector3(pos.X, pos.Y, pos.Z), new Vector3(rot.X, rot.Y, rot.Z));
            }
        }
    }
}
