using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] ItemType _acceptedType;

    public void Accept(ItemData itemData)
    {
        if (itemData.ItemType == _acceptedType)
        {
            // Bon objet
        }
        else
        {
            // Mauvais objet
        }
    }
}