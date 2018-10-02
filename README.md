# DataDragonSharp

C# Wrapper for the [DataDragon](https://developer.riotgames.com/static-data.html)

# Installation

1. Clone this repository.
2. Add [DataDragonSharp](https://github.com/Marimoiro/DataDragonSharp/tree/master/DataDragonSharp) project to your project

# Usage

## Load from local files

1. Download dragontail from Riot Developer Portal. (Download Url: https://ddragon.leagueoflegends.com/cdn/dragontail-8.19.1.tgz )
2. Expand it.

Instantiate a DataDragonLoader

```
    // The paramete is your local datadragon path 
    DataDragonLoader dataDragonLoader = new DataDragonLoader("ddragon/8.19.1");
```

To load a champion

```
    var akali = dataDragonLoader.LoadChampion("Akali");
    
    // can access champion's parameters
    Console.WriteLine(akali.Name);
    Console.WriteLine(akali.Blurb);
```

To load all champions

```
    var data = dataDragonLoader.LoadChampionFullSet();
    var akali = data.Data["Akali"];

```

### Other Methods

Sorry. I have no document. so, reference from [Test](https://github.com/Marimoiro/DataDragonSharp/tree/master/DataDragonSharpTest)

## Request to DDragon CDN

You can request directly from CDN using DataDragonClient.
However, it have not any caching.

```
          using (var client = new DataDragonClient("8.19.1"))
            {
                var akali = await client.RequestChampionAsync("Akali");
            }
```
