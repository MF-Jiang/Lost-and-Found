using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 5.0f;

    public int health = 1;

    public bool yel = false;
    public bool red = false;
    public bool blue = false;


    private Rigidbody2D rb2d;
    private Animator anim;

    public GameObject DieClick;
    [SerializeField]
    public Vector2 VelocityDir = Vector2.right;
    private Vector2 additionalAcceleration = Vector2.zero;
    private BoxCollider2D boxCollider2D;

    public AudioSource walk;
    public AudioClip collect;
    public AudioClip die;
    public AudioClip piu;
    public AudioClip bounce;

    public enum PlayerColors
    {
        White,
        Red,
        Blue,
        Yellow
      
    }

    public enum ShootChoice
    {
        Cant,
        Two,
        Three
    }

    public ShootChoice shootChoice = ShootChoice.Cant;

    public PlayerColors ownColor = PlayerColors.Red;

    public bool couldChangeDir = false;
    public bool ANYChange = false;

    public GameObject fireballPrefab;
    public GameObject fireballPrefab2;
    public Transform[] fireballSpawnDownPoint;
    public Transform[] fireballSpawnUpPoint;
    public Transform[] fireballSpawnRightPoint;
    public Transform[] fireballSpawnLeftPoint;

    //public Collider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isAlive", true);
        boxCollider2D = GetComponent<BoxCollider2D>();
        walk.Play();

        //如果是scene3场景
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Scene3")
        {
            anim.SetInteger("color", 1);
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Scene4")
        {
            anim.SetInteger("color", 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rb2d.velocity = VelocityDir * speed;
        rb2d.velocity = (VelocityDir + additionalAcceleration) * speed;

        if ((VelocityDir == Vector2.right || VelocityDir == Vector2.left) && (couldChangeDir || ANYChange))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                VelocityDir = Vector2.up;
                couldChangeDir = false;
                DieClick.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                VelocityDir = Vector2.down;
                couldChangeDir = false;
                DieClick.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }
        else if ((VelocityDir == Vector2.up || VelocityDir == Vector2.down) && (couldChangeDir || ANYChange))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                VelocityDir = Vector2.left;
                couldChangeDir = false;
                DieClick.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                VelocityDir = Vector2.right;
                couldChangeDir = false;
                DieClick.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (VelocityDir == Vector2.right || VelocityDir == Vector2.left)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    additionalAcceleration = Vector2.up;
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    additionalAcceleration = Vector2.down;
                }
            }
            if (VelocityDir == Vector2.up || VelocityDir == Vector2.down)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    additionalAcceleration = Vector2.left;
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    additionalAcceleration = Vector2.right;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            additionalAcceleration = Vector2.zero;
        }

        if (ownColor == PlayerColors.White || ownColor == PlayerColors.Red || ownColor == PlayerColors.Blue)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (VelocityDir == Vector2.right)
                {
                    if (shootChoice == ShootChoice.Two)
                    {
                        ShootFireball(fireballSpawnRightPoint[1]);
                        ShootFireball(fireballSpawnRightPoint[3]);
                        shootChoice = ShootChoice.Cant;

                        float a = transform.localScale.x;
                        float b = transform.localScale.y;
                        float c = transform.localScale.z;
                        transform.localScale = new Vector3(a / 2, b / 2, c);
                    }
                    else if (shootChoice == ShootChoice.Three)
                    {
                        ShootFireball(fireballSpawnRightPoint[0]);
                        ShootFireball(fireballSpawnRightPoint[2]);
                        ShootFireball(fireballSpawnRightPoint[4]);
                        shootChoice = ShootChoice.Two;

                        float a = transform.localScale.x;
                        float b = transform.localScale.y;
                        float c = transform.localScale.z;
                        transform.localScale = new Vector3(a / 1.5f, b / 1.5f, c);
                    }
                }
                else if (VelocityDir == Vector2.left)
                {
                    if (shootChoice == ShootChoice.Two)
                    {
                        ShootFireball(fireballSpawnLeftPoint[1]);
                        ShootFireball(fireballSpawnLeftPoint[3]);
                        shootChoice = ShootChoice.Cant;

                        float a = transform.localScale.x;
                        float b = transform.localScale.y;
                        float c = transform.localScale.z;
                        transform.localScale = new Vector3(a / 2, b / 2, c);
                    }
                    else if (shootChoice == ShootChoice.Three)
                    {
                        ShootFireball(fireballSpawnLeftPoint[0]);
                        ShootFireball(fireballSpawnLeftPoint[2]);
                        ShootFireball(fireballSpawnLeftPoint[4]);
                        shootChoice = ShootChoice.Two;

                        float a = transform.localScale.x;
                        float b = transform.localScale.y;
                        float c = transform.localScale.z;
                        transform.localScale = new Vector3(a / 1.5f, b / 1.5f, c);
                    }
                }
                else if (VelocityDir == Vector2.up)
                {
                    if (shootChoice == ShootChoice.Two)
                    {
                        ShootFireball(fireballSpawnUpPoint[1]);
                        ShootFireball(fireballSpawnUpPoint[3]);
                        shootChoice = ShootChoice.Cant;

                        float a = transform.localScale.x;
                        float b = transform.localScale.y;
                        float c = transform.localScale.z;
                        transform.localScale = new Vector3(a / 2, b / 2, c);
                    }
                    else if (shootChoice == ShootChoice.Three)
                    {
                        ShootFireball(fireballSpawnUpPoint[0]);
                        ShootFireball(fireballSpawnUpPoint[2]);
                        ShootFireball(fireballSpawnUpPoint[4]);
                        shootChoice = ShootChoice.Two;

                        float a = transform.localScale.x;
                        float b = transform.localScale.y;
                        float c = transform.localScale.z;
                        transform.localScale = new Vector3(a / 1.5f, b / 1.5f, c);
                    }
                }
                else if (VelocityDir == Vector2.down)
                {
                    if (shootChoice == ShootChoice.Two)
                    {
                        ShootFireball(fireballSpawnDownPoint[1]);
                        ShootFireball(fireballSpawnDownPoint[3]);
                        shootChoice = ShootChoice.Cant;

                        float a = transform.localScale.x;
                        float b = transform.localScale.y;
                        float c = transform.localScale.z;
                        transform.localScale = new Vector3(a / 2, b / 2, c);
                    }
                    else if (shootChoice == ShootChoice.Three)
                    {
                        ShootFireball(fireballSpawnDownPoint[0]);
                        ShootFireball(fireballSpawnDownPoint[2]);
                        ShootFireball(fireballSpawnDownPoint[4]);
                        shootChoice = ShootChoice.Two;

                        float a = transform.localScale.x;
                        float b = transform.localScale.y;
                        float c = transform.localScale.z;
                        transform.localScale = new Vector3(a / 1.5f, b / 1.5f, c);
                    }
                }
                walk.PlayOneShot(piu);
            }
        }
        else if (ownColor == PlayerColors.Yellow)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (shootChoice == ShootChoice.Two)
                {
                    shootChoice = ShootChoice.Cant;
                    float a = transform.localScale.x;
                    float b = transform.localScale.y;
                    float c = transform.localScale.z;
                    transform.localScale = new Vector3(a / 2f, b / 2, c);
                }
                else if (shootChoice == ShootChoice.Three)
                {
                    shootChoice = ShootChoice.Two;
                    float a = transform.localScale.x;
                    float b = transform.localScale.y;
                    float c = transform.localScale.z;
                    transform.localScale = new Vector3(a / 1.5f, b / 1.5f, c);
                }
                else
                {
                    return;
                }
                speed = 0;
                boxCollider2D.enabled = true;
                StartCoroutine(WaitYellow());
            
            }
        }

        if (VelocityDir == Vector2.left)
        {
            anim.SetInteger("direction", 3);
        }
        else if (VelocityDir == Vector2.right)
        {
            anim.SetInteger("direction", 2);
        }
        else if (VelocityDir == Vector2.down)
        {
            anim.SetInteger("direction", 1);
        }
        else if (VelocityDir == Vector2.up)
        {
            anim.SetInteger("direction", 0);
        }

        /*        //按e切换下一个颜色
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (ownColor == PlayerColors.White)
                    { 
                        ownColor = PlayerColors.Red;
                        anim.SetInteger("color",1);
                    }
                    else if (ownColor == PlayerColors.Red)
                    {
                        ownColor = PlayerColors.Yellow;
                        anim.SetInteger("color", 2);

                    }
                    else if (ownColor == PlayerColors.Yellow)
                    {
                        ownColor = PlayerColors.Blue;
                        anim.SetInteger("color", 3);

                    }
                    else if (ownColor == PlayerColors.Blue)
                    {
                        ownColor = PlayerColors.White;
                        anim.SetInteger("color", 0);
                    }
                }*/
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ownColor = PlayerColors.White;
            anim.SetInteger("color", 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && red)
        {
            ownColor = PlayerColors.Red;
            anim.SetInteger("color", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && yel)
        {
            ownColor = PlayerColors.Yellow;
            anim.SetInteger("color", 2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && blue)
        {
            ownColor = PlayerColors.Blue;
            anim.SetInteger("color", 3);
        }
    }

    void ShootFireball(Transform spawnPoint)
    {
        if (ownColor == PlayerColors.White || ownColor == PlayerColors.Blue)
        {
            if (fireballPrefab != null && spawnPoint != null)
            {
                GameObject fireball = Instantiate(fireballPrefab, spawnPoint.position, spawnPoint.rotation);
                fireball.GetComponent<FireballController>().SetDirection(VelocityDir);
            }
        }

        if (ownColor == PlayerColors.Red)
        {
            if (fireballPrefab2 != null && spawnPoint != null)
            {
                GameObject fireball = Instantiate(fireballPrefab2, spawnPoint.position, spawnPoint.rotation);
                fireball.GetComponent<FireballController>().SetDirection(VelocityDir);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "eatbigger")
        {
            if (shootChoice == ShootChoice.Cant)
            {
                float a = transform.localScale.x;
                float b = transform.localScale.y;
                float c = transform.localScale.z;

                transform.localScale = new Vector3(2 * a, 2 * b, c);
                shootChoice = ShootChoice.Two;
                Destroy(collision.gameObject);
            }
            else if (shootChoice == ShootChoice.Two)
            {
                float a = transform.localScale.x;
                float b = transform.localScale.y;
                float c = transform.localScale.z;
                transform.localScale = new Vector3(1.5f * a, 1.5f * b, c);
                shootChoice = ShootChoice.Three;
                Destroy(collision.gameObject);
            }
            walk.PlayOneShot(collect);
        }

        if (collision.gameObject.tag == "Bouncing back ")
        {
            if (VelocityDir == Vector2.left)
            {
                VelocityDir = Vector2.right;
            }
            else if (VelocityDir == Vector2.right)
            {
                VelocityDir = Vector2.left;
            }
            else if (VelocityDir == Vector2.up)
            {
                VelocityDir = Vector2.down;
            }
            else if (VelocityDir == Vector2.down)
            {
                VelocityDir = Vector2.up;
            }
            walk.PlayOneShot(bounce);
        }

        if (collision.gameObject.tag == "Ci" || collision.gameObject.tag == "Rock")
        {
            gameObject.GetComponent<Animator>().SetBool("isAlive", false);
            walk.PlayOneShot(die);
            StartCoroutine(Wait(collision));

        }

        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            walk.PlayOneShot(collect);
        }
    }

    IEnumerator Wait(Collision2D collision)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    IEnumerator WaitYellow()
    {
        yield return new WaitForSeconds(0.5f);
        boxCollider2D.enabled = false;
        speed = 5.0f;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "eatbigger")
        {
            if (shootChoice == ShootChoice.Two)
            {
                Destroy(collision.gameObject);
                shootChoice = ShootChoice.Three;
                float a = transform.localScale.x;
                float b = transform.localScale.y;
                float c = transform.localScale.z;
                transform.localScale = new Vector3(a * 1.5f, b * 1.5f, c);
            }
            else if (shootChoice == ShootChoice.Three)
            { }
            else if (shootChoice == ShootChoice.Cant)
            {
                Destroy(collision.gameObject);
                shootChoice = ShootChoice.Three;
                float a = transform.localScale.x;
                float b = transform.localScale.y;
                float c = transform.localScale.z;
                transform.localScale = new Vector3(a * 2, b * 2, c);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "eatbigger")
        {
            if (shootChoice == ShootChoice.Two)
            {
                Destroy(collision.gameObject);
                shootChoice = ShootChoice.Three;
                float a = transform.localScale.x;
                float b = transform.localScale.y;
                float c = transform.localScale.z;
                transform.localScale = new Vector3(a * 1.5f, b * 1.5f, c);
            }
            else if (shootChoice == ShootChoice.Three)
            { }
            else if (shootChoice == ShootChoice.Cant)
            {
                Destroy(collision.gameObject);
                shootChoice = ShootChoice.Three;
                float a = transform.localScale.x;
                float b = transform.localScale.y;
                float c = transform.localScale.z;
                transform.localScale = new Vector3(a * 2, b * 2, c);
            }
        }
    }
}

