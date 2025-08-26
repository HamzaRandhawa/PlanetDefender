Salient features of the Development:

1. Everything is tried to be developed from scratch (like snake using spheres) to show the development of mechanics more effectively.

2. All Objects are pooled using prefabs, giving Reusability with control and flexibility, enabling multiple spawning of objects (like explosion VFX and SFX) at a time.

3. Coding is done respecting SOLID principles.

4. Unity Action/Events are used to enable event-based logic as opposed to checking of logic(like input or explosion occurrence) every frame.

5. Added different types of balls (Fireballs & Iceballs) using inheritance, easily more extensible.

6. Bars used in UI to display Earth Health and the time remaining of the round.

7. As said in the design document, Ball has to strike Snake segments, which is surrounded by Snake segments, in order to nullify the fireball.

8. To Change variables like Snake Speed, Fireballs spawning interval, change variables on the GameManager and SnakeManager scripts attached to the gameObjects of the same name.
 
9. To change balls (Fireballs & Iceballs) speed, damage and rewards, change values on the scripts "Fireball" and "Iceball" attached to the prefabs, respectively.

10. After initialization, no object is instantiated; all game objects (Fireballs, Iceballs, Explosion VFX, Explosion SFX, Ball interception SFX, Snake Segments) are pooled using one general object pooler, and instantiate and destroy calls are avoided.

11. Play the Game using 2048x2048 aspect Ratio in Editor Settings.
