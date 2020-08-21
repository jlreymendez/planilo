### Planilo (based on xNode)
![Planilo](https://i.imgur.com/NpPXtBH.png)

A set of tools for designing AI in a visual node editor on unity. Use for:
* Behavior Trees.
* Finite State Machines.
* Implement your own AI graphs.

### Key features
* A visual editor for Behavior Trees, Finite State Machines and the basis to create other types of AI tools.
* AI graphs implemented as reusable scriptable objects, same instance can be run by multiple GameObjects.
* Share data between the Scene an your Behavior Tree using Blackboard variables.
* Ready implemented examples to use as guidance.
* See highlighted nodes in runtime to understand how your AI graphs are running.
* Modularize your AI graphs and execute them as part of nodes of other AI graphs.
* See more in [documentation](https://github.com/jlreymendez/planilo/wiki)

### Installing with Unity Package Manager
*(Requires Unity version 2018.3.0b7  or above)*

To install this project as a [Git dependency](https://docs.unity3d.com/Manual/upm-git.html) using the Unity Package Manager,
add the following line to your project's `manifest.json`:

```
"com.github.jlreymendez.planilo": "https://github.com/jlreymendez/planilo.git"
```
NOTE: This will also install the dependencies xNode and Unity-SerializableDictionary under the Planilo path.

You will need to have Git installed and available in your system's PATH.

### Using (Thanks to):
* [xNode by Siccity](https://github.com/Siccity/xNode)
* [Unity-SerializableDictionary by azixMcAze](https://github.com/azixMcAze/Unity-SerializableDictionary)
