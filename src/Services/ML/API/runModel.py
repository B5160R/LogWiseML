    # Run LogErrorTime model
# Path: src\Services\ML\Models\LogErrorTime\run.py
import pandas as pd
import numpy as np
import pickle

def run():

    dataset = pd.read_csv('analysistdata.csv')

    print(dataset)

    # Remove the cols that are not required; MLType
    dataset = dataset.drop(['MLType'], axis=1)

    # Convert the Timestamp column to float
    dataset['Timestamp'] = pd.to_datetime(dataset['Timestamp'])
    dataset['Timestamp'] = dataset['Timestamp'].values.astype(float)

    single_input = dataset.values.first()

    # Load the model from disk
    model = pickle.load(open('model.pkl', 'rb'))

    # Predict the test set results
    result = model.predict(single_input)

    # Print the predicted result
    return(result)

