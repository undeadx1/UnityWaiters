# Unity Waiters
The Unity Waiters library is a C# utility class designed to manage coroutine waiters in Unity3D. It is aimed at preventing unnecessary memory allocations during gameplay by caching WaitForSeconds and WaitForSecondsRealtime instances, which are frequently used in coroutines.

# Features
Stores WaitForEndOfFrame and WaitForFixedUpdate objects to use anywhere in your code.
Caches WaitForSeconds and WaitForSecondsRealtime instances, based on a unique combination of wait time and instance ID.
Provides WaitRandom method that returns a new WaitForSeconds object with a random wait time within a specified range.

# Usage 
//in the mono class
..
yield return Waiters.Wait(sec, GetInstanceID()); 
..

# Benefits
Using this class can help to avoid unnecessary memory allocations in your game, thus helping to reduce garbage collection events, and potentially improving overall performance.

# License
This project is licensed under the terms of the MIT license. For more information, please see the LICENSE file.
