# Machine Learning Model for unity

## Utility tools
For implementing Machine learning algorithm I needed various tools csv data extraction, tensor processing, saving model etc. So I implemented a tensor class that represents multidimensional data. I used operator overloading to implement most mathematical operations like 
addition, subraction, multiplication and division. I also implementated operations like mean,log, exp etc. Next I needed to parse csv data. I created a parser to parse csv data then created a datastructure called frame to store the data. I has various indexing features
like getting specific columns and rows. For saving the models. I save the trained weights in json. [Utils](https://github.com/VectorTensor/Unity-ML/tree/main/Assets/Scripts/Utils).


## Adaline 
Basic Adaline Model for classification. [Adaline](https://github.com/VectorTensor/Unity-ML/blob/main/Assets/Scripts/Neural%20Networks/Adaline.cs).

## Logistic Regression
Basic Logistic Regression for classification. [Logistic Regression](https://github.com/VectorTensor/Unity-ML/blob/main/Assets/Scripts/Neural%20Networks/LogisticRegression.cs)



