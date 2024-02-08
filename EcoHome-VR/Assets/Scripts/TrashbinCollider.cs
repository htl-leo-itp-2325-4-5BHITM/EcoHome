using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashbinCollider : MonoBehaviour
{
    [SerializeField] private Player player;
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

    // particle system
    [SerializeField] ParticleSystem paperParticle; 

    void Start() {
        paperParticle = GetComponent<ParticleSystem>();
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == plasticTrashTag && this.gameObject.tag == plasticBinTag)
            || (collision.gameObject.tag == tinTrashTag && this.gameObject.tag == tinBinTag)
            || (collision.gameObject.tag == bioTrashTag && this.gameObject.tag == bioBinTag)
            || (collision.gameObject.tag == glassTrashTag && this.gameObject.tag == glassBinTag))
        {
            Destroy(collision.gameObject);
            Player.localScoreCounter += 1;
            Player.globalScoreCounter += 1;

            audioPlayer.Play();
            paperParticle.Play();
        }
    }

}
