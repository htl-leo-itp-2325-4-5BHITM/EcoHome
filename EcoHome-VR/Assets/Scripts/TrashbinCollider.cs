using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashbinCollider : MonoBehaviour
{
    [SerializeField] private Player player;
    private string paperTrashTag = "PaperTrash";
    private string paperBinTag = "PaperBin";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == paperTrashTag && this.gameObject.tag == paperBinTag)
        {
            Destroy(collision.gameObject);
            Player.globalScoreCounter += 1;
        }
    }
}
