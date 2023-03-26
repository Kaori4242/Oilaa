using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformKill : MonoBehaviour
{
    public void IamDie() {
        Destroy(this.gameObject);
    }
}
