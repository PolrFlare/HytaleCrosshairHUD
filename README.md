# HytaleCrosshairHUD
A simple Windows tool for replacing Hytale’s crosshair reticles.

## Showcase
[![Mod showcase](https://img.youtube.com/vi/T1DmtRZMh6o/0.jpg)](https://www.youtube.com/watch?v=T1DmtRZMh6o)

## What this does

Hytale stores its game assets inside an `Assets.zip`.  
Directly modifying files inside this zip causes Hytale to detect the game as **tampered**.

This tool:

- Safely extracts the `Assets` folder
- Lets you replace Hytale’s crosshair PNGs
- Applies changes without triggering asset integrity issues

## Reticles supported

Hytale uses two main crosshairs:

- **Default reticle** (`Reticle_Default.png`)
- **Melee reticle** (`Reticle_Melee.png`)

Automatically generates:

- `Reticle_Melee_Faded.png` (50% opacity)
- `Reticle_MeleeKill.png` (red kill indicator)

## Platform

- Windows only
- Requires a standard Hytale installation

## Manual method  
*(If the tool doesn’t work or you are not on Windows)*

1. Go to:
C:\Users<you>\AppData\Roaming\Hytale\install\release\package\game\latest

2. If `Assets.zip` exists, extract it so you have an `Assets` folder

3. Edit crosshairs in:
Assets\Common\UI\Crosshairs\

4. Replace the PNG files directly

![alt text](https://raw.githubusercontent.com/PolrFlare/HytaleCrosshairHUD/refs/heads/main/images/image1.png)
