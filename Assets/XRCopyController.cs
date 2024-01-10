using UnityEngine;

public class XRCopyController : MonoBehaviour
{
    [SerializeField] private GameObject headset;

    [SerializeField] private GameObject leftcontroller;

    [SerializeField] private GameObject rightcontroller;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(0, headset.transform.position.y, 0);
        transform.GetChild(0).transform.localPosition = leftcontroller.transform.position - headset.transform.position;
        transform.GetChild(1).transform.localPosition = rightcontroller.transform.position - headset.transform.position;
    }
}