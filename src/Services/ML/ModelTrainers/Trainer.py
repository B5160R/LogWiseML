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

# Remove the cols that are not required; Id and MLType
dataset = dataset.drop(['Id', 'MLType'], axis=1)

# Convert the Timestamp column to float
dataset['Timestamp'] = pd.to_datetime(dataset['Timestamp'])
dataset['Timestamp'] = dataset['Timestamp'].values.astype(float)

# Split the dataset into X and y
X = dataset.iloc[:, :-1].values
y = dataset.iloc[:, -1].values

# Split the dataset into train and test sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2)

# Train the model
regressor = LinearRegression()
regressor.fit(X_train, y_train)

# Predict the test set results
y_pred = regressor.predict(X_test)

# Visualize the training set results
plt.scatter(X_train, y_train, color='red')
plt.plot(X_train, regressor.predict(X_train), color='blue')
plt.title('Error vs Time (Training Set)')
plt.xlabel('Error')
plt.ylabel('Time')
plt.show()

# Save the model to disk
pickle.dump(regressor, open('../Data/Models/model.pkl', 'wb'))


