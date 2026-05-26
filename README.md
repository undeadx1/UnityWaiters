# Waiters

Waiters is a utility class for Unity that provides optimized and reusable coroutine wait operations.

## Features

- Cached `WaitForSeconds` and `WaitForSecondsRealtime` objects for improved performance
- Efficient memory usage
- Randomized wait times with configurable cache precision
- Manual cache clearing when cached wait intervals are no longer needed

## Usage

```csharp
// Wait for a specified number of seconds
yield return Waiters.Wait(1.5f);

// Wait for a specified number of real-time seconds
yield return Waiters.WaitRealtime(2.0f);

// Wait for a random time between min and max seconds
yield return Waiters.WaitRandom(1.0f, 3.0f);

// Wait for a random time using 0.25 second cache buckets
yield return Waiters.WaitRandom(1.0f, 3.0f, 0.25f);

// Clear cached wait intervals
Waiters.ClearCache();

// Wait until the next fixed update
yield return Waiters.FixedUpdate;

// Wait until the end of the frame
yield return Waiters.EndOfFrame;
```

## Installation

1. Copy the `Waiters.cs` file into your Unity project's Assets folder.
2. Use the `Waiters` class in your coroutines for optimized wait operations.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
