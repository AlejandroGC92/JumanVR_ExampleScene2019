using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumanSystem : MonoBehaviour
{
    public CapsuleCollider collider;
    public Transform centerHeadTracker;

    public Transform reorientOVR;
    public Transform smoothOVR;
    public Transform OVRSystem;

    public float walkSpeed = 2f;

    public float yPosition;

    public float smoothnessStep = 1;

    public bool floorCheck = true;

    public float fallingImpactRecovery = 0.75f;

    public float lastYVelocity;

    public bool wasFloorChecked = true;

    private void FixedUpdate()
    {
        //Forma del Collider
        collider.height = centerHeadTracker.localPosition.y;
        collider.center = new Vector3(centerHeadTracker.localPosition.x, centerHeadTracker.localPosition.y / 2, centerHeadTracker.localPosition.z);

        //Movimiento del jugador
        reorientOVR.position += new Vector3(centerHeadTracker.localPosition.x, 0, centerHeadTracker.localPosition.z) * walkSpeed * Time.fixedDeltaTime;

        //Comprobar el suelo
        RaycastHit floorInfo;
        if(Physics.Raycast(new Vector3(centerHeadTracker.position.x, reorientOVR.position.y + 0.1f, centerHeadTracker.position.z), -transform.up, out floorInfo, 0.15f))
        {
            floorCheck = true;
            Debug.DrawLine(new Vector3(centerHeadTracker.position.x, reorientOVR.position.y + 0.1f, centerHeadTracker.position.z), floorInfo.point, Color.yellow);
        }
        else floorCheck = false;

        //Smooths en funcion del suelo
        if(floorCheck)
        {
            smoothOVR.position = Vector3.Lerp(OVRSystem.transform.position, reorientOVR.position, Time.fixedDeltaTime * smoothnessStep);
        }

        if(floorCheck == true && wasFloorChecked == false)
        {
            smoothOVR.position += new Vector3(0, lastYVelocity * fallingImpactRecovery, 0);
        }


        //Aplicar posicion al jugador
        OVRSystem.position = new Vector3(reorientOVR.position.x, smoothOVR.position.y, reorientOVR.position.z);

        //Actualizar info
        wasFloorChecked = floorCheck;
        lastYVelocity = GetComponent<Rigidbody>().velocity.y;
    }
}
