# Unity3D Apartment Tour

A first-person interactive apartment walkthrough built with Unity, featuring VR-inspired interaction mechanics, dynamic lighting, and real-time color customization.

## Project Overview

This project demonstrates 3D modeling and interactive gameplay development skills through a VR-like house walking simulation. All 3D assets and models were created in Blender.

## Features

### Core Mechanics

- **First-Person Movement**: WASD movement with mouse look and smooth camera controls
- **Object Interaction**: Left-click interaction system with context-sensitive crosshair
- **Grab System**: Physics-based grabbing for doors, cabinets, and drawers
- **Dynamic Lighting**: Motion sensor lights with automatic timeout
- **Color Customization**: Real-time material color picker UI

### Interaction Types

| Type | Description | Example Objects |
|------|-------------|-----------------|
| `grab` | Physics-based object manipulation | Doors, drawers, cabinet handles |
| `recolor` | Opens color picker UI for material customization | Paintable surfaces |
| `turn on`/`turn off` | Toggle interaction for lights | Light switches |

## Project Structure

```
Assets/
├── Prefabs/              # Reusable game objects
│   ├── Door.prefab       # Interactive door with handle
│   ├── Drawer.prefab     # Physics-based drawer
│   ├── CabinetDoor.prefab# Cabinet door prefab
│   ├── House.fbx         # Main 3D model import
│   ├── Player.prefab     # Player controller prefab
│   └── Materials/        # Material assets (Fabric, Glass, Metal, Wood, etc.)
├── Scenes/
│   ├── Main.unity        # Main apartment scene
│   └── SampleScene.unity # Development/test scene
├── Scripts/              # C# game logic
│   ├── PlayerController.cs    # FPS movement and interaction
│   ├── IInteractable.cs       # Interaction interface
│   ├── Handle.cs              # Grab physics handler
│   ├── DoorHandleFollow.cs    # Handle follow-mechanic
│   ├── Colorable.cs           # Color-changing objects
│   ├── ColorMenu.cs           # RGB color picker UI
│   ├── LightSwitch.cs         # Light toggle interaction
│   ├── MotionSensorLight.cs   # Proximity-based lighting
│   ├── Crosshair.cs           # Context-sensitive crosshair UI
│   └── EventSystem.cs         # Global event manager
└── TutorialInfo/         # Unity starter assets
```

## Scripts Overview

### PlayerController.cs
First-person controller with:
- Smooth mouse look with sensitivity control
- WASD movement with acceleration smoothing
- Raycast-based interaction system
- Mode switching (roam vs color-edit modes)

### IInteractable.cs
Interface for all interactive objects:
```csharp
public interface IInteractable 
{
    string type { get; set; }
    void Interact(Transform interactor);
}
```

### Handle.cs
Implements physics-based grabbing:
- Attaches object to player on interaction
- Enforces maximum grab distance (0.6 units)
- Releases on mouse up or distance threshold

### EventSystem.cs
Singleton event manager for decoupled communication:
- `roamMode` - Return to free movement
- `colorMode` - Enter color editing mode
- `colorUpdated` - Broadcast color changes
- `crosshairUpdated` - Update interaction hints

## Controls

| Input | Action |
|-------|--------|
| W, A, S, D | Move forward/left/back/right |
| Mouse | Look around |
| Left Click | Interact with objects |
| Escape | Release cursor (when in UI mode) |

## Technical Details

- **Unity Version**: Check `.unity-version` or open in Unity Hub
- **Render Pipeline**: Built-in Render Pipeline
- **Physics**: Unity PhysX with CharacterController
- **UI**: TextMeshPro for crosshair and color menu

## Installation

1. Clone or download this repository
2. Open the project in Unity Hub
3. Open the `Main` scene from `Assets/Scenes/`
4. Press Play to run

## Build

A playable build is available for download:
[Google Drive Build Link](https://drive.google.com/drive/folders/1Aw0HWx4HupxjlxLvTjUQnUB9aC9DbUsH?usp=sharing)

### Architecture
- Event-driven design for loose coupling between systems
- All interactions go through the `IInteractable` interface
- Player controller manages mode states (roam vs color-edit)

## Credits

**Developer**: Tolga Rodoplu  
**3D Modeling**: All assets created in Blender by the author  
**Purpose**: Internship portfolio project to demonstrate 3D modeling and Unity development skills
