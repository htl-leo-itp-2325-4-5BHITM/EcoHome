using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MuseumBin : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private GameHandler gameHandler;
    private string paperTrashTag = "PaperTrash";
    private string paperBinTag = "PaperBin";
    private string plasticTrashTag = "PlasticTrash";
    private string plasticBinTag = "PlasticBin";
    private string tinTrashTag = "TinTrash";
    private string tinBinTag = "TinBin";
    private string bioTrashTag = "BioTrash";
    private string bioBinTag = "BioBin";
    private string glassTrashTag = "GlassTrash";
    private string glassBinTag = "GlassBin";

    // audio system
    public AudioSource audioPlayer; 
    public AudioClip clip_1;
    public AudioClip clip_2;

    // particle system
    [SerializeField] ParticleSystem paperParticle; 



    void Start() {
        paperParticle = GetComponent<ParticleSystem>();
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == paperTrashTag && this.gameObject.tag == paperBinTag)
            || (collision.gameObject.tag == plasticTrashTag && this.gameObject.tag == plasticBinTag)
            || (collision.gameObject.tag == tinTrashTag && this.gameObject.tag == tinBinTag)
            || (collision.gameObject.tag == bioTrashTag && this.gameObject.tag == bioBinTag)
            || (collision.gameObject.tag == glassTrashTag && this.gameObject.tag == glassBinTag))
        {
            gameHandler.spawnTrash(collision.gameObject.tag);

            Destroy(collision.gameObject);
            Playerchall.localScoreCounter += 1;
            Playerchall.globalScoreCounter += 1;
            Playerchall.displayScoreCounter += 1;

            audioPlayer.PlayOneShot(clip_1);
            paperParticle.Play();
        }
        else {
            audioPlayer.PlayOneShot(clip_2);
            if (Playerchall.displayScoreCounter > 0)
            {
                Playerchall.displayScoreCounter -= 1;
            }
        }
    }

}