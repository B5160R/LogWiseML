from matplotlib import pyplot as plt
import pandas as pd
import pickle
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score

#Load the Dataset
dataset = pd.read_csv('../Data/Datasets/dataset.csv')

# Remove the cols that are not required; Id and MLType
dataset = dataset.drop(['Id', 'MLType'], axis=1)

# Convert the Timestamp column to float
dataset['Timestamp'] = pd.to_datetime(dataset['Timestamp'])

# Convert the Timestamp column to float
dataset['Timestamp'] = dataset['Timestamp'].values.astype(float)

# Convert the Error column to boolean
dataset['Error'] = dataset['Error'].astype('bool')

# Split the Data
X = dataset.drop(['Error'], axis=1)  # Features
y = dataset['Error']  # Target variable

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Create and Train the Model
model = LogisticRegression()
model.fit(X_train, y_train)

# Make Predictions
y_pred = model.predict(X_test)

# Evaluate the Model
accuracy = accuracy_score(y_test, y_pred)
print("Accuracy:", accuracy)

# Visualize the Model
plt.scatter(X_test['Timestamp'], y_test, color='gray')
plt.scatter(X_test['Timestamp'], y_pred, color='red')
plt.show()


# Make different models and compare them
models = {
    "Logistic Regression": LogisticRegression(),
    "Linear Regression": LinearRegression(),
    "Random Forest": RandomForestRegressor(),
    "Decision Tree": DecisionTreeRegressor(),
    "KNN": KNeighborsRegressor()
}

# Create a function to fit and score models
def fit_and_score(models, X_train, X_test, y_train, y_test):

    # Set random seed
    np.random.seed(42)

    # Make a dictionary to keep model scores
    model_scores = {}

    # Loop through models
    for name, model in models.items():

        # Fit the model to the data
        model.fit(X_train, y_train)

        # Evaluate the model and append its score to model_scores
        model_scores[name] = model.score(X_test, y_test)

    return model_scores

model_scores = fit_and_score(models=models, X_train=X_train, X_test=X_test, y_train=y_train, y_test=y_test)
print(model_scores)


# Step 6: Save the Model
pickle.dump(model, open('../Data/Models/model.pkl', 'wb'))
