# 🔮 3D Matching Game with Score System (Unity)

## 📖 Project Description
This project is a **3D Matching Game** developed using Unity. Players earn points by matching objects of the same type, while a countdown timer runs. Additional features like **Double Score** and **+10 Seconds** add variety and challenge to the gameplay.

---

## 🎮 Demo / Gameplay
You can try the WebGL version of the game here:

👉 [**3D Matching Game - Unity Play**](https://play.unity.com/en/games/c91ff8e2-dbb1-43f5-af36-377ab674bc3a/3d-matching-game)

> No installation needed. Works directly in browser. For best experience, switch to full screen mode.

---

## 🔄 Features
1. **Object Matching Logic**
   - Using the `CheckMatching` script, objects of the same type are destroyed when matched.
   - Incorrect matches can trigger different actions (e.g., objects being thrown).

2. **Static Score System**
   - The score is preserved even if the scene reloads via `GameManager`.
   - The `AddScore(int)` function increases the score upon correct matches.

3. **Countdown Timer**
   - A timer counts down from 30 seconds (`TimerManager` script).
   - When the time runs out, "Game Over" appears and gameplay stops (`Time.timeScale = 0`).

4. **Double Score Button**
   - Can be used **only once** to double the current score.
   - Once clicked, it becomes disabled (`interactable = false`).

5. **+10 Seconds Button**
   - Adds 10 seconds to the timer. Can be used only once.

6. **WebGL Support**
   - Built using Unity with WebGL Build Support enabled.
   - Use `File > Build Settings > WebGL > Switch Platform` to build for web.

---

## 🗂️ Project Structure
- `Scripts/`: Contains C# scripts.
- `Prefabs/`: Game object prefabs (e.g., cubes, cylinders).
- `Scenes/`: Unity scene files.
- `UI/`: Canvas, buttons, and other interface elements.

---

## 🚀 Setup and Run

1. **Unity Version**  
   - Recommended: Unity 2020+ with **WebGL Build Support**.

2. **Download Project**  
   - Clone or download the project folder.
   - Add the folder to Unity Hub using the **Add** button.

3. **Open and Edit**  
   - Open the project in Unity Hub.
   - Navigate to the `Scenes` folder and open the main scene.

4. **Test Gameplay (Play Mode)**
   - Press **Play** in Unity Editor to test.
   - Drag and drop objects, earn points through matching.
   - Use buttons (Double Score, +10 Seconds) to test additional features.

---

## 🛎️ WebGL Build Instructions

1. **Install WebGL Module**
   - Unity Hub → Installs → Select version → Add Modules → WebGL Build Support

2. **Build Settings**
   - Go to `File > Build Settings`
   - Select **WebGL** and click **Switch Platform**
   - Make sure the scene is included in **Scenes in Build**

3. **Build**
   - Click **Build** or **Build and Run**
   - The output (HTML, .data, .wasm) can be tested using a local server (e.g., Python's `http.server`)

---

## 🎮 Gameplay Flow Example

1. **Game Start**
   - Timer starts counting down from 30.
   - Score begins at 0.

2. **Object Matching**
   - Match two identical objects to remove them and gain points.
   - `GameManager` → `AddScore(10);`

3. **Button Usage**
   - **Double Score**: Doubles the score once, then disables itself.
   - **+10 Seconds**: Adds extra 10 seconds to timer (once only).

4. **When Time Runs Out**
   - "Game Over" text appears.
   - Gameplay stops (`Time.timeScale = 0`).

---

## 👨‍💼 Contributors & Development
**Muhammet Enes DEMIRKOL** – Project Developer

> Project is open for contributions. Feel free to extend it with new features such as difficulty levels, online leaderboard, or custom object types.

---

## 📄 License
```text
MIT License

Copyright (c) 2023 ...
Permission is hereby granted, free of charge, to any person obtaining a copy...
```

---
