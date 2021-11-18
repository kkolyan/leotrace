# About

Fork of [LeoECS](https://github.com/Leopotam/ecs) with the goal of advanced debugging. It doesn't change core behavior, but provides some debugging features.

# Features

* systems order analysis

# Production use

That's intended to be used only for temporary debugging sessions and switched back to original LeoECS as soon as it gave results.

# Perspective

## Nearest plans
1. try it on pet project
2. introduce hinting attributes to allow:
   * false-negative alerts supression
   * more advanced checks
   * init-time or even compile-time checks

## Further plans
(f this fork proves itself useful on my pet-project)
1. cover all debugging functionality with preprocessor conditions so this library could be used in production.
2. do the same fork for [LeoECS Lite](https://github.com/Leopotam/ecslite)
