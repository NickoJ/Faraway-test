# Dinorunner

All visualization using MVC pattern.
Game itself isn't binded to Unity as much as possible (even ticks are sent there using PlayerLoop, not MonoBewhaviour update methods).
All assets are in addressable. Game is starting via GameInit class.
Project is separated to three main assemblies.
Engine: initialization and binding unity and the game core.
Core: Core mechanic of the game.
Scripts: Unity part.

All dependencies are sent via service locator (but to be honest there was no need in that).

I didn't use unity physics and colliders because there's no need for that, game is too simple. Core gameplay works via systems (ECS-like but with normal model objects).
Object pools for classes and structs are used everywhere where is possible.

## Libraries:
* Addressables;
* UniTask.
