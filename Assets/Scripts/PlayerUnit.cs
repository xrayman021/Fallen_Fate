using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public Tile2 location;
    public int range;
    public int attackRange;
    public bool canMove = true;
    public Vector3 destination;
    public float speed;
    public int health = 3;
    bool isMoving;
    bool isAttacking;
    public ProgressBar Pb;
    [SerializeField] AudioClip _Footsteps;
    [SerializeField] AudioClip _AttackSound;
    public static int playerNum = 5;
    public Animator animator;
    private float attackCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        destination = this.transform.position;
        playerNum = 5;
        isMoving = false;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pb.BarValue = health;
        //Debug.Log(canMove);
        if (Vector3.Distance(this.transform.position, destination) > 1.5f)
        {
            //Vector3.MoveTowards(this.transform.position, destination, speed * Time.deltaTime);
            transform.LookAt(destination);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            transform.Translate(0, 0, speed * Time.deltaTime);
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        }
        if (health <= 0 && gameObject != null)
        {
            transform.Translate(0, -Time.deltaTime, 0);
            Destroy(gameObject);
            playerNum--;
        }

        /*if (isMoving == false)
        {
            animator.SetBool("isMoving", false);
        }
        if (isMoving == true)
        {
            animator.SetBool("isMoving", true);
        }*/
        

        if (isAttacking == false)
        {
            animator.SetBool("isAttacking", false);
        }
        if (isAttacking == true)
        {
            animator.SetBool("isAttacking", true);
            attackCounter -= 1;
            if (attackCounter <= 0)
            {
                isAttacking = false;
            }
        }
    }

    public void Move(Tile2 newLocation)
    {
        
        if (canMove && Vector3.Distance(this.transform.position, newLocation.transform.position) <= range && GameManager2.playerTurn && newLocation.occupier == null)
        {
            Debug.Log("Moved Success");
            isMoving = true;
            AudioHelper.PlayClip2D(_Footsteps, 1f);
            location.occupier = null;
            location = newLocation;
            location.occupier = this.gameObject;
            canMove = false;
            destination = newLocation.transform.position;
        }
        else
        {
            Debug.Log("Can't move");
            isMoving = false;
        }
        //isMoving = false;
    }

    public void Attack(GameObject opponent)
    {
        if (canMove)
        {
            attackCounter = 10;
            isAttacking = true;
            AudioHelper.PlayClip2D(_AttackSound, 1f);
            EnemyUnit enemy = opponent.GetComponent<EnemyUnit>();
            enemy.health -= 10;
            
            canMove = false;
            Debug.Log("enemy health: " + enemy.health);
        }
        else 
        {
            Debug.Log("can't attack");
            isAttacking = false;
        }
        //isAttacking = false;
    }


}
