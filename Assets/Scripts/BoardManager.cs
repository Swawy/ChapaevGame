using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Checker[,] Checkers { set; get; }
    private Checker selectedChecker;

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public List<GameObject> checkerItem;
    private List<GameObject> activeChecker;

    private Material previousMaterial;
    public Material selectedMaterial;

    private Quaternion orientation = Quaternion.Euler(0, 180, 0);

    public bool isWhiteTurn = true;

    private void Start()
    {
        SpawnAllCheckers();
    }

    private void Update()
    {
        //UpdateSelection();
        DrawCheckersBoard();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (selectionX >= 0 && selectionY >= 0)
        //    {
        //        if (selectedChecker == null)
        //        {
        //            SelectChecker(selectionX, selectionY);
        //        }
        //        else
        //        {
        //            MoveChecker(selectionX, selectionY);
        //        }
        //    }
        //}
    }

    private void SelectChecker(int x, int y)
    {
        if (Checkers[x, y] == null)
            return;

        if (Checkers[x, y].isWhite != isWhiteTurn)
            return;

        selectedChecker = Checkers[x, y];
        previousMaterial = selectedChecker.GetComponent<MeshRenderer>().material;
        selectedMaterial.mainTexture = previousMaterial.mainTexture;
        selectedChecker.GetComponent<MeshRenderer>().material = selectedMaterial;
    }

    private void MoveChecker(int x, int y)
    {
        if (selectedChecker.PossibleMove(x, y))
        {
            Checkers[selectedChecker.CurrentX, selectedChecker.CurrentY] = null;
            selectedChecker.transform.position = GetTileCenter(x, y);
            Checkers[x, y] = selectedChecker;
            isWhiteTurn = !isWhiteTurn;
        }

        selectedChecker.GetComponent<MeshRenderer>().material = previousMaterial;
        selectedChecker = null;
    }

    private void UpdateSelection()
    {
        if (!Camera.main)
            return;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("CheckersPlane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void SpawnChecker(int index, int x, int y)
    {
        GameObject go = Instantiate(checkerItem[index], GetTileCenter(x,y), orientation) as GameObject;
        go.transform.SetParent(transform);
        Checkers[x, y] = go.GetComponent<Checker>();
        Checkers[x, y].SetPosition(x, y);
        activeChecker.Add(go);
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        return origin;
    }

    private void SpawnAllCheckers()
    {
        activeChecker = new List<GameObject>();
        Checkers = new Checker[8, 8];

        for (int i = 0; i < 8; i++)
        {
            SpawnChecker(0,i,0);
            SpawnChecker(1,i,7);
        }
    }

    private void DrawCheckersBoard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }

        if(selectionX >= 0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            Debug.DrawLine(
                Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
        }
    }
}
