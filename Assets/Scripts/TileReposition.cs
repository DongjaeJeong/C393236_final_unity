using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileReposition : MonoBehaviour
{
    Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;
        Vector3 player_pos = GameManager.Instance.player.transform.position;
        Vector3 tile_pos = transform.position;
        float diffX = Mathf.Abs(player_pos.x - tile_pos.x);
        float diffY = Mathf.Abs(player_pos.y - tile_pos.y);

        Vector3 playerDir = GameManager.Instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1:1;
        float dirY = playerDir.y < 0 ? -1:1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                    transform.Translate(Vector3.right * dirX * 40);
                else if (diffX < diffY)
                    transform.Translate(Vector3.up * dirY * 40);
                break;

            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0)); 
                }
                break;
        }
    }
}
