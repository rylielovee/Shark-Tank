# Academic Project: Shark Tank

You are a hungry shark trying eat enough fish to be the biggest shark in the ocean. But watch out for other sharks, jellyfish, and pufferfish!

## Simulation/Game Design

- This is a 2D interactive simulation/game made in Unity of an underwater virtual world populated with NPC aquatic animals.
- The purpose of this project was to demonstrate an understanding of forces and steering behaviors, including flee, seek, flocking, and obstacle avoidance.
- This was coded without the use of Unity’s built in collision methods.
- All art was created by me.

## Controls

- Movement: WASD
- Player grows in size when eating fish
- Player shrinks when colliding with other sharks, jellyfish, or pufferfish

## NPC Behaviors

- Sharks: seeks player when in range, otherwise wanders
- Fish: flees from player when in range, otherwise uses flocking behaviors (seperation, cohesion, and alignment)
- Pufferfish: stationary, puffs up when in range of player
- Jellyfish: wanders
- All have the behavior to stay within bounds
