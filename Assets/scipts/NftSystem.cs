using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NftSystem : MonoBehaviour
{
    int nftCount= 0 ;
    [SerializeField]TextMeshProUGUI nftCountText;

    private void Start()
    {
        nftCountText.text = nftCount.ToString();
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dsd");
        if (other.tag == "nft") {
            Destroy(other.gameObject);
            nftCount++;
            nftCountText.text = nftCount.ToString();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("dsd");
        if (collision.gameObject.tag == "nft")
        {
            Destroy(collision.gameObject);
            nftCount++;
            nftCountText.text = nftCount.ToString();
        }
    }
}
