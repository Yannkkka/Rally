using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> checkpoints;
    private int nextCheckpointIndex = 0;
    private int completeCircles = 0;
    public Material finishMaterial;
    public Text textRound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textRound.text = "Round: " + completeCircles.ToString();
    }

    public void checkpointReached(GameObject checkpoint)
    {
        if (checkpoints[nextCheckpointIndex] == checkpoint)
        {
            checkpoint.GetComponent<Renderer>().material.color = Color.green;
            nextCheckpointIndex++;
            Debug.Log("checkpoint");
        }
    }

    public void finishReached(GameObject finishBlock)
    {
        if (nextCheckpointIndex == checkpoints.Count)
        {
            finishBlock.GetComponent<Collider>().isTrigger = false;
            finishBlock.GetComponent<Renderer>().material.color = Color.blue;
            Debug.Log("finish");
            completeCircles++;
            Debug.Log(completeCircles);
            StartCoroutine(timer(0.5f, finishBlock));
        }
    }

    private void Reset(GameObject finish)
    {
        foreach (GameObject block in checkpoints)
        {
            block.GetComponent<Renderer>().material.color = Color.white;
        }
        finish.GetComponent<Renderer>().material = finishMaterial;

        nextCheckpointIndex = 0;
    }

    IEnumerator timer(float time, GameObject block)
    {
        yield return new WaitForSeconds(time);
        Reset(block);
        block.GetComponent<Collider>().isTrigger = true;
    }

}
