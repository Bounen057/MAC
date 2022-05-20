using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class DroppedItem : MonoBehaviourPunCallbacks
{
    public Item item;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<Inventory>();
    }

    void Update()
    {

    }

    // no-complete
    public void Pick(int player_id)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == player_id)
        {
            if (inventory.give(item))
            {
                Debug.Log(player_id.ToString() + " got the item!");
                photonView.RPC(nameof(RPCDestroy), RpcTarget.AllBufferedViaServer);
            }
        }
    }

    [PunRPC]
    public void RPCDestroy()
    {
        Destroy(this.gameObject);
    }
}
