using System.Globalization;
using TMPro;
using UnityEngine;

namespace Recorder.Tools
{
    
    public class RenderLine : MonoBehaviour
    {
       [SerializeField] private TextMeshProUGUI Front;
        [SerializeField] TextMeshProUGUI Back;

        private void Start()
        {
            var rotation = 0;
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i).name == name)
                {
                    rotation = 10 * i;
                }
            }
            
            Front.text = $"{rotation.ToString(CultureInfo.CurrentCulture)}";
            Back.text = $"{(180 + rotation).ToString(CultureInfo.CurrentCulture)}";
        }
    }
}