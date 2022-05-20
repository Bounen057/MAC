using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviourPunCallbacks, IPunObservable
{
    public int hp_max;
    public int hp_current;
    public int item_id; // not meaning... what is idToName()?

    private ItemMeta itemMeta;

    void Start()
    {
        hp_current = hp_max;

        // CREATE HP bar
        GameObject obj = Instantiate((GameObject)Resources.Load("HpBar"), Vector3.zero, Quaternion.identity);
        obj.GetComponent<HpBar>().parent = this.gameObject;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) ){
            photonView.RPC(nameof(Damaged), RpcTarget.AllBufferedViaServer, 10);
        }

        if (hp_current <= 0)
        {
            GameObject.Find("DroppedItemManager").GetComponent<DroppedItemManager>().drop_id(item_id, this.transform.position);
            photonView.RPC(nameof(RPCDestroy), RpcTarget.AllBufferedViaServer);
            Destroy(this.gameObject); //  時間差のせいで、ここにもDestroy入れないとつむ
        }

    }

    [PunRPC]
    public void Damaged(int amount)
    {
        hp_current -= amount;

    }

    // When this is destroyed;
    [PunRPC]
    public void RPCDestroy()
    {
        Destroy(this.gameObject);

    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
        }
        else
        {
        }
    }
}
