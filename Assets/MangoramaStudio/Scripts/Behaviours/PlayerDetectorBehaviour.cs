using MangoramaStudio.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetectorBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Range" && gameObject.tag == "Player")
        {
            Debug.Log("Range is: " + PlayerData.Range);
        }
        else if(other.tag == "FireRate" && gameObject.tag == "Player")
        {
            Debug.Log("Fire rate is: " + PlayerData.FireRate);
        }
    }
}
