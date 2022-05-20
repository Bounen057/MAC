using System.Collections;
using Photon.Pun; 
using System.Collections.Generic;
using UnityEngine;

public class DroppedItemManager : MonoBehaviourPunCallbacks
{
    public void drop_item(Item item, Vector3 position)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject obj = PhotonNetwork.InstantiateRoomObject("DroppedModel/" + new IdToName().GetName(item.id), position, Quaternion.identity);
            obj.GetComponent<DroppedItem>().item = item;
        }
    }

    public void drop_id(int id, Vector3 position)
    {
        if (PhotonNetwork.IsMasterClient)
        {

            Debug.Log("DroppedModel / " + new IdToName().GetName(id));

            GameObject obj = PhotonNetwork.InstantiateRoomObject("DroppedModel/" + new IdToName().GetName(id), position, Quaternion.identity);
            
            obj.GetComponent<DroppedItem>().item = new Item(id, null, 1);
        }
    }
}
