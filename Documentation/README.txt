
Max Payne 2 - Mobile (iOS) - Unity Project Skeleton
--------------------------------------------------

What's included:
- Folder structure for a Unity project (Assets/...)
- C# scripts for player movement, shooting, bullet time, enemy AI, health, and simple mobile UI (joystick + buttons)
- Documentation folder with steps to complete the project
- Placeholder image (screenshot) to use for prototyping

Important notes:
- This is a skeleton project (scripts + folders). You must import your Mixamo character (FBX for Unity) and assign Animator, model, and animations.
- Bullet prefab requires a Rigidbody + Collider and the Bullet.cs script.
- Player GameObject should have CharacterController component and the PlayerController, PlayerShooting, and Health scripts attached as needed.
- For iOS build: Open Unity > Switch Platform to iOS (File -> Build Settings). Use Metal as Graphics API. Use IL2CPP for Scripting Backend in Player Settings.
- To build to device: you'll need a Mac with Xcode. For device provisioning, an Apple Developer account may be needed for real device testing; Simulator or local testing possible via Xcode.

Setup steps (short):
1. Open Unity (2022 LTS / 2023 LTS recommended). Create new 3D project.
2. Copy the 'Assets' folder from this package into your project's Assets/ (or open this folder as project root).
3. Import Cinemachine (Package Manager) and optionally Input System.
4. Import your Mixamo character (FBX for Unity) + animations.
5. Create a Player GameObject and attach CharacterController, PlayerController, PlayerShooting, Health and set references (camera, joystick, firePoint, bulletPrefab, audioSource).
6. Create UI Canvas, add joystick and two buttons; hook MobileButtons script to buttons and assign player shooting reference.
7. Create Bullet prefab (Sphere or small object) with Collider + Rigidbody, attach Bullet.cs.
8. Create Enemy prefab with CharacterController, EnemyAI (set player reference), Health, and firePoint child transform.
9. Set up Cinemachine virtual camera to follow the player.
10. Test in Editor. Adjust Time.fixedDeltaTime if needed during bullet time experiments.

Files:
- Scripts: Joystick.cs, MobileButtons.cs, PlayerController.cs, PlayerShooting.cs, Bullet.cs, Health.cs, EnemyAI.cs
- Documentation/README.txt (this file)

If you want, I can produce a follow-up ZIP that includes example Unity scene files (.unity) and simple prefabs — but those are more fragile since Unity's meta files / versioning matter. This skeleton is intentionally simple and guaranteed to import reliably across Unity versions.

---
Credits & Licenses:
- Mixamo assets are free for use; please check Mixamo's licensing if you redistribute packaged models.
- The scripts here are provided under MIT-like terms for your use.


---
New: Prefabs added in Assets/Prefabs (Player.prefab, Enemy.prefab, Bullet.prefab). Drag & Drop into scene to use.


---
Upgrade Added:
1. HUDController.cs (attach to Canvas with Slider+Text).
2. WaveSpawner.cs (attach to empty GameObject, assign Enemy prefab + spawn points).
