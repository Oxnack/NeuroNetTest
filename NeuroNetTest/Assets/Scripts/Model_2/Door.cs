using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;

    private void Update()
    {
        if (open)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
