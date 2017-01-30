Particle detection - image processing
======================
author: Tereza Štanglová

Particles' generator
-------------------
This is the first step of whole process. You can specify the number of particles. The particles' sizes are random, between 10 and 25 pixels. The particles' positions are also random. The particles can overlap each other. When particles overlap they seems to look like one. The final image is an input for particle detection.

<p align="center">
  <img src="https://cloud.githubusercontent.com/assets/5311408/22424552/3b43aa7e-e6f7-11e6-8109-41dfff52701b.png">
</p>

Area
----
Algorithm:

1. Analyze the image line by line and search for red points (pixels).
2. Check the area around the red point.
3. If there is another red point in the area around, add its coordinates to the stack. Change the color of the current point to the color of background (black in this case).
4. Is the stack empty?
  - No - Pop the first element and go to 2.
  - Yes - End.

Perimeter
---------
At this stage we know the coordinates of all points of each particle. This knowledge can be used for detection of internal boundaries of particles (perimeter). Internal boundary can be detect by erosion - morphological transformation. Internal boundary is defined by: 

*H<sub>r</sub> = A \ (A &#8854; B)*,

where *A* is a matrix of points for each particle, *B* is a kernel and &#8854; is a vector difference.

<p align="center">
  <img src="https://cloud.githubusercontent.com/assets/5311408/22426360/3e0669b0-e6ff-11e6-8fb2-9d24874422ec.PNG">
  <br>
  Kernel for erosion.
</p>

The course of erosion illustrates the following figures.

[]() | []()
------------- | ---------------
![alt tag]() <br> 1. Original image. | ![alt tag]() <br> 2. Kernel application on (1;1) point.
![alt tag]() <br> 3. . | ![alt tag]() <br> 4. .


