# Ubiq RPM Latency test
## Overview
In this repository, I have created a social VR scene using networking library [Ubiq](https://github.com/UCL-VR/ubiq) to facilitate virtual meetings and events. It also uses Ready Player Me (Half body) avatars [implementation](https://github.com/UCL-VR/ubiq-avatars-readyplayerme) by UCL-VR.
The primary purpose of this project is to serve as a platform for conducting latency tests in VR environments (Work in progress).

## Getting Started
The main scene is located at Scenes/Ubiq_office
This version of a project is configured to run on a server provided by Nexus allowing it to work "out of the box"
To run it on a local server, please follow these [instructions](https://ucl-vr.github.io/ubiq/serversetup/). Note, that you will need to clone the repository first https://github.com/UCL-VR/ubiq
After that, follow these steps: 
1. Write the following in the Social Network Scene GameObject:

![image](https://github.com/sultanov0372/Ubiq_RPM_Latency_test/assets/60095737/435ffa1d-b0b1-4432-9ecc-f037de2403af)

2. On other clients, instead of `localhost`, write the IP address of the host. (The host and clients should be on the same local network.)

## Usage
You can choose one of three avatars from the catalogue  located at `Prefabs/AvatarCatalogue1`. To change your avatar, replace `avatarPrefab` on the 'AvatarManager' with `RPM-Avatar2/3_Male`
You can also create your own avatar using [Web interface](https://demo.readyplayer.me/avatar). Note before you start that this package currently only supports `HalfBody` avatars. 
An url is provided once the model has been created. Open one of the RPM-Avatar prefabs (Prefabs folder), under `RPM-body` in `Ubiq Ready Player Me Loader` component paste your new avatar link. If you make a copy of a prefab, don't forget to add your new avatar to the catalogue.
More information [here](https://github.com/UCL-VR/ubiq-avatars-readyplayerme).

## Useful links
- [Ubiq docs](https://ucl-vr.github.io/ubiq/)
- [Environment](https://assetstore.unity.com/packages/3d/environments/urban/pixel-modern-office-extras-225670)
- [Ready Player Me avaters](https://readyplayer.me/)
