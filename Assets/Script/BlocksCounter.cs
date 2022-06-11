using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocksCounter : MonoBehaviour
{
    [SerializeField] Text blockCounter;
    void Start()
    {

    }

    void Update()
    {
        int blockCount = transform.childCount;
        if (blockCount > 1) blockCounter.text = blockCount + " blocks left";
        else blockCounter.text = blockCount + " block left";
    }
}
