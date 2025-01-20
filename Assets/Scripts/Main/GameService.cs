using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public MapService MapService { get; private set; }

    public WaveService waveService { get; private set; }
    public EventService EventService { get; private set; }



    [SerializeField] private UIService uIService;
    public UIService UIService => uIService;

    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;

    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

    private Grid currentGrid;
    private Tilemap currentTileMap;
    private MapData currentMapData;
    private SpriteRenderer tileOverlay;



    private void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject , audioEffects , backgroundMusic);
        MapService = new MapService(mapScriptableObject);
        waveService = new WaveService(waveScriptableObject);
        EventService = new EventService();

    }

    private void Update()
    {
        playerService.Update();
    }
}
