using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class systemMove : MonoBehaviour
{
    [SerializeField] float speed, realSpeed = 5,  stepTime , rotationSpeed = 10f;
    [SerializeField] Rigidbody rb;
    [SerializeField] Button buttonPlay;
    public Coroutine j;
    Vector3 initPlayerPos = new Vector3(-0.5000122f , 1.267421f , -4.859787f);
    Quaternion   initPlayerRot ;
    [HideInInspector]public bool isFinished = false;
    [HideInInspector] public bool Success = false;
    bool isWorking = true;
    Coroutine d,c;


    public bool isLimit = false;
    public int MaxElem = 10;
    public Animator emerText;
    Animator robotAnim;
    private void Start()
    {
        robotAnim = rb.GetComponent<Animator>();
        initPlayerRot = rb.rotation;
    }
    private void Update()
    {
        
    }
    public void onCollect() {
        if (isLimit)
        {
            if (this.transform.childCount < MaxElem)
            {
                c = StartCoroutine(onCollectCor());
            }
            else
            {
                emerText.SetTrigger("Emer");
            }
        }
        else {
            c = StartCoroutine(onCollectCor());
        }
        
        
    }
    public void LoopIsShit()
    {

    }
    IEnumerator onCollectCor() {
        
        
        buttonPlay.interactable = false;
        isWorking = true;
        Restart:
        foreach (Transform blocks in transform)
        {
            if (!isWorking) {
                break;            
            }
            isFinished = false;
            if (blocks.tag == "Forward" && isWorking)
            {
               d=  StartCoroutine(Forward());
                
            }
            else if (blocks.tag == "back" && isWorking) {
                d = StartCoroutine(Back());
                
            }
            else if (blocks.tag == "left" && isWorking)
            {
                d= StartCoroutine(Left());
                yield return new WaitForSeconds(0.5f);
            }
            else if (blocks.tag == "right" && isWorking)
            {
                d = StartCoroutine (Right());
                yield return new WaitForSeconds(0.5f);
            }
            else if (blocks.tag == "jump" && isWorking)
            {
                d = StartCoroutine(Jump());
                yield return new WaitForSeconds(1f);

            }
            else if (blocks.tag == "up" && isWorking)
            {
                d = StartCoroutine(Up());
                yield return new WaitForSeconds(1f);

            }
            else if (blocks.tag == "loop" && isWorking)
            {
                if (!isFinished) {
                    goto Restart;
                }
                

            }



            yield return new WaitUntil(() => isFinished );
        }
        

        if (!Success) {
            yield return new WaitForSeconds(0.2f);
            rb.position = initPlayerPos;
            Quaternion trav = Quaternion.Euler(0, 0, 0);
            rb.transform.localRotation = trav;
            rb.useGravity = true;
        }
        buttonPlay.interactable = true;
    }

    IEnumerator Forward() {

        float aim = rb.transform.position.z + speed;
        float aiSm = rb.transform.position.x - speed;
        float aiSSm = rb.transform.position.x + speed;
        float aiSSSm = rb.transform.position.z - speed;
        Debug.Log(rb.transform.position.z+ " " + aim + " " + rb.transform.position.x + " " + aiSm);
        
        

        
        while (isWorking&& aim - rb.transform.position.z > 0.01f && aiSm - rb.transform.position.x < 0.01f && aiSSm - rb.transform.position.x > 0.01f &&  aiSSSm - rb.transform.position.z < 0.01f)
            {
            robotAnim.CrossFade("Walking" , 0);
            
            rb.transform.Translate(Vector3.forward * realSpeed);
            int layerMask = 1 << 7;
            

            Ray ray = new Ray(new Vector3(rb.position.x, rb.position.y - 0.5f, rb.position.z), rb.transform.forward);
                Debug.DrawRay(new Vector3(rb.position.x , rb.position.y - 0.5f , rb.position.z), rb.transform.forward, Color.green);
            RaycastHit hit;
            



            if (Physics.Raycast(ray, out hit , layerMask) ) {
                Debug.Log( hit.distance);
                if (hit.distance < 0.5f) {
                    Debug.Log("jhhih " + hit.collider.tag + " " + hit.distance);
                    break;
                }
                
            }
            
            yield return new WaitForSeconds(0.01f);
           // Debug.Log(rb.transform.position.z + " " + aim + " " + rb.transform.position.x + " " + aiSm);
        }

        robotAnim.CrossFade("Robot_Idle", 0.3f, 0);


        isFinished = true;
    }

    IEnumerator Back()
    {

        float aim = rb.transform.position.z + speed;
        float aiSm = rb.transform.position.x - speed;
        float aiSSm = rb.transform.position.x + speed;
        float aiSSSm = rb.transform.position.z - speed;
        Debug.Log(aim);
        while (isWorking && aim - rb.transform.position.z > 0.01f && aiSm - rb.transform.position.x < 0.01f && aiSSm - rb.transform.position.x > 0.01f && aiSSSm - rb.transform.position.z < 0.01f)
        {
            robotAnim.CrossFade("Walking", 0);
            rb.transform.Translate(Vector3.back * realSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        robotAnim.CrossFade("Robot_Idle", 0.3f, 0);
        isFinished = true;
    }
    IEnumerator Left()
    {
        float initRot = rotationSpeed;
        float aim = rb.transform.localEulerAngles.y   - 90;
        Quaternion trav = Quaternion.Euler(0, aim, 0);
        //Debug.Log(aim + " \\" + trav.eulerAngles.y + " \\" + rb.transform.rotation.y + " \\ " + trav.normalized.y + " \\ " + trav.y);

       /* while (isWorking && rb.transform.eulerAngles.y != trav.eulerAngles.y )
        {
            //Debug.Log(rb.transform.rotation.y + "  " + trav.normalized.y);
            robotAnim.CrossFade("Walking", 0);
           

            rotationSpeed += 0.2f;




           
        }*/
        if (isWorking) {
            robotAnim.CrossFade("Walking", 0);
            rb.transform.localRotation = Quaternion.Lerp(rb.transform.localRotation, trav, 1);
        }
        yield return new WaitForSeconds(0.01f);
        robotAnim.CrossFade("Robot_Idle", 0.3f, 0);
        Debug.Log("END");
        rotationSpeed = initRot;
       
        isFinished = true;
        
    }
    IEnumerator Right()
    {
        float initRot = rotationSpeed;
        float aim = rb.transform.localEulerAngles.y + 90;
        Quaternion trav = Quaternion.Euler(0, aim, 0);
        // Debug.Log(aim + " \\" + trav.eulerAngles.y + " \\" + rb.transform.rotation.y + " \\ " + trav.normalized.y + " \\ " + trav.y);

        /*while (isWorking && rb.transform.eulerAngles.y != trav.eulerAngles.y)
        {
            //Debug.Log(rb.transform.rotation.y + "  " + trav.normalized.y);
            robotAnim.CrossFade("Walking", 0);*/
       
            if (isWorking)
            {
                robotAnim.CrossFade("Walking", 0);
                rb.transform.localRotation = Quaternion.Lerp(rb.transform.localRotation, trav, 1);
            }
        
        
            
        //rotationSpeed += 0.2f;




        /*
            
        }*/
        yield return new WaitForSeconds(0.01f);
        rotationSpeed = initRot;
        robotAnim.CrossFade("Robot_Idle", 0.3f, 0);
        Debug.Log("END");
        rotationSpeed = initRot;
        new WaitForSeconds(5f);
        isFinished = true;
        
    }
    IEnumerator Jump()
    {
        rb.useGravity = false;
        float aim = rb.transform.position.y + 0.5f;
        robotAnim.CrossFade("Jumo", 0);

        Debug.Log(aim);
        while (isWorking && aim - rb.transform.position.y > 0.01f && rb.transform.position.y  >0.4f)
        {


            
            rb.transform.Translate(Vector3.up * realSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        
        rb.useGravity = true;
        StartCoroutine(Forward());
        robotAnim.CrossFade("Robot_Idle", 0.3f, 0);
        rb.useGravity = true;
        
    }

    public void ReloadScene() {

        isWorking = false;
      
        StopCoroutine(d);
        

        isFinished = true;
        buttonPlay.interactable = true;
        
        rb.useGravity = true;

    }
    public void DeleteAllPlatforms()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
    void Dance()
    {

    }

    void Nft()
    {

    }
    IEnumerator Up()
    {
        rb.useGravity = false;
        float aiam = rb.transform.position.y + 0.5f;
        robotAnim.CrossFade("Jumo", 0);
        Debug.Log(aiam);
        while (isWorking && aiam - rb.transform.position.y > 0.01f && rb.transform.position.y > 0.4f)
        {
            
            rb.transform.Translate(Vector3.up * realSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        robotAnim.CrossFade("Robot_Idle", 0.3f, 0);
        float aim = rb.transform.position.z + 2;
        float aiSm = rb.transform.position.x - 2;
        float aiSSm = rb.transform.position.x + 2;
        float aiSSSm = rb.transform.position.z - 2;
        Debug.Log(rb.transform.position.z + " " + aim + " " + rb.transform.position.x + " " + aiSm);



        while (isWorking && aim - rb.transform.position.z > 0.01f && aiSm - rb.transform.position.x < 0.01f && aiSSm - rb.transform.position.x > 0.01f && aiSSSm - rb.transform.position.z < 0.01f)
        {
            
            rb.transform.Translate(Vector3.forward * realSpeed);
            yield return new WaitForSeconds(0.001f);
            Debug.Log(rb.transform.position.z + " " + aim + " " + rb.transform.position.x + " " + aiSm);
        }



        robotAnim.CrossFade("Robot_Idle", 0.3f, 0);
        isFinished = true;
        rb.useGravity = true;
    }
    void Loop()
    {

    }

    
}
