using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float camHeightAboveTarget = 1;
    public float focusHeightAboveTarget = .5f;
    public float distanceFromTarget = 3;
    public float angle = 0;
    public float maxRotateDegPerSec = 90;
    public float lerpSpeed = .25f;
    private Vector3 currentWorldPos = Vector3.zero;

    public void Turn(float amount)
    {
        angle += (amount*maxRotateDegPerSec) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
            return;
        
        Vector2 flat = DegreeToVector2(angle);
        Vector3 offset = new Vector3(flat.x * -distanceFromTarget, camHeightAboveTarget, flat.y * -distanceFromTarget);
        currentWorldPos = Vector3.Lerp(currentWorldPos, target.position + offset, lerpSpeed);
        transform.position = target.position + offset;
        transform.LookAt(target.position + Vector3.up * focusHeightAboveTarget);
    }

    public Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
    
    public Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }



}
