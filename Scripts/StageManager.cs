using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] mapSpots;
    [SerializeField]
    public int xDist;
    [SerializeField]
    public int zDist;
    [SerializeField]
    public  GameObject[,] spotMatrix;
    public Hashtable distances;
    private int[,] coords = new int[4, 2] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        int counter = 0;
        distances = new Hashtable();
        spotMatrix = new GameObject[xDist, zDist];
        //populate spotMatrix with all toplevel spots
        foreach (Transform child in transform)
        {
            counter++;
            int xCoord = (int)((child.position.x - 4) / 8);
            int zCoord = (int)((child.position.z - 4) / 8);
            if (spotMatrix[xCoord, zCoord] == null || spotMatrix[xCoord, zCoord].transform.position.y < child.position.y)
            {
                spotMatrix[xCoord, zCoord] = child.gameObject;
                spotMatrix[xCoord, zCoord].GetComponent<ValidSpot>().setFakeX(xCoord);
                spotMatrix[xCoord, zCoord].GetComponent<ValidSpot>().setFakeZ(zCoord);
            }
        }
        Debug.Log(counter);
        for (int i = 0; i < MenuManager.instance.ActiveCharactersInLevel.Count; i++) {
            int xc = MenuManager.instance.ActiveCharactersInLevel[i].GetComponent<CharacterPage>().X;
            int zc = MenuManager.instance.ActiveCharactersInLevel[i].GetComponent<CharacterPage>().Z;
            ValidSpot temp = spotMatrix[xc, zc].GetComponent<ValidSpot>();
                temp.setCharacterIsOnSpot(true);

            spotMatrix[xc, zc].GetComponent<ValidSpot>().setCharacterOnSpot(MenuManager.instance.ActiveCharactersInLevel[i]);
        }
        
    }
    void Recur( Hashtable ht, int curDist, int curX, int curZ, bool ps)
    {
        GameObject curObj = spotMatrix[curX, curZ];
        if (curObj == null)
        {
            return;
        }
        ValidSpot spotObj = curObj.GetComponent<ValidSpot>();
        if (spotObj.characterCanUse == false)
        {
            return;
        }
        if (spotObj.characterIsOnSpot == true)
        {
            if (spotObj.GetCharacterOnSpot().GetComponent<CharacterPage>().PlayerSide != ps)
            {
                if (ht[curX.ToString() + "," + curZ.ToString()] == null || ((int)ht[curX.ToString() + "," + curZ.ToString()] > curDist))
                {
                    ht[curX.ToString() + "," + curZ.ToString()] = curDist;
                }
                
                return;
            }
        }
        if (ht[curX.ToString() + "," + curZ.ToString()] == null || ((int)ht[curX.ToString() + "," + curZ.ToString()]) > curDist)
        {
           
            ht[curX.ToString() + "," + curZ.ToString()] = curDist;
        for (int i = 0; i < coords.GetLength(0); i++)
        {
            int nx = curX + coords[i, 0];
            int nz = curZ + coords[i, 1];
            if (nz >= 0 && nx >= 0 && nz < zDist && nx < xDist)
            {
                    Recur(ht, curDist+1, nx, nz, ps);
            }
        }

        }
    }
    public void FindDistancesWithinX(bool ps, int mDist, int sX, int sZ)
    {
        for (int i = 0; i < xDist; i++)
        {
            for (int j = 0; j < zDist; j++)
            {
                if (Mathf.Abs(i-sX)+Mathf.Abs(j-sZ) <= mDist)
                {
                    GameObject curSpot = spotMatrix[i, j];
                    if (curSpot == null)
                    {
                        continue;
                    }
                    FindAllDists(i, j, ps);
                }
                
            }
        }
    }
    public void FindDistances(bool ps)
    {
        for (int i = 0; i < xDist; i++)
        {
            for (int j = 0; j < zDist; j++)
            {
                GameObject curSpot = spotMatrix[i, j];
                if (curSpot == null)
                {
                    continue;
                }
                FindAllDists(i, j, ps);
            }
        }
    }
    public void FindAllDists( int xcs, int zcs, bool ps)
    {
        Hashtable distsHT = new Hashtable();
        
        Recur( distsHT, 0, xcs, zcs, ps);
        distances[xcs.ToString() + "," + zcs.ToString()] = distsHT;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
