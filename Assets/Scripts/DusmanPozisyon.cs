using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanPozisyon : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
