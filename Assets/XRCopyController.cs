using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRCopyController : MonoBehaviour
{

    [SerializeField]
    private GameObject headset;
    [SerializeField]
    private GameObject leftcontroller;
    [SerializeField]
    private GameObject rightcontroller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.GetChild(0).transform.localPosition = leftcontroller.transform.position - headset.transform.position;
        transform.GetChild(1).transform.localPosition = rightcontroller.transform.position - headset.transform.position;
    }
}
