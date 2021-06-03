# Phantom Limb Pain - VR 
This repo is intended for virtual reality research at Rhodes College. See the menu below for more information.

- [Build Settings](#build-settings)
- [Pull Requests](#pull-requests)
- [Compiling to Oculus](#oculus)
- [Animation Rigging](#animation-rigging)
- [VR Rig](#vr-rig)




### Build Settings
- launch in Unity version 2020.3.9f1
- Run on Android platform
- Texture Compression: ASTC

### Pull Requests
Before you can request the project code on your local device, you must first fork the project to your Github account. You can do this by clicking the fork button on the top right of the repository. 

Next, you will clone the project. Click on the green Clone button, and copy the link. Open your computer's terminal and type 
```
  git clone https://github.com/[USERNAME]/Phantom_Limb_Pain.git. 
```
You should now have the project on your local device. 

### Oculus
Plug in the Oculus device using the USBC cable, plugging one end into the Oculus and one end into the computer. Once dev settings are enabled and the Project is on your local device, go to file > Build and Run. You can now find the App in the Oculus under APPS > Unknown Sources > Com.RhodesCollege.PhantomLimb. You can change the name under Edit > Player Settings > Player. 

### Animation Rigging
To acheive inverse kinematics, I used the animation rigging asset from the Unity registry. I pulled the moving animations from [mixamo](https://www.mixamo.com/#/?page=1&query=walk) and imported them into my project. To set up the animation rig, [Valem's VR Body series](https://www.youtube.com/watch?v=Wk2_MtYSPaM&list=RDCMUCPJlesN59MzHPPCp0Lg8sLw&index=1) was extremely helpful. 

### VR Rig
The inverse kinematics/rig scripts are compatible with any VR Device and Camera Rig. Simply apply the correct rig components to the VR targets in the VR Rig script. 

Coded by London Bielicke. For more information contact me at bielm-24@rhodes.edu.
