Particle detection - image processing
======================
author: Tereza Štanglová

Table of contents
------------------

  * [Particles' generator](#particles-generator)
  * [Area](#area)
  * [Perimeter](#perimeter)
  * [Automatic particle counting](#automatic-particle-counting)
    * [Simple method](#simple-method)
    * [Histogram method](#histogram-method)
    * [Method of circular tracks](#method-of-circular-tracks)
  * [Results](#results)
  * [User documentation](#user-documentation)
  * [Easter egg](#easter-egg)

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

where *A* is a matrix of points for each particle, *B* is a kernel (structuring element) and &#8854; is a vector difference.

<p align="center">
  <img src="https://cloud.githubusercontent.com/assets/5311408/22426360/3e0669b0-e6ff-11e6-8fb2-9d24874422ec.PNG">
  <br>
  Kernel for erosion.
</p>

Points of input image are called *foreground* pixels. Each foreground pixel is superimposed by the structuring element on top of the input image. If for *every* pixel in the structuring element, the corresponding pixel in the image underneath is a foreground pixel, then the input pixel is left as it is. Pixels that were removed are a part of the internal boundary.

<table>
<tr>
<td><img src="https://cloud.githubusercontent.com/assets/5311408/22455245/881eeb76-e78b-11e6-8791-d75cd0557085.PNG" /> <br> 1. Original image.</td>
<td><img src="https://cloud.githubusercontent.com/assets/5311408/22455247/8cc52ec4-e78b-11e6-92a0-ac3a93046084.PNG" /> <br> 2. Kernel application on point (1;1).</td>
</tr>
<tr>
<td><img src="https://cloud.githubusercontent.com/assets/5311408/22455252/9133371c-e78b-11e6-8007-ef5093732f78.PNG" /> <br> 3. The result of kernel application.</td>
<td><img src="https://cloud.githubusercontent.com/assets/5311408/22455256/95e8daa0-e78b-11e6-9ca5-9b28952f7f75.PNG" /> <br> 4. Final result of erosion.</td>
</tr>
</table>

Automatic particle counting
---------------------------
The following methods are used for counting particles.

### Simple method
For this method we have to know the number of particles *N* and theirs area *A<sub>i</sub>*. The area of each particle is compared to reference area *A<sub>ref</sub>*. *A<sub>ref</sub>* is the average area of all *A<sub>i</sub>*.

<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22462285/fb7fc448-e7ac-11e6-8621-dee6de2a50e9.PNG"></p>

Estimation of particles' multiplicity *n<sub>i</sub>* is defined by:

<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22462302/08c7fd8c-e7ad-11e6-93fd-499be7950db4.PNG"></p>

Then the estimated number of particles *Particles<sub>single</sub>* can be computed as:

<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22464246/30394fc0-e7b6-11e6-83a7-ebb8f193ae89.PNG"></p>

If *A<sub>i</sub>* area is smaller than *A<sub>ref</sub>* area, then *n<sub>i</sub>=1*. That could be a problem.

Methods for *A<sub>ref</sub>* selection:
  - Median.
  - The upper quartile.
  - The lower quartile.
  
### Histogram method
For this method we have to know the number of particles *N* and theirs area *A<sub>i</sub>*. The next step is to create a histogram of *A<sub>i</sub>* distribution.

<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22459575/7e382698-e7a1-11e6-83c9-191513bdc7b5.PNG"></p>

Algorithm:

1. Divide the histogram into intervals , which will have a size *q*.
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22462736/d0e4729a-e7ae-11e6-8f7a-520ed18c5347.PNG"></p>
2. Select an interval with most particles.
3. Select *A<sub>ref</sub>* as a lower limit or a middle value of interval.
4. For each particle, if *A<sub>i</sub> > A<sub>ref</sub>*, calculate its multiplicity *n<sub>j</sub>*. For smaller particles *n<sub>j</sub>=1*.
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22462746/de56db2a-e7ae-11e6-877b-62cd7e2acfa2.PNG"></p>
5. Then the estimated number of particles *Particles<sub>single</sub>* can be computed as:
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22464230/1e06c3e6-e7b6-11e6-98e0-961b92160a13.PNG"></p>

### Method of circular tracks
For this method we need to define circularity of objects. Circularity is the measure of how closely the shape of an object approaches that of a circle. The higher it goes, the less circular it is. Circularity in descrete space can be defined as:
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22463361/8b916f7e-e7b1-11e6-8b09-6411a77f9b50.PNG"></p>

Algorithm:

1. For each particle calculate *A<sub>i</sub>*, *P<sub>i</sub>* and *VOL<sub>i</sub>* (parameter of circularity) defined by:
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22463610/c4aa8d4e-e7b2-11e6-9ae0-e62b8e53d94e.PNG">,</p>
where *C* is a constant. *C* is approximately *4&#960;*.

2. Calculate a reference area *A<sub>ref</sub>* of particles where *Round(VOL<sub>i</sub>)=1*
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22463733/82ef8b38-e7b3-11e6-8eb0-0941422d3a1c.PNG"></p>

3. For each *A<sub>i</sub>* calculate a multiplicity *w<sub>i</sub>* defined by:
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22463918/b98d4b16-e7b4-11e6-8e6f-93a6514c6734.PNG"></p>

4. The estimated number of particles *Particles<sub>i</sub>* in *A<sub>i</sub>* can be computed as:
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22464195/e292a71c-e7b5-11e6-9c79-3b1f2b247706.PNG">,</p>
where *k* and *l* are constants that can be changed. Default value is 1.

5. Then the estimated number of particles *Particles<sub>single</sub>* can be computed as:
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22464184/da4248c4-e7b5-11e6-8ffd-eb07b3b4c2bd.PNG"></p>

Results
--------

<table>
<tr><td colspan="9"><b>Particles</b></td></tr>
<tr><td>Generated</td><td> 10 </td><td> 50 </td><td> 75 </td><td> 100 </td><td> 125 </td><td> 150 </td><td> 175 </td><td> 200 </td></tr>
<tr><td>Found</td><td> 10 </td><td> 47 </td><td> 60 </td><td> 82 </td><td> 89 </td><td> 102 </td><td> 114 </td><td> 125 </td></tr>

<tr><td colspan="9"><b>Simple method</b></td></tr>
<tr><td>Average</td><td> 10 </td><td> 47 </td><td> 60 </td><td> 82 </td><td> 88,99 </td><td> 102 </td><td> 113,9 </td><td> 124,9 </td></tr>
<tr><td>Median</td><td> 10,14 </td><td> 48,33 </td><td> 67,65 </td><td> 83,33 </td><td> 103,46 </td><td> 122,03 </td><td> 143 </td><td> 158,8 </td></tr>
<tr><td>Lower quartile</td><td> 15,65 </td><td> 80,11 </td><td> 132 </td><td> 157,54 </td><td> 195,58 </td><td> 271,62 </td><td> 318,27 </td><td> 255,8 </td></tr>
<tr><td>Upper quartile</td><td> 8,63 </td><td> 35,23 </td><td> 39,74 </td><td> 69,28 </td><td> 66,56 </td><td> 70,31 </td><td> 90,1 </td><td> 94,61 </td></tr>

<tr><td colspan="9"><b>Histogram method (param: number of intervals)</b></td></tr>
<tr><td><i>n=3</i></td><td> 2,15 </td><td> 33,75 </td><td> 38,92 </td><td> 36,48 </td><td> 59,29 </td><td> 78,56 </td><td> 84 </td><td> 100 </td></tr>
<tr><td><i>n=5</i></td><td> 6 </td><td> 42,93 </td><td> 59,28 </td><td> 59,93 </td><td> 91,93 </td><td> 128,44 </td><td> 129,3 </td><td> 147,42 </td></tr>
<tr><td><i>n=8</i></td><td> 6 </td><td> 6,1 </td><td> 70,82 </td><td> 74,22 </td><td> 132 </td><td> 163,43 </td><td> 163,42 </td><td> 197,85 </td></tr>

<tr><td colspan="9"><b>Histogram method (param: number of intervals)</b></td></tr>
<tr><td><i>k</i>=1, <i>l</i>=1</td><td> 10 </td><td> 53 </td><td> 79 </td><td> 103 </td><td> 126 </td><td> 157 </td><td> 183 </td><td> 190 </td></tr>
<tr><td><i>k</i>=1, <i>l</i>=10</td><td> 11 </td><td> 50 </td><td> 70 </td><td> 97 </td><td> 126 </td><td> 147 </td><td> 174 </td><td> 188 </td></tr>
<tr><td><i>k</i>=1, <i>l</i>=50</td><td> 11 </td><td> 46 </td><td> 67 </td><td> 94 </td><td> 120 </td><td> 150 </td><td> 176 </td><td> 180 </td></tr>
<tr><td><i>k</i>=10, <i>l</i>=1</td><td> 10 </td><td> 50 </td><td> 72 </td><td> 93 </td><td> 116 </td><td> 134 </td><td> 165 </td><td> 172 </td></tr>
<tr><td><i>k</i>=50, <i>l</i>=1</td><td> 10 </td><td> 50 </td><td> 71 </td><td> 93 </td><td> 114 </td><td> 131 </td><td> 162 </td><td> 169 </td></tr>
</table>

User documentation
-------------------
User interface is devided to two sections. The first section includes a preview image. The second section includes all control buttons.

1. In the first box you can enter a number of particles that will be generated on canvas. The box contains button for generating particles, saving and loading image. 
2. The number of particles, perimeters and areas are computed after generating.
3. In the *Simple method* box you can choose a method for *A<sub>ref</sub>* selection. 
4. In the *Histogram method* box you can enter a number of intervals.
5. In the *Circularity* box you can enter values for *k* and *l* constants.

<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22464780/d539e9f6-e7b8-11e6-83a8-022acddd7749.PNG"></p>

Easter egg
-----------
If you start the program with command line argument `deadpool`, random particles will look like a little Deadpool. 
<p align="center"><img src="https://cloud.githubusercontent.com/assets/5311408/22464392/e7a69320-e7b6-11e6-9464-89eb699544a9.PNG"></p>
