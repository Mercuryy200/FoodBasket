using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayModeTests
{
    // 3 Test qui couvre le PlayerController avec NSubStitute
    // Test 1 : Vérifie le mouvement vers la droite (Input +1)
    [UnityTest]
    public IEnumerator Player_MovesRight_WhenInputIsPositive()
    {
        // Arrange
        GameObject player = new GameObject();
        PlayerController controller = player.AddComponent<PlayerController>();
        Vector3 initialPosition = player.transform.position;
        var mockInput = Substitute.For<IPlayerInput>();
        mockInput.HorizontalInput.Returns(1.0f);
        controller.PlayerInput = mockInput;

        // Act
        yield return null;

        // Assert
        Assert.IsTrue(
            player.transform.position.x > initialPosition.x,
            "Le Player n'a pas bouger en positif sur l'axe des x par rapport à sa position initiale"
        );
    }

    // Test 2 : Vérifie le mouvement vers la gauche (Input -1)
    [UnityTest]
    public IEnumerator Player_MovesLeft_WhenInputIsNegative()
    {
        // Arrange
        GameObject player = new GameObject();
        PlayerController controller = player.AddComponent<PlayerController>();

        var mockInput = Substitute.For<IPlayerInput>();
        mockInput.HorizontalInput.Returns(-1.0f);
        controller.PlayerInput = mockInput;
        var initialPosition = player.transform.position;
        //Act
        yield return null;

        // Assert
        Assert.IsTrue(
            player.transform.position.x < initialPosition.x,
            "Le Player n'a pas bouger en négatif sur l'axe des x par rapport à sa position initiale"
        );
    }

    // Test 3 : Vérifie l'absence de mouvement (Input 0)
    [UnityTest]
    public IEnumerator Player_DoesNotMove_WhenInputIsZero()
    {
        // Arrange
        GameObject player = new GameObject();
        PlayerController controller = player.AddComponent<PlayerController>();
        var mockInput = Substitute.For<IPlayerInput>();
        mockInput.HorizontalInput.Returns(0.0f);
        controller.PlayerInput = mockInput;
        var initialPosition = player.transform.position;

        // Act
        yield return null;

        // Assert
        Assert.AreEqual(
            initialPosition.x,
            player.transform.position.x,
            "La position initiale et finale ne sont pas les même"
        );
    }

    //Test de jeu pour les effets sonores de la scene
    [UnityTest]
    public IEnumerator MainScene_LoadsCorrectly_AndComponentsExist()
    {
        const string scenePath = "Assets/Scenes/FruitBasket.unity";
        var op = SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Single);

        while (!op.isDone)
        {
            yield return null;
        }

        var gameManagerObj = GameObject.Find("Game Manager");
        Assert.IsNotNull(gameManagerObj, "Le Game Manager est introuvable dans la scène.");

        var gmScript = gameManagerObj.GetComponent<GameManager>();
        Assert.IsNotNull(
            gmScript,
            "Le script GameManager est manquant sur le Game Manager object."
        );

        var player = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(player, "Le Player est introuvable.");

        var playerCtrl = player.GetComponent<PlayerController>();
        Assert.IsNotNull(playerCtrl, "Le script PlayerController est manquant sur le Player.");

        //Vérifie qu'il y a bien un Audio Source Component et une caméra
        var mainCamera = GameObject.FindWithTag("MainCamera");
        Assert.IsNotNull(mainCamera, "La Camera est introuvable dans la scène.");

        var audioSource = mainCamera.GetComponent<AudioSource>();
        Assert.IsNotNull(audioSource, "Il manque l'AudioSource sur la caméra principale.");
        //Vérifie qu'il y a une musique ambiante en fond de scène.
        Assert.IsTrue(audioSource.isPlaying, "Il n'y a pas de son qui joue sur la camera");

        // Vérifie qu'un target spawn lorsque le jeu commence
        gmScript.StartGame();

        yield return new WaitForSeconds(3.0f);

        //https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Object.FindAnyObjectByType.html
        var target = Object.FindAnyObjectByType<Target>();
        Assert.IsNotNull(target, "Aucun target n'a spawn après 3 secondes (ni Good, ni Bad).");

        var targetController = target.GetComponent<Target>();
        Assert.IsNotNull(targetController, "Le script Target est manquant sur le Target.");
        Assert.IsNotNull(
            targetController.collisionSound,
            "Aucun son de collision n'est assigné au target"
        );
        Assert.IsNotNull(
            target.GetComponent<AudioSource>(),
            "Aucun Component Audio Source n'a été trouvé sur le Target "
        );
        // Vérifier que le son ne joue pas si le target n'entre pas en collision
        Assert.IsFalse(
            target.GetComponent<AudioSource>().isPlaying,
            "Le audiosource component sur le target is playing"
        );
    }
}
