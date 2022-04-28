using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public static int width = 16;
    public static int height = 10;
    public GameObject tile;
    public static GameObject[,] tiles;
    public int playerUnits;
    public int enemyUnits;
    public GameObject[] playerUnitTypes;
    public List<GameObject> activePlayerUnits;
    public GameObject[] enemyUnitTypes;
    public List<GameObject> activeEnemyUnits;
    public GameObject mouseOver;
    public GameObject currentlySelected;
    public static bool playerTurn = true;
    public Button endTurn;
    public Text displayTurn;
    [SerializeField] SceneLoader _sceneLoader = null;
    [SerializeField] AudioClip _battleTheme;
    [SerializeField] AudioClip _selection;
    [SerializeField] AudioClip _invalidSelection;
    private AudioSource Audio;



    void EndTurn()
    {
        StartCoroutine(CoUpdate());
    }

    List<GameObject> getAdjacent(int w, int h)
    {
        List<GameObject> adjacent = new List<GameObject>();
        if (w == 0 && h == 0) // upper left
        {
            adjacent.Add(tiles[w + 1, h]);
            adjacent.Add(tiles[w, h + 1]);
        }
        else if (w == 0 && h == height - 1) // lower left
        {
            adjacent.Add(tiles[w + 1, h]);
            adjacent.Add(tiles[w, h - 1]);
        }
        else if (w == width - 1 && h == 0) // upper right
        {
            adjacent.Add(tiles[w - 1, h]);
            adjacent.Add(tiles[w, h + 1]);
        }
        else if (w == width - 1 && h == height - 1) // lower right
        {
            adjacent.Add(tiles[w, h - 1]);
            adjacent.Add(tiles[w - 1, h]);
        }
        else if (h == 0) // top
        {
            adjacent.Add(tiles[w + 1, h]);
            adjacent.Add(tiles[w - 1, h]);
            adjacent.Add(tiles[w, h + 1]);
        }
        else if (h == height - 1) // bottom
        {
            adjacent.Add(tiles[w + 1, h]);
            adjacent.Add(tiles[w - 1, h]);
            adjacent.Add(tiles[w, h - 1]);
        }
        else if (w == 0) // left
        {
            adjacent.Add(tiles[w, h - 1]);
            adjacent.Add(tiles[w, h + 1]);
            adjacent.Add(tiles[w + 1, h]);
        }
        else if (w == width - 1) // right
        {
            adjacent.Add(tiles[w, h - 1]);
            adjacent.Add(tiles[w, h + 1]);
            adjacent.Add(tiles[w - 1, h]);
        }
        else
        {
            Debug.Log("w: " + w);
            Debug.Log("h: " + h);
            adjacent.Add(tiles[w + 1, h + 1]);
            adjacent.Add(tiles[w - 1, h + 1]);
            adjacent.Add(tiles[w - 1, h - 1]);
            adjacent.Add(tiles[w + 1, h - 1]);
        }
        return adjacent;
    }

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.clip = _battleTheme;
        Audio.loop = true;
        Audio.Play();
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        EnemyUnit.enemyNum = 5;
        PlayerUnit.playerNum = 5;
        displayTurn.text = "Player Turn";
        endTurn.onClick.AddListener(EndTurn);
        tiles = new GameObject[width, height];
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                tiles[w, h] = Instantiate(tile, new Vector3(w, 0, h), Quaternion.identity);
                Tile2 curtile = tiles[w, h].GetComponent<Tile2>();
                int type = Random.Range(0, curtile.costumes.Length);
                bool walk = true;
                if (type == 1)
                {
                    walk = false;
                }
                curtile.Initialize(type, walk);
            }
        }

        int passable = Random.Range(0,width);

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                if (w == passable) 
                {
                    Tile2 curtile = tiles[w, h].GetComponent<Tile2>();
                    curtile.Change(0, true);
                }
                

                List<GameObject> adjacent = new List<GameObject>();
                if (w == 0 && h == 0)
                {
                    adjacent.Add(tiles[w + 1, h]);
                    adjacent.Add(tiles[w, h + 1]);
                }
                else if (w == 0 && h == height - 1)
                {
                    adjacent.Add(tiles[w + 1, h]);
                    adjacent.Add(tiles[w, h - 1]);
                }
                else if (w == width - 1 && h == 0)
                {
                    adjacent.Add(tiles[w - 1, h]);
                    adjacent.Add(tiles[w, h + 1]);
                }
                else if (w == width - 1 && h == height - 1)
                {
                    adjacent.Add(tiles[w, h - 1]);
                    adjacent.Add(tiles[w - 1, h]);
                }
                else if (h == 0)
                {
                    adjacent.Add(tiles[w + 1, h]);
                    adjacent.Add(tiles[w - 1, h]);
                    adjacent.Add(tiles[w, h + 1]);
                }
                else if (h == height - 1)
                {
                    adjacent.Add(tiles[w + 1, h]);
                    adjacent.Add(tiles[w - 1, h]);
                    adjacent.Add(tiles[w, h - 1]);
                }
                else if (w == 0)
                {
                    adjacent.Add(tiles[w, h - 1]);
                    adjacent.Add(tiles[w, h + 1]);
                    adjacent.Add(tiles[w + 1, h]);
                }
                else if (w == width - 1)
                {
                    adjacent.Add(tiles[w, h - 1]);
                    adjacent.Add(tiles[w, h + 1]);
                    adjacent.Add(tiles[w - 1, h]);
                }
                else 
                {
                    adjacent.Add(tiles[w + 1, h + 1]);
                    adjacent.Add(tiles[w - 1, h + 1]);
                    adjacent.Add(tiles[w - 1, h - 1]);
                    adjacent.Add(tiles[w + 1, h - 1]);
                }




                bool haswalkable = false;
                foreach (GameObject t in adjacent) 
                {
                    Tile2 curtile = t.GetComponent<Tile2>();
                    if (curtile.walkable) 
                    {
                        haswalkable = true;
                    }
                }

                if (haswalkable==false) 
                {
                    foreach (GameObject t in adjacent)
                    {
                        Tile2 thetile = t.GetComponent<Tile2>();
                        thetile.Change(0, true);
                    }

                }



                

            }
        }

        for (int i = 0; i < playerUnits; i++)
        {
            foreach (GameObject unit in playerUnitTypes)
            {
                Debug.Log(tiles.Length);
                Tile2 randomTile = tiles[Random.Range(0, width), Random.Range(0, height / 2)].GetComponent<Tile2>();
                while (randomTile.occupier != null)
                {
                    randomTile = tiles[Random.Range(0, width), Random.Range(0, height/2)].GetComponent<Tile2>();
                }
                GameObject currentUnit = Instantiate(unit, randomTile.transform.position, Quaternion.identity);
                randomTile.occupier = currentUnit;
                currentUnit.GetComponent<PlayerUnit>().location = randomTile;
                currentUnit.transform.Translate(0, 1.5f, 0);
                activePlayerUnits.Add(currentUnit);
            }
        }

        for (int i = 0; i < enemyUnits; i++) 
        {
            Debug.Log("tried to make an enemy");
            foreach (GameObject unit in enemyUnitTypes)
            {
                Tile2 randomTile = tiles[Random.Range(0, width), Random.Range(height / 2, height)].GetComponent<Tile2>();
                while (randomTile.occupier != null)
                {
                    randomTile = tiles[Random.Range(0, width), Random.Range(height / 2, height)].GetComponent<Tile2>();
                }
                GameObject currentUnit = Instantiate(unit, randomTile.transform.position, Quaternion.identity);

                randomTile.occupier = currentUnit;
                currentUnit.GetComponent<EnemyUnit>().location = randomTile;
                currentUnit.transform.Translate(0, 1.5f, 0);
                activeEnemyUnits.Add(currentUnit);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            mouseOver = hit.transform.gameObject;
        }
        else
        {
            mouseOver = null;
        }
        if(currentlySelected != null)
        {
            if (currentlySelected.tag == "Tile") 
            {
                currentlySelected = null;
                AudioHelper.PlayClip2D(_invalidSelection, 1f);
            }
            else if (currentlySelected.tag == "Enemy")
            {
                currentlySelected = null;
                AudioHelper.PlayClip2D(_invalidSelection, 1f);
            }
        }
        if (Input.GetMouseButtonDown(0) && mouseOver != null && currentlySelected == null /*&& mouseOver.tag != "Enemy"*/)
        {
            currentlySelected = mouseOver;
            
        }
        if (currentlySelected != null && currentlySelected.tag == "Hero" && Input.GetMouseButtonDown(0))
        {
            AudioHelper.PlayClip2D(_selection, 1f);
            Debug.Log("hero selected");
            if(mouseOver != null && mouseOver.tag == "Tile")
            {
                Debug.Log("tile selected");
                PlayerUnit p = currentlySelected.GetComponent<PlayerUnit>();
                //p.destination = mouseOver.transform.position;
                Tile2 t = mouseOver.GetComponent<Tile2>();
                p.Move(t);
                currentlySelected = null;
            }
            if (mouseOver != null && mouseOver.tag == "Enemy")
            {
                Debug.Log("Attack attempted");
                Debug.Log(currentlySelected);
                PlayerUnit unit = currentlySelected.GetComponent<PlayerUnit>();
                if (Vector3.Distance(mouseOver.transform.position,currentlySelected.transform.position) < unit.attackRange) 
                {
                    unit.Attack(mouseOver);
                }


               /* List<GameObject> adj = getAdjacent((int)currentlySelected.transform.position.x, (int)currentlySelected.transform.position.z);
                Debug.Log(adj);
                bool foundit = false;
                foreach (GameObject g in adj) 
                {
                    Tile2 t = g.GetComponent<Tile2>();
                    Debug.Log(t.occupier);
                    if (t.occupier == mouseOver) 
                    {
                        currentlySelected.GetComponent<PlayerUnit>().Attack(mouseOver);
                        Debug.Log("Attack Successful");
                    }
                }*/
                currentlySelected = null;
            }
        }

        if(playerTurn == false)
        {
            
            displayTurn.text = " ";
            foreach (GameObject enemy in activeEnemyUnits)
            {
                if (enemy != null) 
                {
                    EnemyUnit eunit = enemy.GetComponent<EnemyUnit>();
                    GameObject closest = eunit.ClosestObjectWithTag("Hero");
                    if (Vector3.Distance(eunit.transform.position,closest.transform.position) <= eunit.attackRange) 
                    {
                        eunit.Attack(closest);
                        Debug.Log("Enemy Attacked Hero");
                        Debug.Log("Hero health: " + closest.GetComponent<PlayerUnit>().health);
                    }
                    else
                    {
                        eunit.Move();
                    }
                    
                }
                
            }
            playerTurn = true;
            displayTurn.text = " ";
            foreach (GameObject player in activePlayerUnits)
            {
                if (player != null)
                {
                    player.GetComponent<PlayerUnit>().canMove = true;
                }
            }
        }
        WinState();
        LoseState();

    }

    void WinState()
    {
        if (EnemyUnit.enemyNum == 0)
        {
            _sceneLoader.ReloadLevel();
            SceneManager.LoadScene("WinScreen");
        }
    }

    void LoseState()
    {
        if (PlayerUnit.playerNum == 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    IEnumerator CoUpdate ()
    {
        playerTurn = false;
        displayTurn.text = " ";
        yield return new WaitForSeconds(1);
        foreach (GameObject g in activeEnemyUnits)
        {
            if (g != null)
            {
                g.GetComponent<EnemyUnit>().canMove = true;
            }

        }
        yield return null;
    }

}
