# TonsOfBugs!
**To test; open the scene and create 20,000-100,000 bug instances, and observe the ram usage**

## With Flyweight Design Pattern
![image](https://user-images.githubusercontent.com/58806238/176909314-939d42a1-9a88-477e-9df3-bc57cc8aec5e.png)
</br>*1161MB with 50,000bug instances, each bug has a unique walk speed float and 20 shared random double values*

## Without Flyweight Design Pattern
![image](https://user-images.githubusercontent.com/58806238/176909379-aaa6a212-d956-4c72-994a-f931739b84ec.png)
</br>*1255MB with 50,000bug instances, each bug has a unique walk speed float and 20 unique random double values*

## Key Points
**-** Observe the difference in ram usage</br>
**-** Observe that fps is not affected
