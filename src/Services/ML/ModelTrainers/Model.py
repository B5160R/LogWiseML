# Train model on the given data from the dataset.csv file

# Import the necessary libraries
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import pickle
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression

# Load the dataset
dataset = pd.read_csv('../Data/Datasets/dataset.csv')

# Split the dataset into X and y
X = dataset.iloc[:, :-1].values
y = dataset.iloc[:, -1].values

# Split the dataset into train and test sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2)

# Train the model
regressor = LinearRegression()
regressor.fit(X_train, y_train)

# Save the model to disk
pickle.dump(regressor, open('../Data/Models/model.pkl', 'wb'))