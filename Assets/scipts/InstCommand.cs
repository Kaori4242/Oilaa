using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstCommand : MonoBehaviour
{
   [SerializeField] GameObject insOb, contentParent ;

    [SerializeField] Animator EmerText;
    public bool isLimitLevel = false;
    public int LimitCount = 0;
    
    private void Start()
    {
        
    }
    public void createOb() {

        if (!isLimitLevel)
        {
            if (this.gameObject.tag == "loop" && contentParent.transform.childCount == 0)
            {

            }
            else {
                Instantiate(insOb, contentParent.transform);
            }
            
        }
        else {
            if (contentParent.transform.childCount < LimitCount)
            {
                if (this.gameObject.tag == "loop" && contentParent.transform.childCount == 0)
                {

                }
                else
                {
                    Instantiate(insOb, contentParent.transform);
                }
            }
            else {
                EmerText.SetTrigger("Emer");
            }
        }

    }

 

}
