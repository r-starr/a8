using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TreasureHunter : MonoBehaviour
{
    public TextMesh scoreText;

    public int score = 0;
    public int itemsCollected = 0;

    public LayerMask mask;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // if the user presses Q, attempt to collect the closet object hit by raycast
        if(Input.GetKeyDown(KeyCode.Q)) {

            GameObject player = GameObject.Find("TreasureHunter");

            Collider[] collectibles = Physics.OverlapSphere(player.transform.position, 2f, mask.value);
            for(int i = 0; i < collectibles.Length; i++) {
                print(collectibles[i]);
                itemsCollected++;
                score += 50;
                scoreText.text = $"Score: {score}\nItems Collected: {itemsCollected}";
                Destroy(collectibles[i].gameObject);
            }
        }
    }
}
