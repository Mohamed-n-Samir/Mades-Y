using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEffectDestroyier : MonoBehaviour
{
    // Start is called before the first frame update
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
