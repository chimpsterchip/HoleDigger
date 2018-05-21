using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipRotation : MonoBehaviour {

    public void Flip()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 180);
    }
}
