using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public PlayerDirection direction;

    //[HideInInspector]
    public float step_length = 2f;

    //[HideInInspector]
    public float movement_frequency = 0.5f;

    private float counter;
    private bool move;

    [SerializeField]
    private GameObject tailPrefab;

    private List<Vector3> delta_Position;

    private List<Rigidbody> nodes;

    private Rigidbody main_Body;
    private Rigidbody head_Body;
    private Transform tr;

    string lastTag = Tags.FOOD;
    int foodStreak = 0;

    private bool create_Node_At_Tail;




    // Start is called before the first frame update
    void Awake()
    {
        tr = transform;
        main_Body = GetComponent<Rigidbody>();
        InitSnakeNodes();
        InitPlayer();
        //GameplayController.instance.SpawnFood();

        delta_Position = new List<Vector3>()
        {
            new Vector3(-step_length, 0f),
            new Vector3(0f, step_length),
            new Vector3(step_length, 0f),
            new Vector3(0f, -step_length)
        };
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovementFrequency();
    }

    void FixedUpdate()
    {
        if (move)
        {
            move = false;
            Move();
        }
    }

    void InitSnakeNodes()
    {
        nodes = new List<Rigidbody>();

        nodes.Add(tr.GetChild(0).GetComponent<Rigidbody>());
        nodes.Add(tr.GetChild(1).GetComponent<Rigidbody>());
        nodes.Add(tr.GetChild(2).GetComponent<Rigidbody>());

        head_Body = nodes[0];
    }

    void SetDirectionRandom()
    {
        direction = PlayerDirection.RIGHT;
    }
    void InitPlayer()
    {
        SetDirectionRandom();
        nodes[1].position = nodes[0].position - new Vector3(2f, 0f, 0f);
        nodes[2].position = nodes[0].position - new Vector3(4f, 0f, 0f);
    }

    void Move()
    {
        Vector3 dPosition = delta_Position[(int)direction];
        Vector3 parentPos = head_Body.position;
        Vector3 prevPosition;

        main_Body.position = main_Body.position + dPosition;
        head_Body.position = head_Body.position + dPosition;

        for (int i = 1; i < nodes.Count; i++) {
            prevPosition = nodes[i].position;
            nodes[i].position = parentPos;
            parentPos = prevPosition;
        }

        if (create_Node_At_Tail)
        {
            create_Node_At_Tail = false;
            GameObject newNode = Instantiate(tailPrefab, nodes[nodes.Count-1].position, Quaternion.identity);

            newNode.transform.SetParent(transform, true);
            nodes.Add(newNode.GetComponent<Rigidbody>());
        }

    }

    void CheckMovementFrequency()
    {
        counter += Time.deltaTime;
        if (counter >= movement_frequency) {
            counter = 0f;
            move = true;
        }
    }

    public void SetInputDirection(PlayerDirection dir){
        if (dir == PlayerDirection.UP && direction == PlayerDirection.DOWN ||
            dir == PlayerDirection.DOWN && direction == PlayerDirection.UP ||
            dir == PlayerDirection.RIGHT && direction == PlayerDirection.LEFT ||
            dir == PlayerDirection.LEFT && direction == PlayerDirection.RIGHT)
        {
            return;
        }
        direction = dir;
        ForceMove();
    }

    void ForceMove()
    {
        counter = 0;
        move = false;
        Move();
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == Tags.RED || target.tag == Tags.BLUE
            || target.tag == Tags.GREEN || target.tag == Tags.YELLOW) {
            print("Touched Food");
            
            if(lastTag != target.tag)
            {
                foodStreak = 1;
                lastTag = target.tag;
            }
            else
            {
                foodStreak += 1;
            }
            GameplayController.instance.IncreaseScore(getScore(target.tag) * foodStreak);
            target.gameObject.SetActive(false);
            create_Node_At_Tail = true;
        }

        if(target.tag == Tags.TAIL || target.tag == Tags.WALL)
        {
            print("You Died");
            Time.timeScale = 0;
            EndMenu.gameHasEnded = true;
        }
    }

    int getScore(string str)
    {
        if (str == "Red")
        {
            return FoodSpawner.instance.colorScore.red; 
        }
        else if (str == "Blue")
        {
            return FoodSpawner.instance.colorScore.blue;
        }
        else if (str == "Green")
        {
            return FoodSpawner.instance.colorScore.green;
        }
        else if (str == "Yellow")
        {
            return FoodSpawner.instance.colorScore.yellow;
        }
        else
        {
            return 0;
        }
    }
}
