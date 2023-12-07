using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashbinCollider : MonoBehaviour
{
    [SerializeField] private Player player;
    private string paperTrashTag = "PaperTrash";
    private string paperBinTag = "PaperBin";
    private int maxScore = 5;

    //audio system
    public AudioSource audioPlayer; 

    //particle system
    [SerializeField] ParticleSystem paperParticle; 

    void Start() {
        paperParticle = GetComponent<ParticleSystem>();
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == paperTrashTag && this.gameObject.tag == paperBinTag)
        {
            Destroy(collision.gameObject);
            Player.globalScoreCounter += 1;

            audioPlayer.Play();
        }
    }

    void onTriggerEnter(Collision other)
    {
        if (other.gameObject.tag == paperTrashTag && this.gameObject.tag == paperBinTag)
        {
            paperParticle.Play();
        }
    }

}
