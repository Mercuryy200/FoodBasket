using NUnit.Framework;
using UnityEditor;
using UnityEngine;


public class EditModeTests
{
    //Test de configuration du prefab de la bombe
    [Test]
    public void BombPrefab_HasRequiredComponents()
    {
        GameObject bombPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Bomb.prefab");
        Assert.IsNotNull(bombPrefab, "Le prefab bombPrefab est null");

        var controller = bombPrefab.GetComponent<Target>();
        Assert.IsNotNull(controller, "Aucun component Target n'a été trouvé");

        Assert.IsNotNull(bombPrefab.GetComponent<Rigidbody>(),
            "La Bombe ne possède pas de RigidBody component");
        var bombBoxCollider = bombPrefab.GetComponent<BoxCollider>();
        Assert.IsNotNull(bombBoxCollider,
            "La Bombe ne possède pas de Collider component");
        Assert.IsTrue(bombBoxCollider.isTrigger, "Le trigger est mis a false");
        
        float bombExpectedPontValue = -20.0f;
        Assert.AreEqual(controller.pointValue, bombExpectedPontValue, "Les point ne valent pas -20.0f");
        Assert.IsNotNull(controller.collisionSound, "Il n'y a pas de collisionSound assigné à la bombe");
        Assert.IsNotNull(controller.explosionParticle, "Il n'y a pas de explosionParticle assigné à la bombe");
        Assert.IsNotNull(bombPrefab.GetComponent<AudioSource>(), "Aucun component AudioSource n'a été trouvé sur la bombe");
    }
}
