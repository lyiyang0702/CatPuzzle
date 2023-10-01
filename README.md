# CatPuzzle Dev Log
## Important Notes:
Update IMoveable IsInContainer boolean check. Currently, it only checks if moveable overlaps the container but does not check if it is completed inside the container. A detection frame outside the container can help fix this.
## Life Time Manager 
Life Time Manager Has two parts: ```LifeTimeManager``` and ```LifeTimeBroadCaster```.
Life Time Manager Handles all the Actual Unity Logic of the game control Flow
+ Next Level - Note, All the level should ordered in the correct linear order to use this function. Otherwise, an alternative function is needed
+ Hard Reset - Arcade Reset Button functionality. Lead Directly to the index scene. Note: Updated needed when the new dontDestroyOnLoad component is defined.
+ Quit - Quit Application

All the functionality is revoked through events contained in ```LifeTimeBroadCaster```.

**Caution!** ```LifeTimeBroadCaster``` is a Static Class that contains static functions that can be called anywhere in the project. Avoid Using it in non-manager scripts
## IMoveable
IMoveable is an interface for moveables. It defines universal properties of moveables to make the life of game manager easier when we have more types of moveables later.
Currently IMoveable's Interfaces are:
+ public bool IsInContainer(). It tells the game manager if this moveable object is in the container. **Note** Further Action Needed. Current implementation only checks if the moveable overlaps the container but doesn't check if the moveable is completely inside the container.
  
