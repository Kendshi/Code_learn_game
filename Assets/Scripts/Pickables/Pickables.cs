using UnityEngine;

public class Pickables : ResetBase
{
    [SerializeField] private PickableType type;

    [SerializeField] private Item item;

    public PickableType Type => type;

    public Item Item => item;
}
