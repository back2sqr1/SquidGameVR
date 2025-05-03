using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> cards;
    public GameObject passthroughManager;
    public GameObject blueMesh;
    void Start()
    {
        cards = new List<GameObject>();
        foreach (Transform child in transform)
        {
            cards.Add(child.gameObject);
        }

        // Shuffle the deck of cards once
        ShuffleCards();
        PositionCards(new Vector3(0.5f, 1, 0), 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        // No need to shuffle the deck of cards every frame
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            passthroughManager.SetActive(!passthroughManager.activeSelf);
            blueMesh.SetActive(!blueMesh.activeSelf);

        }

    }

    void ShuffleCards()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    void PositionCards(Vector3 center, float spacing)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            float yOffset = i * spacing;
            cards[i].transform.position = new Vector3(center.x - 0.5f, center.y + yOffset, center.z);
            cards[i].transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        int cardNum = 0;
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (j == i)
                {
                    cards[cardNum].transform.position = new Vector3(center.x + (i * 0.15f), center.y + (j * spacing), center.z + (j * 0.05f));
                    cards[cardNum].transform.rotation = Quaternion.Euler(-90, 0, 0);
                }
                else
                {
                    cards[cardNum].transform.position = new Vector3(center.x + (i * 0.15f), center.y + (j * spacing), center.z + (j * 0.05f));
                    cards[cardNum].transform.rotation = Quaternion.Euler(90, 0, 0);
                }
                cardNum++;
            }
        }
    }
}
   