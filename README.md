# ToyTopDownShooter

### YOU CANT DIE :( BUT YOU CAN KILL! :)

## What was done:

Assets: The project should have at least 2 imported assets. [X] (Blood Splatter randomly selected, enemies change sprite on death)
1 should be a player character, and the rest can be enemies or hazards. [X] (Technically the protag and enemies have the same sprite, I forgot to change it and it
is too late for that but I have plenty of different sprites in there that change and spawn on damage and death of enemies)
Have animations for at least the player. [X] (I rotate the player because its a top down shooter)
If you’d like to also import an asset/texture pack for scenery and environmental things, feel free. [X] (Used Tiled)

Environment: Ideally, have a basic environment with a few “rooms” or an equivalent. [X] YES 2 levels
They should be more interesting than the simple “rooms” in the NavMesh videos, for reference. [X] Walk through big doors to get to next level

Player: The player should be able to navigate the environment. [X]Yes
The camera can either follow the player or be a top-down view. [X] Yes, camera follows
The player should be able to attack the enemies with an animation for attacking. [X] Yes, spawn bullets, enemies also attack you but they cant kill you at the moment
you can kill them though

You can attach a collider to the player and position it on their weapon to detect collisions with enemies (up to you what to do when a collision happens). [X] Yes, detecting bullet collisions and killing enemies based on it
Enemies: The enemies should wander the environment with a NavMesh. [X] YES but it is a little janky
Up to you how you do it, as long as it seems like random “roaming” movement. [~] They dont really roam until they detect you, but they will chase you after
An extra (not required) challenge could be to have the enemies detect when the player is in range, and switch to an attack mode.[X] Yeah I did this instead
