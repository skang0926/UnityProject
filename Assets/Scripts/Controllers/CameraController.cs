using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;

    void Start()
    {
    }

    void LateUpdate()
    {
        if (Target == null)
            return;

        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y + 2, -10);
    }
}
