# Upgrading HDRP from Unity 2019.2 to Unity 2019.3

In the High Definition Render Pipeline (HDRP), some features work differently between major versions of Unity. This document helps you upgrade HDRP from Unity 2019.2 to 2019.3.

<a name="ProceduralSky"></a>

## Procedural Sky

The [Procedural Sky](Override-Procedural-Sky.html) override is deprecated in Unity 2019.3. If your Project uses a procedural sky, you either need to install the override from the samples or switch to the new physically based sky.

To install the Procedural Sky override into a 2019.3 Project:

1. Open your Project in the Unity Editor.
2. Open the Package Manager (**Window > Package Manager**) and click on **High Definition RP**
3. In the **Samples** section, click on the **Import in project** button for the **Procedural Sky** entry. If you have a Scene open that uses the Procedural Sky,  the sky re-appears, but its settings are reset to the default values.
4. To recover your sky settings, you must quit Unity without saving and then re-open your Project.

The last step is important because, if you haven't installed the sample and load a Scene that uses a Procedural Sky, then the Procedural Sky data in the Volume is lost. Unity does not serialize this so you can close and re-open Unity to recover your settings.

## Fog

HDRP has deprecated the Linear Fog, Exponential Fog, Volumetric Fog, and Volumetric Fog Quality overrides in 2019.3 and replaced them with a single [Fog](Override-Fog.html) override. This override acts as an exponential fog with a height component by default and allows you to add additional volumetric fog. To automatically update old fog overrides to the new system, select **Edit > Render Pipeline > Upgrade Fog Volume Components**. Note that it can not safely convert all cases so you may need to upgrade some manually.

## Area Lights

Before Unity 2019.3, HDRP synchronized the width and height of an area [Light](Light-Component.html)'s **Emissive Mesh** with the [localScale](https://docs.unity3d.com/ScriptReference/Transform-localScale.html) of its Transform. From Unity 2019.3, HDRP uses the [lossyScale](https://docs.unity3d.com/ScriptReference/Transform-lossyScale.html) to make the **Emissive Mesh** account for the scale of the parent Transforms. This means that you must resize every area Light in your Unity Project according to the scale of its parent.

## Material Upgrader

When you upgrade your **High Definition RP** package, Unity now upgrades each of your Materials. This means adds a version number the first time it happens so, if a HDRP Shader change occurs, Unity is able to fix your Material so that it still works correctly with the new changes.

To do this, Unity opens a prompt when you begin the upgrade, asking if you want to save your Project. It keeps attempting to upgrade old files until you agree to save your Project.