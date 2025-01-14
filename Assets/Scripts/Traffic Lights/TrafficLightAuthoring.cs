using UnityEngine;
using Unity.Entities;


public class TrafficLightAuthoring : MonoBehaviour
{
    public LaneAuthoring Lane;
}

public class TrafficLightBaker : Baker<TrafficLightAuthoring>
{
    public override void Bake(TrafficLightAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new TrafficLight
        {
            AssociatedLane = GetEntity(authoring.Lane, TransformUsageFlags.None)
        });
    }
}