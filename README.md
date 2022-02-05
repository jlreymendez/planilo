![planilo](https://user-images.githubusercontent.com/1077394/91163953-be4d8d80-e6a4-11ea-9f86-127a6374235d.png)

A set of tools for designing AI in a visual node editor on unity. Use for:
* Behavior Trees.
* Finite State Machines.
* Implement your own AI graphs.

## Key features
* A visual editor for Behavior Trees, Finite State Machines and the basis to create other types of AI tools.
* AI graphs implemented as reusable scriptable objects, same instance can be run by multiple GameObjects.
* Share data between the Scene an your Behavior Tree using Blackboard variables.
* Ready implemented examples to use as guidance.
* See highlighted nodes in runtime to understand how your AI graphs are running.
* Modularize your AI graphs and execute them as part of nodes of other AI graphs.
* See more in [documentation](https://github.com/jlreymendez/planilo/wiki)

## Road to v0.2.0
As I'm not actively using planilo on any project I have stopped development of planilo for the time being. 
I have merged the development branch to master, hoping to encourage people to stop using v0.1.0 which in my opinion has major design flaws.
The only thing that's stopping the release of v0.2.0 is that the samples have bugs coming from either Unity's Assets v2 or xNode. 
This was the last thing to convince me that if I ever continue developing this tool I will need to drop xNode to gain control over important parts 
of the tool.
 
### What is changing?
* **Separation of concerns.** Using xNode as a serialization and behaviour builder tool only. Making no assumptions of how runtime execution should be.
* Interface blackboards for behaviours instead of dictionaries.
* Behaviour tree overhaul with new composite nodes Active Selector and Active Sequencer.

## Things left to investigate
* Jobified versions of the AI behaviour. 
* Utility based Behaviour Tree.

## v0.1.0
The initial release of planilo had some design flaws which would cause:  
* Bugs difficult to track.
* Less control over the flow execution for the user.
* Performance hits due to allocations while using dictionaries for the blackboard variables.

If you still want to have access to planilo v0.1.0 you can find it in the releases page [v0.1.0](https://github.com/jlreymendez/planilo/releases/tag/untagged-e47bab49a17a75565867)

## Installing with Unity Package Manager
*(Requires Unity version 2019.1 or above)*

To install this project as a [Git dependency](https://docs.unity3d.com/Manual/upm-git.html) using the Unity Package Manager,
add the following line to your project's `manifest.json`:

```
"com.github.jlreymendez.planilo": "https://github.com/jlreymendez/planilo.git"
```
NOTE: This will also install the dependencies xNode under the Planilo path.

You will need to have Git installed and available in your system's PATH.

## Acknowledgements:
* [xNode by Siccity](https://github.com/Siccity/xNode)
* [Game-icons.net and Delapouite](https://game-icons.net/1x1/delapouite/choice.html)
