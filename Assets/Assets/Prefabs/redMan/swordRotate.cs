using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordRotate : MonoBehaviour
{
    [SerializeField] private float  rotateSpeed=5.0f;
    [SerializeField] private float rotationSpeed=100.0f;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject sword_cut;
    [SerializeField] private float radius=5.0f;
    [SerializeField] private Transform player;
    private float timeBtwHit;
    [SerializeField] private float TimeBtwHit=0.5f;
    [SerializeField] private float TimeBtwswordSkill=2.0f;
    private float timeBtwswordSkill;
    [SerializeField] private Animator animator;
    private bool isSwordSkillOnCooldown=false;
    private bool timeBombCooldown=false;

    private bool isPerformingSkill = false ;
    [SerializeField] private GameObject bombPrefabs;
    [SerializeField] private float timeReloadBomb=7.0f;
    public static swordRotate Instane;
    private enum State{idle,hit}
    private State state=State.idle;

    private float angle = 0f;

    public static swordRotate Instance;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        sword.SetActive(false);
    }
    private void Update()
    {
        timeBtwHit-=Time.deltaTime;
        sword_Click();
        applyState(); 
    }

    private void sword_Click()
    {     
        if(Input.GetMouseButton(0) && !isPerformingSkill) 
        {
            sword.SetActive(false);
            sword_cut.SetActive(true);
            timeBtwHit = TimeBtwHit;
            state=State.hit;
        }
        else if(Input.GetKeyDown("1") && !isSwordSkillOnCooldown)
        {
            sword.SetActive(true);
            sword_cut.SetActive(false);
            StartCoroutine(sword_skill());
        }
        else if(Input.GetKeyDown("space") && !timeBombCooldown)
        {
           StartCoroutine(createBomb());
        }
        else
        {
            state=State.idle;
        }
    }
 
    private IEnumerator sword_skill()
    {   
        isPerformingSkill=true;
        isSwordSkillOnCooldown = true;
        if(sword.activeSelf)
        {
        
        float elapsedTime=0f;
        while(elapsedTime <5f)
        {
            float x=Mathf.Sin( angle)*radius;
            float y=Mathf.Cos( angle)*radius;
            sword.transform.position=player.position+new Vector3(x,-y,0);
            angle+=rotateSpeed*Time.deltaTime;
            if(angle>360f)
            {
                angle-=360f;
            }
            Vector3 currentRotation = sword.transform.localEulerAngles;

            currentRotation.z += rotationSpeed * Time.deltaTime;

            sword.transform.localEulerAngles = currentRotation;
            elapsedTime+=Time.deltaTime;
            yield return null;
        }
        }
        sword.SetActive(false);
        sword_cut.SetActive(true);
        isPerformingSkill=false;
        yield return new WaitForSeconds(TimeBtwswordSkill);
        isSwordSkillOnCooldown = false;

    }
    private IEnumerator createBomb()
    {
        timeBombCooldown = true;
        Instantiate(bombPrefabs,player.position,Quaternion.identity);
        yield return new WaitForSeconds(timeReloadBomb);
        timeBombCooldown = false;
    }
    private void applyState()
    {
        animator.SetInteger("state",(int)state);
    }
}
